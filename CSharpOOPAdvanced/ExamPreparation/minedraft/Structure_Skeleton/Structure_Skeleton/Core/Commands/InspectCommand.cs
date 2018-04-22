using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private HarvesterController harvesterController;

    private ProviderController providerController;

    public InspectCommand(HarvesterController harvesterController, ProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        bool isParsed = int.TryParse(this.Arguments[0], out int id);
        if (!isParsed)
        {
            return string.Format(Constants.NoEntityFoundWithId, id);
        }

        return Inspect(id);
    }

    private string Inspect(int id)
    {
        if (this.harvesterController.Entities.Any(e => e.ID == id))
        {
            return this.harvesterController.Entities.FirstOrDefault(e => e.ID == id).ToString();
        }
        else if (this.providerController.Entities.Any(e => e.ID == id))
        {
            return this.providerController.Entities.FirstOrDefault(e => e.ID == id).ToString();
        }
        else
        {
            return string.Format(Constants.NoEntityFoundWithId, id);
        }
    }
}