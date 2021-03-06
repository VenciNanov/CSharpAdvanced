﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
       private IProviderController providerController;

    public RepairCommand(IProviderController providerController,IList<string> arguments) : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var repairValue = double.Parse(this.Arguments[0]);

        return this.providerController.Repair(repairValue);
    }
}
