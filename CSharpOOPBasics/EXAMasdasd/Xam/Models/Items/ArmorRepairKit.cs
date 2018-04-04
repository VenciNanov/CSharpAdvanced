﻿using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Items
{
    public class ArmorRepairKit:Item
    {
        public ArmorRepairKit() : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
