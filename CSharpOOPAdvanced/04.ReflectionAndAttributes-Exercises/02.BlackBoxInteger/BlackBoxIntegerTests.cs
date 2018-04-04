namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);

            ConstructorInfo constructor = blackBoxType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            BlackBoxInteger blackBox = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });

            string input;

            while ((input = Console.ReadLine())!="END")
            {
                var tokens = input.Split("_");
                var methodName = tokens[0];
                var methodArgs = int.Parse(tokens[1]);

                MethodInfo method = blackBoxType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

                method.Invoke(blackBox, new object[] { methodArgs });

                FieldInfo value = blackBoxType.GetField("innerValue",
                    BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(value.GetValue(blackBox));          
            }
        }
    }
}
