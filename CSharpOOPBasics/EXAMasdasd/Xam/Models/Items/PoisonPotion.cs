using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Items
{
    public class PoisonPotion : Item
    {
        public PoisonPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health = Math.Max(0, character.Health - 20);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }

        }

        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
