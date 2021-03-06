﻿using Exam.Interfaces;
using Exam.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public void Heal(Character character)
        {
            if (!IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            else
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}

