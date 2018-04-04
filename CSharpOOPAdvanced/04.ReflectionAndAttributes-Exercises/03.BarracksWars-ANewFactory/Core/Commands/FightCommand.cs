using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    public class FightCommand : Command
    {

        public FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            return "exit";
        }
    }
}
