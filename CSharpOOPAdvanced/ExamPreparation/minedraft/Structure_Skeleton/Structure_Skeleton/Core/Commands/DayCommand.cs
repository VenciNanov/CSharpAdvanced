using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IHarvesterController harvesterController,IProviderController providerController,IList<string> arguments) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.providerController.Produce());
        sb.AppendLine(this.harvesterController.Produce());

        return sb.ToString().Trim();
    }
}
