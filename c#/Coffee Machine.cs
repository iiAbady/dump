using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Machine
{
    class Program
    {
        static Dictionary<string, double> espresso = new Dictionary<string, double>
            {
                { "water", 50 },
                { "coffee", 18 },
                { "cost", 1.5 }
            };

        static Dictionary<string, double> latte = new Dictionary<string, double>
            {
                { "water", 200 },
                { "coffee", 24 },
                { "milk", 150 },
                { "cost", 2.5 }
            };

        static Dictionary<string, double> cappuccino = new Dictionary<string, double>
            {
                { "water", 250 },
                { "coffee", 24 },
                { "milk", 100 },
                { "cost", 3.0 }
            };

        static Dictionary<string, Dictionary<string, double>> menu = new Dictionary<string, Dictionary<string, double>>
            {
                { "espresso", espresso },
                { "latte", latte },
                { "cappuccino", cappuccino }
            };

        static Dictionary<string, double> resources = new Dictionary<string, double>
            {
                { "water", 1000 },
                { "milk", 600 },
                { "coffee", 200 }
            };
        static double money = 0;
        static void buy(string orderType)
        {
            
        }
        static void Main(string[] args)
        {
            Console.Write("Coffe Machine\n");

            while (true)
            {
                Console.WriteLine("What would you like to order?\n\n1.espresso\n2.latte\n3.cappuccino\n");
                Console.Write("Order: ");
                string order = Console.ReadLine();
                if (order == "1" || order == "espresso")
                    buy("espresso");
                else if (order == "2" || order == "latte")
                    buy("latte");
                else if (order == "3" || order == "cappuccino")
                    buy("cappuccino");
                else if (order == "report")
                {
                    Console.WriteLine($"Water: {resources["water"]}ml\nMilk: {resources["milk"]}ml\nCoffee: {resources["coffee"]}g\nMoney: {money}$\n");
                }
                else if (order == "refill")
                {
                    while (true)
                    {
                        Console.WriteLine("Please enter the item: ");
                        string item = Console.ReadLine();
                        if (item == "water")
                        {
                            resources["water"] = 1000;
                            break;
                        }
                        else if (item == "milk")
                        {
                            resources["milk"] = 600;
                            break;
                        }
                        else if (item == "coffee")
                        {
                            resources["coffee"] = 200;
                            break;
                        }
                        else if (item == "cancel")
                            break;
                        else
                            Console.WriteLine("Please enter the item correctly");
                    }
                }
                else if (order == "off")
                    break;
                else
                    Console.WriteLine("Please enter one of the orders or\n\"off\" to close the program\nreport to report the resources\nrefill to refill the resources\n");
            }
        }
    }
}
