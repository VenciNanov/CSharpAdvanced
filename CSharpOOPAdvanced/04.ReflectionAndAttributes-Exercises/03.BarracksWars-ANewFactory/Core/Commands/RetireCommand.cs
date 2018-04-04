using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private readonly IRepository Repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);

            var output = $"{unitType} retired!";
            return output;
        }
    }
}
