using Exam.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
