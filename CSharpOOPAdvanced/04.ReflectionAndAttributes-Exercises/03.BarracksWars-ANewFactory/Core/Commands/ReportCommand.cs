using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public ReportCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {

            var output = this.repository.Statistics;
            return output;
        }
    }
}
