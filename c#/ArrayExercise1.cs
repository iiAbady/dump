using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercise 1
            /*int[] lst = { 1, 0, 3, 6, 2, 4 };
            for (int i = 0; i < lst.Length - 1; i++)
            {
                Console.Write($"{Math.Max(lst[i], lst[i + 1])} ");
            }*/

            // exercise 2
            /* string[] lst = { "python", "java", "css", "php", "html" };
            Console.Write("Enter a charachter: ");
            char letter = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Set mode: 1) Starts With K Letter, 2) Contain K Letter");
            int mode = int.Parse(Console.ReadLine());
            string[] filiterdList = lst.Where((word) =>
            {
                if (mode == 0)
                    return word.StartsWith(letter.ToString());
                else
                    return word.IndexOf(letter) > -1 ? true : false;
            }).ToArray();
            Console.WriteLine(filiterdList[1]);*/


            // exercise 3

            /* string[] lst = { "php course", "php language php tutorial", "java course" };
            Console.Write("Enter the subword: ");
            string subword = Console.ReadLine();
            int counter = 0;

            foreach (var word in lst)
            {
                string[] split = word.Split(' ');
                for (int i = 0; i < split.Length; i++)
                {
                    if (split[i] == subword)
                        counter++;
                }
            }
            Console.WriteLine(counter);*/
        }
    }
}
