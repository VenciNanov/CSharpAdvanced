using System;
using System.Linq;

namespace _10.HeiganDance
{
    class Program
    {
        public static void Main(string[] args)
        {
            double heigan = 3000000;

            var playerHP = 18500;

            var lastUsedSpellOnPlayr = "";

            var playerRow = 7;
            var playerCol = 7;

            double playerDmg = double.Parse(Console.ReadLine());

            while (true)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var spellInput = input[0];
                var attackRow = int.Parse(input[1]);
                var attackCol = int.Parse(input[2]);

                var spellDmg = 0;
                if (playerHP >= 0)
                {
                    heigan -= playerDmg;
                }

                if (lastUsedSpellOnPlayr == "Cloud")
                {
                    playerHP -= 3500;

                }

                if (heigan <= 0 || playerHP <= 0)
                {
                    break;
                }
                Raid(ref playerHP, ref lastUsedSpellOnPlayr, ref playerRow, ref playerCol, spellInput, attackRow, attackCol);

                if (playerHP <= 0)
                {
                    break;
                }
            }

            Printing(heigan, playerHP, lastUsedSpellOnPlayr, playerRow, playerCol);
        }

        private static void Raid(ref int playerHP, ref string lastUsedSpellOnPlayr, ref int playerRow, ref int playerCol, string spellInput, int attackRow, int attackCol)
        {
            if (IsInDanger(attackRow, attackCol, playerRow, playerCol))
            {
                //Up dangerous or wall
                if (!IsInDanger(attackRow, attackCol, playerRow - 1, playerCol) && !IsWall(playerRow - 1))
                {
                    playerRow--;
                    lastUsedSpellOnPlayr = "";
                }
                //right dangerous or wall
                else if (!IsInDanger(attackRow, attackCol, playerRow, playerCol + 1) && !IsWall(playerCol + 1))
                {
                    playerCol++;
                    lastUsedSpellOnPlayr = "";
                }
                //down
                else if (!IsInDanger(attackRow, attackCol, playerRow + 1, playerCol) && !IsWall(playerRow + 1))
                {
                    playerRow++;
                    lastUsedSpellOnPlayr = "";
                }
                //left
                else if (!IsInDanger(attackRow, attackCol, playerRow, playerCol - 1) && !IsWall(playerCol - 1))
                {
                    playerCol--;
                    lastUsedSpellOnPlayr = "";
                }
                else
                {
                    if (spellInput == "Cloud")
                    {
                        playerHP -= 3500;
                        lastUsedSpellOnPlayr = "Cloud";
                    }
                    else if (spellInput == "Eruption")
                    {
                        playerHP -= 6000;
                        lastUsedSpellOnPlayr = "Eruption";
                    }
                }
            }
        }

        public static void Printing(double heigan, int playerHP, string lastUsedSpellOnPlayr, int playerRow, int playerCol)
        {
            if (heigan > 0)
            {
                Console.WriteLine($"Heigan: {heigan:f2}");
                if (lastUsedSpellOnPlayr == "Cloud")
                {
                    Console.WriteLine($"Player: Killed by Plague Cloud");
                }
                else
                {
                    Console.WriteLine($"Player: Killed by Eruption");
                }
            }
            else if (playerHP > 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {playerHP}");
            }
            else if (playerHP <= 0 && heigan <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                if (lastUsedSpellOnPlayr == "Eruption")
                {
                    Console.WriteLine($"Player: Killed by Eruption");
                }
                else
                {
                    Console.WriteLine($"Player: Killed by Plague Cloud");
                }
            }
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        public static bool IsInDanger(int targetRow, int targetCol, int moveRow, int moveCol)
        {
            return ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1)
                    && (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));
        }
        public static bool IsWall(int moveCell)
        {
            return moveCell < 0 || moveCell >= 15;
        }
    }
}
