using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrance
{
    class Program
    {


        static int remainder(int number, int divieder) {
            bool postivie = number > 0 ? true : false;
            while (true)
            {

                if (postivie && number >= 0)
                {
                    number -= divieder;
                }
                else if (!postivie && number <= 0)
                {
                    number += divieder;
                }
                else
                {
                    return postivie ? number + divieder : number - divieder;
                }
            }
        }
        static int power(int number, int power)
        {
            int final = number;
            int now = number;
            for (int i = 0; i < power - 1; i++)
            {
                for (int j = 0; j < number - 1; j++)
                {
                    final += now;
                }
                now = final;
            }
            return final;
        }
        static void Main(string[] args)
        {
            // exercise 1
            Console.Write("Enter Number: ");
            int _number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Divider: ");
            int divider = Convert.ToInt32(Console.ReadLine());
            int test = remainder(_number, divider);
            Console.WriteLine(test);

            // exercise 2
            int odd_number;
            do
            {
                Console.Write("Please enter an odd number: ");
                odd_number = Convert.ToInt32(Console.ReadLine());
            }

            while (odd_number % 2 == 0);

            for (int i = 0; i < odd_number; i++)
            {
                for (int j = 0; j < odd_number; j++)
                {
                    if ((i == 0 || i == odd_number - 1) || (j == 0 || j == odd_number - 1))
                    {
                        Console.Write(" *");
                    } else
                    {
                        if (((i + 1) % 2 == 0) && (j + 1) % 2 == 0) 
                        {
                            Console.Write(" *");
                        }
                        else if (((i + 1) % 2 != 0) && (j + 1) % 2 != 0)
                        {
                            Console.Write(" *");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }
                Console.WriteLine();
            }

            // Exerise 3
            Console.Write("Please enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the root: ");
            int root = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            while (true)
            {
                int num = power(count, root);
                if (num == number)
                {
                    Console.WriteLine($"{root}th root of {number} is: {count}");
                    break;
                }
                else if (num > number)
                {
                    Console.WriteLine($"The {root}th of the number you entered isn't an integer value");
                    break;
                }
                else
                    count += 1;
            }
        }

    }
}
