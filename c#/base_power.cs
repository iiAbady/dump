using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base_power
{
    class Program
    {

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
            Console.Write("Please enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the root: ");
            int root = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            while (true)
            {
                int num = power(count, root);
                if (num == number)
                    break;
                else
                    count += 1;
            }
            Console.WriteLine($"{root}th root of {number} is: {count}");
        }
    }
    }
