using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercise 4
            /* Console.Write("Enter a string: ");
            string word = Console.ReadLine();
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            string left = word.Substring(number) + word.Substring(0, number);
            string right = word.Substring(word.Length - number) + word.Substring(0, word.Length - number);
            Console.WriteLine("Left rotation: \"{0}\"", left);
            Console.WriteLine("Right rotation: \"{0}\"", right);*/

            // exercise 5

            /* Console.Write("Enter the string: ");
            string word = Console.ReadLine();
            Console.Write("Enter the substring: ");
            string subword = Console.ReadLine();
            int counter = 0;
            string res = "True";
            while (word != "")
            {
                if (counter >= word.Length - 1) {
                    res = "False";
                    break;
                }
                string _word = word.Substring(counter, subword.Length);
                if (_word == subword)
                {
                    if (counter == 0)
                        word = word.Substring(subword.Length);
                    else
                        word = word.Substring(0, counter) + word.Substring(counter + subword.Length);
                    counter = 0;
                } else
                    counter++;
                
            }
            Console.WriteLine(res);
            */


            // exercise 6
            /* Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            char firstLetter = char.IsLower(input[0]) ? char.ToUpper(input[0]) : char.ToLower(input[0]);
            input = firstLetter + input.Substring(1);
            for (int i = 1; i < input.Length; i++)
            {
                char letter = char.IsLower(input[i]) ? char.ToUpper(input[i]) : char.ToLower(input[i]);
                input = input.Substring(0, i) + letter +  input.Substring(i+1);
            }
            Console.WriteLine(input);*/
        }
    }
}
