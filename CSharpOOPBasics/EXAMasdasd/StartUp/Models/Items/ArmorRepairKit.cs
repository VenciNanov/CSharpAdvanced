using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Items
{
    public class ArmorRepairKit:Item
    {
        public ArmorRepairKit(int weight) : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException("Must be alive to perform this action!");
            }
            else
            {
                character.Armor = character.BaseArmor;   
            }
        }
    }
}
