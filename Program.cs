using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{

    // Build a collection of customers who are millionaires
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Program
    {
        public static void Main() {


//...............................................................................................................................//
// Start of step one //
//...............................................................................................................................//
            //Restriction/Filtering Operations
            // Find the words in the collection that start with the letter 'L'
                List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};
                    
                    IEnumerable<string> fruitsWithL =  from fruit in fruits 
                        where fruit.StartsWith("L")
                        select fruit;

                        foreach(string fruit in fruitsWithL) 
                        {
                            Console.WriteLine(fruit);
                        }
                
                // var LFruits = from fruit in fruits ...
//...............................................................................................................................//
// End Of step one //
//...............................................................................................................................//


//...............................................................................................................................//
// Start Of step Two//
//...............................................................................................................................//
                // Which of the following numbers are multiples of 4 or 6
                List<int> numbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                }
               
                var fourSixMultiples = numbers.Where(number => (number%4 == 0) || (number%6 == 0));

                foreach


//...............................................................................................................................//
// End Of step two //
//...............................................................................................................................//

            List<Customer> customers = new List<Customer>() {
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


            //you can use "var" for linq statements .. only ... and the below is a linq statement
            var millionaires = from cust in customers
                where cust.Balance >= 1000000
                select cust;

                // foreach (var cust in millionaires)
                // {
                //     Console.WriteLine($"{cust.Name} ${cust.Balance}");
                // }

                var grouped = from mill in millionaires 
                    //below is the chose key we want to group by 
                    // each item is grouped by bank, into taco ... taco below is the grouping operation. bank is the key in the instance below 
                    // how many items are grouped using that key.
                    group mill by mill.Bank into taco
                    select new { Bank = taco.Key, Count = taco.Count() };

                // foreach (var taco in grouped){
                //         Console.WriteLine($"{taco.Bank} - {taco.Count}");

                //         foreach (var cust in taco.Count){
                //             Console.WriteLine($"  {cust.Name}");
                //         }
                // } 
// the two below statments are exquivilent to each other .... 
                //grouping customers
                // var grouped = from cust in customers 
    
                //     group cust by cust.Bank into potato
                //     select new { Bank = potato.Key, Count = potato.Count() };

                var grouped2 = customers.Where(char2 => char2.Balance >= 1000000)
                                        . GroupBy(d => d.Bank);
// /...........................................................

                foreach(var potato in grouped2){
                    Console.WriteLine($"{potato.Key} {potato.Count()}");
                    
                    foreach(var customer in potato){
                        Console.WriteLine($"{customer.Name} {customer.Balance}");
                        }
                }


                // foreach (var potato in grouped){
                //         Console.WriteLine($"{potato.Bank} - {potato.Count}");

                //         foreach (var cust in potato.Customers){
                //             Console.WriteLine($"  {cust.Name}");
                //         }
                // } 




            /* 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */
        }
    }
}
