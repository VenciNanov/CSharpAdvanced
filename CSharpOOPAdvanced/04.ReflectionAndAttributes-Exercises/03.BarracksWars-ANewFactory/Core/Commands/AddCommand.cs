using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IUnitFactory unitFactory;

        public AddCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = base.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            var output = unitType + " added!";
            return output;
        }
    }
}
