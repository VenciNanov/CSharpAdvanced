using Exam.Interfaces;
using Exam.Models.Bags;
using Exam.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restMultiplier;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = BaseHealth;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.isAlive = true;
            this.RestMultiplier = 0.2;
        }

        public double RestMultiplier
        {
            get { return restMultiplier; }
            protected set { restMultiplier = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Faction Faction
        {
            get { return faction; }
            set
            {
                faction = value;
            }
        }

        public Bag Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            set { abilityPoints = value; }
        }

        public double Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            set { baseArmor = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (Health < 0)
                {
                    IsAlive = false;
                }
                health = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            set { baseHealth = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            var dmg = 0.0;

            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Armor - hitPoints <= 0)
            {
                dmg = hitPoints - Armor;
                this.Armor -= dmg;
                if (dmg > 0)
                {
                    this.Health -= dmg;
                }
            }
            else if (this.Health - hitPoints <= 0)
            {
                this.Health -= hitPoints;
                IsAlive = false;
            }
        }
        public void Rest()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            this.Health = BaseHealth * RestMultiplier;
        }
        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);

        }
        public void UseItemOn(Item item, Character character)
        {
            if (!IsAlive && !character.isAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);

        }
        public void GiveCharacterItem(Item item, Character character)
        {
            if (!IsAlive && !character.isAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.ReciveItem(item);
            bag.Items.Remove(item);

        }
        public void ReciveItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Bag.Items.Add(item);
        }

    }
}
