using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Flames = { "Friends", "Love", "Affection", "Marriage", "Enemy", "Siblings" };
            Console.Write("Enter the first player name: ");
            string player1 = Console.ReadLine().ToLower();
            Console.Write("Enter the second player name: ");
            string player2 = Console.ReadLine().ToLower();

            if (player1 == player2)
            {
                Console.WriteLine("-___-");
                return;
            }
            foreach (char i in player1)
            {
                if (player2.Contains(i))
                {
                    while (player1.Contains(i) || player2.Contains(i))
                    {
                        if (player2.Contains(i))
                            player2 = player2.Remove(player2.IndexOf(i), 1);
                        else
                            player1 = player1.Remove(player1.IndexOf(i), 1);
                    }
                }
            }

            int remainder = player1.Length + player2.Length - 1;
            Console.Write(remainder);
            Console.WriteLine("Relationship status: " + Flames[(remainder % 6)]);
        }
    }
}
