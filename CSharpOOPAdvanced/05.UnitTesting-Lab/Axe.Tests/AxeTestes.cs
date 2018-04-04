using NUnit.Framework;
using System;

[TestFixture]
    public class AxeTestes
    {
        [Test]
        public void AxeLoosesDuruabilityAfterAttack()
        {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
    }

