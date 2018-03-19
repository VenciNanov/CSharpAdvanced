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
        private Queue<Item> itemPool;
        private Faction faction;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.heroes = new Dictionary<string, Character>();
            this.itemPool = new Queue<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var type = args[1];
            var name = args[2];

            if (faction != "CSharp" || faction != "Java")
            {
                throw new ArgumentException($"Invalid faction {faction}!"); ;
            }

            var character = characterFactory.CreateCharacter(faction, args[1], args[2]);

            heroes[name] = character;

            return $"{name} joined the party";
        }

        public string AddItemToPool(string[] args)
        {
            var item = itemFactory.CreateItem(args[0]);

            itemPool.Enqueue(item);

            return $"{args[0]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var player = args[0];
            var item = itemPool.Last();

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            heroes[player].Bag.AddItem(item);
            itemPool.Dequeue();

            return $"{player} picked up {item.ToString()}!";

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
            var item = heroes[player].Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

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

            var reciver = heroes[reciverName];

            var item = heroes[giverName].Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);
            heroes[giverName].UseItemOn(item, reciver);

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
            var reciver = heroes[reciverName];

            var item = heroes[giverName].Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

            heroes[giverName].GiveCharacterItem(item, reciver);

            return $"{giverName} used {itemName} on {reciverName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            foreach (var hero in heroes.OrderByDescending(x => x.Value.IsAlive).ThenByDescending(x => x.Value.Health))
            {

                sb.Append(string.Join(Environment.NewLine, hero.ToString()));
            }
            return sb.ToString().Trim();
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
            if (heroes[attackerName].GetType().Name == "Cleric")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior warrior = (Warrior)heroes[attackerName];

            var reciver = heroes[reciverName];

            warrior.Attack(reciver);

            var sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {reciverName} for {warrior.AbilityPoints} hit points! {reciverName} has {reciver.Health}/{reciver.BaseHealth} HP and {reciver.Armor}/{reciver.BaseArmor} AP left!");

            return sb.ToString().Trim();
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
            if (heroes[attackerName].GetType().Name == "Warrior")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Cleric healer = (Cleric)heroes[attackerName];

            var reciver = heroes[reciverName];

            healer.Heal(reciver);

            var sb = new StringBuilder();

            sb.AppendLine($"{healer.Name} heals {reciverName} for {healer.AbilityPoints}! {reciverName} has {reciver.Health} health now!");

            return sb.ToString().Trim();
        }

        public string EndTurn(string[] args)
        {
            var character = heroes.Values;

            var sb = new StringBuilder();

            if (heroes.Values.Where(x => x.IsAlive).Count() == 1)
            {
                foreach (var hero in heroes.Values)
                {
                    hero.RestMultiplier += 1;
                }
            }
            foreach (var player in heroes.Values.Where(x => x.IsAlive))
            {
                var hpAfterRest = player.BaseHealth * player.RestMultiplier;

                sb.AppendLine($"{player.Name} rests ({player.Health} => {hpAfterRest})");

                player.Rest();
            }
            return sb.ToString().Trim();

        }

        public bool IsGameOver()
        {
            if (heroes.Values.Any(x => x.IsAlive))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
