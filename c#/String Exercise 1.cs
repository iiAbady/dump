using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercise 1
            /* string[] nums = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            Console.Write("Enter the string: ");
            string input = Console.ReadLine();
            foreach (var word in input.Split(' '))
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == word)
                        Console.Write(i);
                }
            }
            Console.WriteLine(); */

            // exercise 2
            /* string sentence = "python is the easiest language";
            string[] split = sentence.Split(' ');
            Console.WriteLine(sentence);
            Console.WriteLine("Enter the word: ");
            string word = Console.ReadLine();
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == word)
                {
                    Console.WriteLine(i+1);
                    break;
                }
            } */



            // exercise 3

            /* Console.Write("Enter the string: ");
            string word = Console.ReadLine();
            string usedChars = "";
            Console.Write('[');
            for (int i = 0; i < word.Length; i++)
            {
                if (usedChars.Contains(word[i]))
                    continue;
                int count = 0;
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[i] == word[j])
                        count++;
                }
                usedChars += word[i];
                Console.Write($"{count},");
            }
            Console.Write(']');
            Console.WriteLine(); */
        }
    }
}
