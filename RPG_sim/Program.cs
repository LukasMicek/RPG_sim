using System.IO;

namespace RPG_sim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int p_hp, m_hp; // health points
            int p_atk, m_atk; // attack stat
            int p_def, m_def; // defense stat
            int p_luck, m_luck; // luck stat
            bool play = true;


            Console.WriteLine("Welcome to the RPG fight simulator!");

            while (play) // Game loop
            {
                // Input for player's health points
                Console.Write("\nPlease enter the player's health points: ");
                while (!int.TryParse(Console.ReadLine(), out p_hp) || p_hp <= 0)
                {
                    if (p_hp < 0)
                    {
                        Console.WriteLine("Health can't be a negative");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for health points.");
                    }
                }


                // Input for monster's health points
                Console.Write("\nNow enter the monster's health points: ");
                while (!int.TryParse(Console.ReadLine(), out m_hp) || m_hp <= 0)
                {
                    if (m_hp < 0)
                    {
                        Console.WriteLine("Health can't be a negative");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for health points.");
                    }
                }


                // Input for player's attack points
                Console.Write("\nPlease enter the player's attack points: ");
                while (!int.TryParse(Console.ReadLine(), out p_atk) || p_atk <= 0)
                {
                    if (p_atk < 0)
                    {
                        Console.WriteLine("Attack can't be negative");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for attack points.");
                    }
                }


                // Input for monster's attack points
                Console.Write("\nNow enter the monster's attack points: ");
                while (!int.TryParse(Console.ReadLine(), out m_atk) || m_atk <= 0)
                {
                    if (m_atk < 0)
                    {
                        Console.WriteLine("Attack can't be negative");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for attack points.");
                    }
                }


                // Input for player's defense points
                Console.Write("\nPlease enter the player's defense points: ");
                while (!int.TryParse(Console.ReadLine(), out p_def) || p_def < 0 || p_def > m_atk)
                {
                    if (p_def < 0)
                    {
                        Console.WriteLine("Defense can't be negative");
                    }
                    else if (p_def > m_atk)
                    {
                        Console.WriteLine("Defense can't be higher or equal to opponent attack");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for defense points.");
                    }
                }


                // Input for monster's defense points
                Console.Write("\nNow enter the monster's defense points: ");
                while (!int.TryParse(Console.ReadLine(), out m_def) || m_def < 0 || m_def > p_atk)
                {
                    if (m_def < 0)
                    {
                        Console.WriteLine("Defense can't be negative");
                    }
                    else if (m_def > p_atk)
                    {
                        Console.WriteLine("Defense can't be higher or equal to opponent attack");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for defense points.");
                    }
                }


                // Input for player's luck points
                Console.Write("\nPlease enter the player's luck points: ");
                while (!int.TryParse(Console.ReadLine(), out p_luck) || p_luck < 0 || p_luck > 10)
                {
                    if (p_luck < 0)
                    {
                        Console.WriteLine("Luck can't be negative");
                    }
                    else if (p_luck > 10)
                    {
                        Console.WriteLine("Luck can't be higher than 10");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for luck points.");
                    }
                }


                // Input for monster's luck points
                Console.Write("\nNow enter the monster's luck points: ");
                while (!int.TryParse(Console.ReadLine(), out m_luck) || m_luck < 0 || m_luck > 10)
                {
                    if (m_luck < 0)
                    {
                        Console.WriteLine("Luck can't be negative");
                    }
                    else if (m_luck > 10)
                    {
                        Console.WriteLine("Luck can't be higher or equal to opponent attack");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for luck points.");
                    }
                }

                Console.WriteLine("\nPress 'Enter' to start a fight");
                Console.ReadLine();
                Console.Clear();
          
                while (p_hp > 0 && m_hp > 0) // fight loop
                {
                    bool playerTurn = random.Next(2) == 0;

                    if (playerTurn)
                    {
                        PlayerAttack(ref m_hp, p_atk, m_def, p_luck, m_luck, random);
                    }
                    else
                    {
                        MonsterAttack(ref p_hp, m_atk, p_def, p_luck, m_luck, random);
                    }

                }
                if (p_hp <= 0) // check if character is dead
                {
                    Console.WriteLine("Player was slain by a monster");
                }
                else
                {
                    Console.WriteLine("Monster was slain by a Player");
                }
                Console.Write("Do you want to play another round? (yes/no): ");
                string response = Console.ReadLine().ToLower();
                play = (response == "yes");
                Console.Clear();
            }
            Console.WriteLine("Thanks for playing!");
        }
        private static void PlayerAttack(ref int m_hp, int p_atk, int m_def, int p_luck, int m_luck, Random random) // player attack method
        {
            // random events depend on luck
            bool isCrit = random.Next(100) < (p_luck * 5); //5% per point of luck for crit
            bool evade = random.Next(100) < (m_luck * 3); //3% per point of luck for evasion

            if (evade)
            {
                Console.WriteLine("Monster evaded Player's attack!");
                Console.ReadLine();
            }
            else
            {
                if (isCrit)
                {
                    Console.WriteLine($"Player is hitting a monster with a critical for {p_atk * 2} points");
                    Console.WriteLine($"Monster is defending {m_def} points");
                    m_hp = m_hp - (p_atk * 2 - m_def);
                    Console.WriteLine($"Monster is hit with {p_atk * 2 - m_def} damage and is left with {m_hp} hp\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Player is hitting a monster for {p_atk} points");
                    Console.WriteLine($"Monster is defending {m_def} points");
                    m_hp = m_hp - (p_atk - m_def);
                    Console.WriteLine($"Monster is hit with {p_atk - m_def} damage and is left with {m_hp} hp\n");
                    Console.ReadLine();
                }
            }
        }
        private static void MonsterAttack(ref int p_hp, int m_atk, int p_def, int m_luck, int p_luck, Random random) // monster attack metod
        {
            // random events depend on luck
            bool isCrit = random.Next(100) < (m_luck * 5); //5% per point of luck for crit
            bool evade = random.Next(100) < (p_luck * 3); //3% per point of luck for evasion

            if (evade)
            {
                Console.WriteLine("Player evaded Monster's attack!");
                Console.ReadLine();
            }
            else
            {
                if (isCrit)
                {
                    Console.WriteLine($"Monster is hitting a player with a critical for {m_atk * 2} points");
                    Console.WriteLine($"Player is defending {p_def} points");
                    p_hp = p_hp - (m_atk * 2 - p_def);
                    Console.WriteLine($"Player is hit with {m_atk * 2 - p_def} damage and is left with {p_hp} hp\n");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Monster is hitting a player for {m_atk} points");
                    Console.WriteLine($"Player is defending {p_def} points");
                    p_hp = p_hp - (m_atk - p_def);
                    Console.WriteLine($"Player is hit with {m_atk - p_def} damage and is left with {p_hp} hp\n");
                    Console.ReadLine();
                }
            }
        }
    }
}