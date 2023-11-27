using System.IO;

namespace RPG_sim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int p_hp, m_hp; // health points
            int p_atk, m_atk; // attack
            int p_def, m_def; // defense

            Console.WriteLine("Welcome to the RPG fight simulator!");

            // Input for player's health points
            Console.Write("Please enter the player's health points: ");
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
            Console.Write("Please enter the player's attack points: ");
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
            Console.Write("Please enter the player's defense points: ");
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
            Console.Write("Please enter the monster's defense points: ");
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


            while (p_hp > 0 && m_hp > 0) // fight loop
            {
                bool playerTurn = random.Next(2) == 0;

                if (playerTurn)
                {
                    PlayerAttack(ref m_hp, p_atk, m_def, random);
                }
                else
                {
                    MonsterAttack(ref p_hp, m_atk, p_def, random);
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
        }
        private static void PlayerAttack(ref int m_hp, int p_atk, int m_def, Random random) // player attack method
        {
            bool isCrit = random.Next(2) == 0; // random crit chace
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
        private static void MonsterAttack(ref int p_hp, int m_atk, int p_def, Random random) // monster attack metod
        {
            bool isCrit = random.Next(2) == 0; // random crit chance
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