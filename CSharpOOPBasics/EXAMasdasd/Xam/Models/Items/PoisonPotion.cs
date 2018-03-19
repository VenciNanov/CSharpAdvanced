using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion(int weight) : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException("Must be alive to perform this action!");
            }
            else if (character.Health - 20 <= 0)
            {
                character.IsAlive = false;
            }
            else
            {
                character.Health -= 20;
            }

        }

        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
