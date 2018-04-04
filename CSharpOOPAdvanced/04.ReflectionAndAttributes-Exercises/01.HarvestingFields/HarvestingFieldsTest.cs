 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = string.Empty;

            while ((input=Console.ReadLine())!= "HARVEST")
            {
                var modifier = input;

                var harvestType = typeof(HarvestingFields);

                var fields = harvestType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                fields = GetFieldInformation(fields, modifier);

                foreach (var fieldInfo in fields)
                {
                    var fieldAccessModifier = fieldInfo.Attributes.ToString().ToLower() == "family" ? "protected" : fieldInfo.Attributes.ToString().ToLower();

                    Console.WriteLine($"{fieldAccessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }
            }
        }

        private static FieldInfo[] GetFieldInformation(FieldInfo[] fields, string modifier)
        {

            switch (modifier)
            {
                case "public":
                    fields = fields.Where(x => x.IsPublic).ToArray();
                    break;

                case "private":
                    fields = fields.Where(x => x.IsPrivate).ToArray();
                    break;

                case "protected":
                    fields = fields.Where(x => x.IsFamily).ToArray();
                    break;
            }
            return fields;
        }
    }
}
