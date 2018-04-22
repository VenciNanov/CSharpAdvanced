using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammoType = this.GetAmmoType(ammunitionName);

        return (IAmmunition)Activator
            .CreateInstance(ammoType, ammunitionName);
    }

    private Type GetAmmoType(string ammunitionName)
    {
        Type[] assemblyTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        return assemblyTypes
            .FirstOrDefault(x => x.Name == ammunitionName);
    }
}
