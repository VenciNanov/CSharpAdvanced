using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion(int weight) : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.Health += 20;

        }
        public override string ToString()
        {
            return $"{GetType().Name}";
        }

    }
}
