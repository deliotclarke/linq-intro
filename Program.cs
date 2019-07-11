using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };


            IEnumerable<string> LFruits = from fruit in fruits
                                          where fruit.Contains("L")
                                          select fruit;

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
                {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0);

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(name => name[0]).ToList();

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
                {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            List<int> ascend = numbers2.OrderBy(x => x).ToList();

            // Output how many numbers are in numbers2
            int howMany = numbers2.Count;

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double totalPurchases = purchases.Sum();


            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double mostExpensive = prices.OrderByDescending(x => x).ToList()[0];


            // Store each number in the following List until a perfect square is detected
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            double test = Math.Sqrt(4);

            List<int> findPerfectSquare = wheresSquaredo.TakeWhile(n => (Math.Sqrt(n) % 1 != 0)).ToList();



            // Create a group of Millionaires!!
            List<Customer> customers = new List<Customer>()
            {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            IEnumerable<Customer> millionaires = from client in customers
                                                 where client.Balance > 999999
                                                 select client;

            var millionaireCount = from client in customers
                                   group client by client.Balance > 999999 into vipList
                                   from vipClient in vipList
                                   group vipClient by vipClient.Bank into bankGroup
                                   select new
                                   {
                                       Bank = bankGroup.Key,
                                       milliCount = bankGroup.Count()
                                   };

            Console.WriteLine();
            Console.WriteLine("ha-milli ha-milli ha-milli count:");
            foreach (var obj in millionaireCount)
            {
                Console.WriteLine();
                Console.WriteLine($"{obj.Bank} millionaire count is {obj.milliCount}.");
                Console.WriteLine();
            }
        }
    }
}
