using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameToInvestigate, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(nameToInvestigate);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {nameToInvestigate}");
        foreach (var field in classFields.Where(x => fieldsToInvestigate.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in classNonPublicMethods.Where(x=>x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (MethodInfo method in classPublicMethods.Where(x=>x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (var method in classMethods.Where(x=>x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (var method in classMethods.Where(x=>x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
