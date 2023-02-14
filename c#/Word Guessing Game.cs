using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Guessing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //inital
            string[] words = { "java", "football", "basketball", "" };
            int random = new Random().Next(0, words.Length - 1);
            string word = words[random];
            string temp = "";

            //user (input - display)
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Good Luck! {name}\nGuess The characters");
            for (int i = 0; i < word.Length; i++)
                temp += "-";
            Console.WriteLine(temp);

            // code
            int guesses = 0;

            while (temp != word && guesses < 12)
            {
                Console.Write("Guess a character: ");
                char character = Convert.ToChar(Console.ReadLine());
                for (int i = 0; i < word.Length; i++)
                {
                    if (character == word[i])
                    {
                        temp = temp.Remove(i, 1);
                        temp = temp.Insert(i, character.ToString());
                    }
                }
                Console.WriteLine(temp);
                guesses++;
            }

            Console.WriteLine(
                temp == word ? "You win (:" : "You Lose ):"
                );
        }
    }
}
