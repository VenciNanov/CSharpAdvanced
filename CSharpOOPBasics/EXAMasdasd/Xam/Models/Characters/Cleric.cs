using Exam.Interfaces;
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
        protected override double RestHealMultiplier => 0.5;
        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            character.Health = Math.Min(character.BaseHealth, character.Health + this.AbilityPoints);
        }
    }
}

