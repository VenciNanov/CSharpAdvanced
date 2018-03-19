using Exam.Models;
using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Interfaces
{
   public interface IHealable
    {
        void Heal(Character character);
    }
}
