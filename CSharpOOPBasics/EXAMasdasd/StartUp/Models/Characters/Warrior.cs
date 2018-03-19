using Exam.Interfaces;
using Exam.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character.Name == Name)
            {
                throw new InvalidCastException("Cannot attack self!");
            }

            if (character.Faction == Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {Faction} factoon!");
            }

            TakeDamage(character.AbilityPoints);
        }
    }
}
