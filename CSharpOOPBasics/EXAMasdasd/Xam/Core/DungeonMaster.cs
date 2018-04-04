using Exam.Interfaces;
using Exam.Models;
using Exam.Models.Characters;
using Exam.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam.Factories;

namespace Xam.Core
{
    public class DungeonMaster
    {
        private Dictionary<string, Character> heroes;
        private Stack<Item> itemPool;

        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.heroes = new Dictionary<string, Character>();
            this.itemPool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var type = args[1];
            var name = args[2];

            var character = characterFactory.CreateCharacter(faction, args[1], args[2]);

            heroes[name] = character;

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var item = itemFactory.CreateItem(args[0]);

            this.itemPool.Push(item);

            return $"{args[0]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var player = args[0];

            if (!heroes.ContainsKey(player))
            {
                throw new ArgumentException($"Character {player} not found!");
            }

            if (!this.itemPool.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            
            var item = itemPool.Pop();
            heroes[player].ReciveItem(item);
            return $"{player} picked up {item.GetType().Name}!";

        }

        public string UseItem(string[] args)
        {
            var player = args[0];
            var itemName = args[1];

            if (!heroes.ContainsKey(player))
            {
                throw new ArgumentException($"Character {player} not found!");
            }

            var hero = heroes[player];

            var item = hero.Bag.GetItem(itemName);

            heroes[player].UseItem(item);

            return $"{player} used {item}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var reciverName = args[1];
            var itemName = args[2];

            if (!heroes.ContainsKey(giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!heroes.ContainsKey(reciverName))
            {
                throw new ArgumentException($"Character {reciverName} not found!");
            }
            var giver = heroes[giverName];
            var reciver = heroes[reciverName];

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, reciver);

            return $"{giverName} used {itemName} on {reciverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var reciverName = args[1];
            var itemName = args[2];


            if (!heroes.ContainsKey(giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!heroes.ContainsKey(reciverName))
            {
                throw new ArgumentException($"Character {reciverName} not found!");
            }

            var giver = heroes[giverName];
            var reciver = heroes[reciverName];
            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, reciver);

            return $"{giverName} gave {reciverName} {itemName}.";
        }

        public string GetStats()
        {
            var sorted = this.heroes.Values
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health);

            var result = string.Join(Environment.NewLine, sorted);

            return result;
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var reciverName = args[1];

            if (!heroes.ContainsKey(attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!heroes.ContainsKey(reciverName))
            {
                throw new ArgumentException($"Character {reciverName} not found!");
            }
            //if (heroes[attackerName].GetType().Name == "Cleric")
            //{
            //    throw new ArgumentException($"{attackerName} cannot attack!");
            //}

             var attacker = heroes[attackerName];

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var reciver = heroes[reciverName];

            attackingCharacter.Attack(reciver);

            var result =
                $"{attackerName} attacks {reciverName} for {attacker.AbilityPoints} hit points! {reciverName} has {reciver.Health}/{reciver.BaseHealth} HP and {reciver.Armor}/{reciver.BaseArmor} AP left!";

            if (!reciver.IsAlive)
            {
                result += Environment.NewLine + $"{reciver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            var attackerName = args[0];
            var reciverName = args[1];

            if (!heroes.ContainsKey(attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!heroes.ContainsKey(reciverName))
            {
                throw new ArgumentException($"Character {reciverName} not found!");
            }
            //if (heroes[attackerName].GetType().Name == "Warrior")
            //{
            //    throw new ArgumentException($"{attackerName} cannot attack!");
            //}

            var healer = heroes[attackerName];
            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }
            var reciver = heroes[reciverName];

            healingCharacter.Heal(reciver);

            var sb = new StringBuilder();

            var result =
                 $"{healer.Name} heals {reciver.Name} for {healer.AbilityPoints}! {reciver.Name} has {reciver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var aliveChars = heroes.Values.Where(x => x.IsAlive).ToArray();

            var sb = new StringBuilder();

            foreach (var hero in aliveChars)
            {
                var previousHp = hero.Health;

                hero.Rest();

                var currentHP = hero.Health;
                sb.AppendLine($"{hero.Name} rests ({previousHp} => {currentHP})");
            }
            if (aliveChars.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }
            var result = sb.ToString().TrimEnd('\r', '\n');
            return result;
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivors = this.heroes.Values.Count(x => x.IsAlive) <= 1;
            var lasSuriversSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivors && lasSuriversSurvivedTooLong;
        }

    }
}
