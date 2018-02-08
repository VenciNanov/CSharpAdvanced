using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03.NumberWars
{
    class Program
    {
        private static Queue<KeyValuePair<int, char>> playerOneDeck;
        private static Queue<KeyValuePair<int, char>> playerTwoDeck;

        private static List<KeyValuePair<int, char>> board;

        private static bool hasWiner;

        static void Main(string[] args)
        {
            board = new List<KeyValuePair<int, char>>();

            FillDeck(ref playerOneDeck);
            FillDeck(ref playerTwoDeck);

            var turnsCounter = 0;

            while (turnsCounter <= 100000000 || hasWiner == false)
            {
                if (playerOneDeck.Count==0||playerTwoDeck.Count==0)
                {
                    hasWiner = true;
                    break;
                }
                else
                {
                    Turn();
                    turnsCounter++;
                }
            }

            var resultt = string.Empty;

            if (playerOneDeck.Count==playerTwoDeck.Count)
            {
                resultt = "Draw";
            }
            else
            {
                resultt = $"{(playerOneDeck.Count > playerTwoDeck.Count ? "First" : "Second")} player wins";
            }

            Console.WriteLine($"{resultt} after {turnsCounter} turns");

        }

        private static void Turn()
        {
            board.Clear();

            var playerOneCard = GetCard(playerOneDeck);
            var playerTwoCard = GetCard(playerTwoDeck);

            CompareScore(playerOneCard.Key, playerTwoCard.Key);

        }

        private static void CompareScore(int playerOneScore, int playerTwoScore)
        {
            if (playerOneScore>playerTwoScore)
            {
                TransferBoardCard(playerOneDeck);
            }
            else if (playerOneScore<playerTwoScore)
            {
                TransferBoardCard(playerTwoDeck);
            }
            else
            {
                if (playerOneDeck.Count>=3&& playerTwoDeck.Count>=3)
                {
                    War();
                }
                else
                {
                    hasWiner = true;
                }
            }
        }

        private static void War()
        {
            var playerOneSum = 0;
            var playerTwoSum = 0;

            for (int i = 0; i < 3; i++)
            {
                playerOneSum += (GetCard(playerOneDeck).Value - 'a' + 1);
                playerTwoSum += (GetCard(playerTwoDeck).Value - 'a' + 1);
            }
            CompareScore(playerOneSum, playerTwoSum);
        }

        private static void TransferBoardCard(Queue<KeyValuePair<int, char>> deck)
        {
            var ordered = board.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value);

            foreach (var item in ordered)
            {
                deck.Enqueue(item);
            }
            
        }

        private static KeyValuePair<int,char> GetCard(Queue<KeyValuePair<int,char>> deck)
        {
            var card = deck.Dequeue();
            board.Add(card);

            return card;
        }

        private static void FillDeck(ref Queue<KeyValuePair<int, char>> deck)
        {
            deck = new Queue<KeyValuePair<int, char>>();

            var data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var reg = new Regex(@"(?<number>\d+)(?<card>\w+)");

            foreach (var item in data)
            {
                var match = reg.Match(item);

                var number = int.Parse(match.Groups["number"].Value);
                var card = match.Groups["card"].Value[0];

                var kvp = new KeyValuePair<int, char>(number, card);

                deck.Enqueue(kvp);
            }
        }
    }
}
