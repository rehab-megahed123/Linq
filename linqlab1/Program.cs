using System.ComponentModel;
using System.Runtime.CompilerServices;
using L2O___D09;

namespace linqlab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static void PrintFunction<T>(IEnumerable<T> list)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }



                Console.WriteLine(" Restriction Operators ");
                Console.WriteLine("Products Out Of Stock");
                var result = ListGenerators.ProductList.Where(a => a.UnitsInStock == 0);
                PrintFunction(result);

                Console.WriteLine("products that are in stock and cost more than 3.00 per unit.");
                var result2 = ListGenerators.ProductList.Where(a => a.UnitsInStock != 0 && a.UnitPrice > 3);
                PrintFunction(result2);

                Console.WriteLine("s digits whose name is shorter than their value");
                string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight" ,
                 "nine" };

                var result3 = Arr.Where((a, index) => index > a.Length).ToList();
                PrintFunction(result3);

            Console.WriteLine("  Element Operators");
            Console.WriteLine("  first Product out of Stock  ");
            var result4 = ListGenerators.ProductList.First(a => a.UnitsInStock == 0);
            Console.WriteLine(result4);

            Console.WriteLine("the first product whose Price > 1000, unless there is no match, in which case nullis returned." );
            var result5 = ListGenerators.ProductList.FirstOrDefault(a => a.UnitPrice > 1000);
            Console.WriteLine(result5);
            Console.WriteLine(" the second number greater than 5 ");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result6 = Arr2.Where(a => a > 5).Skip(1).First();
            Console.WriteLine(result6);
            Console.WriteLine("----------------------");
            Console.WriteLine("Set Operators");
            Console.WriteLine(" the unique Category names from Product List ");
            var result7 = ListGenerators.ProductList.DistinctBy(a => a.Category);
            PrintFunction(result7);
            Console.WriteLine(". Produce a Sequence containing the unique first letter from both product and customer nnames. ");
            var DistnctProductName = ListGenerators.ProductList.Select(a => a.ProductName).Select(a => a.First());
            var DistnctCustomerName = ListGenerators.CustomerList.Select(a => a.CustomerID).Select(a => a.First());
            var result8 = DistnctProductName.Union(DistnctCustomerName);
            PrintFunction(result8);
            Console.WriteLine(" one sequence that contains the common first letter from both product and ncustomer names.");
            var result9 = DistnctCustomerName.Intersect(DistnctProductName);
            PrintFunction(result9);
            Console.WriteLine(" one sequence that contains the first letters of product names that are not also first letters of customer names.");
            var result10 = DistnctProductName.Except(DistnctCustomerName);
            PrintFunction(result10);
            Console.WriteLine("one sequence that contains the last Three Characters in each names of all customers and products including any duplicates ");
            var Last3ProductName = ListGenerators.ProductList.Select(a => a.ProductName).Select(a => a.TakeLast(3).ToList());

            var Last3CustomerName = ListGenerators.CustomerList.Select(a => a.CustomerID).Select(a => a.TakeLast(3).ToList());
            var result11 = Last3CustomerName.Concat(Last3ProductName).ToList();
            foreach(var item in result11)
            {
                foreach (var item1 in item)
                {
                    Console.Write(item1);
                }
            }
            Console.WriteLine("Aggregate Operators ");
            Console.WriteLine(" get the number of odd numbers in the array ");
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result12 = Arr3.Count(a => a % 2 != 0);
            Console.WriteLine(result12);

            Console.WriteLine(" a list of customers and how many orders each has. ");
            var result13 = ListGenerators.CustomerList.Select((Customer, CountOfOrders) => new { Customer = Customer.CustomerID, CountOfOrders = Customer.Orders.Count() });
            PrintFunction(result13);
            Console.WriteLine(" a list of categories and how many products each has ");
            var result14 = ListGenerators.ProductList.Select((Category, CountOfProducts) => new { Category = Category.Category, CountOfProducts = Category.ProductName.Count() });
            PrintFunction(result14);
            Console.WriteLine(" total of the numbers in an array");
            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result15 = Arr4.Sum();
            Console.WriteLine(result15);

            Console.WriteLine("  the total number of characters of all words in dictionary_");
            string filePath = "C:\\Users\\Admin\\Desktop\\EntityFrameWork\\EntityFramework\\linqlab1\\dictionary_english.txt";
            string[] dictionaryArray = File.ReadAllLines(filePath);
            var result16 = dictionaryArray.Select(a => a.Count()).Sum();
            Console.WriteLine(result16);
            Console.WriteLine(" the total units in stock for each product category. ");
            var result17 = ListGenerators.ProductList.GroupBy(x => x.Category).Select((m ,n)=> new { Category = m.Key, Count = m.Sum(n => n.UnitsInStock) });
            PrintFunction(result17);

            Console.WriteLine(" Get the length of the shortest word in dictionary_english.txt");
            var result18 = dictionaryArray.Min(a => a.Length);
            Console.WriteLine(result18);
            Console.WriteLine(" Get the average length of the words in dictionary_english.txt");
            var result19 = dictionaryArray.Average(a => a.Length);
            Console.WriteLine(result19);
            Console.WriteLine(" Sort a list of products by name ");
            var result20 = ListGenerators.ProductList.OrderBy(a => a.ProductName);
            PrintFunction(result20);
            Console.WriteLine("e sort of the words in an array");
            string[] Arr5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var result21 = Arr5.Order();
            PrintFunction(result21);
            Console.WriteLine(" Sort a list of products by units in stock from highest to lowest.");
            var result22 = ListGenerators.ProductList.OrderByDescending(a => a.UnitsInStock);
            PrintFunction(result22);
            Console.WriteLine(" Sort a list of digits, first by length of their name, and then alphabetically by the name itself. ");
            string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
"nine" };
            var result23 = Arr6.OrderBy(a => a.Length).ThenBy(a=>a);
            PrintFunction(result23);
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Console.WriteLine(" Sort first by word length and then by a case-insensitive sort of the words in an array.");
            var result24 = words.OrderBy(a => a.Length).ThenBy(a => a, StringComparer.OrdinalIgnoreCase);
            PrintFunction(result24);
            Console.WriteLine(" Get the cheapest price among each category's products ");
            var result25 = ListGenerators.ProductList.GroupBy(a => a.Category).Select((a, b) => new { Category = a.Key, Cheapest = a.Min(b => b.UnitPrice)});
            PrintFunction(result25);
            Console.WriteLine(" Get the products with the cheapest price in each category (Use Let)");
            var result26 = from product in ListGenerators.ProductList
                           group product by product.Category into g
                           let cheapestPrice = g.OrderBy(p => p.UnitPrice).First()
                           select new { Category = g.Key, Cheapest = cheapestPrice };
            PrintFunction(result26);
            Console.WriteLine(". Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt ninto Array of String First).");
            var result27 = dictionaryArray.Max(a => a.Length);
            Console.WriteLine(result27);
            Console.WriteLine(". Get the most expensive price among each category's products. ");
            var result28 = ListGenerators.ProductList.GroupBy(a => a.Category).Select((a, b) => new { Category = a.Key, Maximum = a.Max(b => b.UnitPrice) });
            PrintFunction(result28);
            Console.WriteLine(" Get the products with the most expensive price in each category. ");
            var result29 = ListGenerators.ProductList.GroupBy(a => a.Category).Select((a, b) => new { Category = a.Key, Maximum = a.OrderBy(b => b.UnitPrice).Last() });
            PrintFunction(result29);
            Console.WriteLine(" Get the average length of the words in dictionary_english.txt (Read \r\ndictionary_english.txt into Array of String First). ");
            var result30 = dictionaryArray.Average(a => a.Length);
            Console.WriteLine(result30);
            Console.WriteLine(" Get the average price of each category's products");
            var result31 = ListGenerators.ProductList.GroupBy(a => a.Category).Select((a, b) => new { Category = a.Key, Average = a.Average(b => b.UnitPrice) });
            PrintFunction(result31);
            Console.WriteLine(". Sort a list of products, first by category, and then by unit price, from highest to lowest. ");
            var result32 = ListGenerators.ProductList.OrderBy(a => a.Category).ThenByDescending(b => b.UnitPrice);
            PrintFunction(result32);
            Console.WriteLine(" Sort first by word length and then by a case-insensitive descending sort of the words in an array. ");
            string[] Arr8 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var result33 = Arr8.OrderBy(a => a.Length).ThenByDescending( b=>b,StringComparer.OrdinalIgnoreCase);
            PrintFunction(result33);
            Console.WriteLine(". Create a list of all digits in the array whose second letter is 'i' that is reversed from the \r\norder in the original array. ");
            string[] Arr9 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
"nine" };
            var result34 = Arr9.Reverse().Where(a => a[1] == 'i').Select(b=>b);
            PrintFunction(result34);
            Console.WriteLine(" Get the first 3 orders from customers in Washington ");
            var result35 = ListGenerators.CustomerList.Where(a => a.Country == "Washington").SelectMany(a=>a.Orders).Take(3);
            foreach(var item in result35)
            {
                Console.WriteLine($"Id:{item.OrderID}-OrderDate:{item.OrderDate}-Total:{item.Total}");
               
            }
            Console.WriteLine("Get all but the first 2 orders from customers in Washington. ");
            var result36 = ListGenerators.CustomerList.Where(a => a.Country == "Washington").SelectMany(a => a.Orders).Skip(2);
            foreach (var item in result36)
            {
                Console.WriteLine($"Id:{item.OrderID}-OrderDate:{item.OrderDate}-Total:{item.Total}");

            }
            Console.WriteLine("Return elements starting from the beginning of the array until a number is hit that is \r\nless than its position in the array. ");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result37 = numbers.TakeWhile((a,b)=>a>b);
            PrintFunction(result37);
            Console.WriteLine(". Get the elements of the array starting from the first element divisible by 3");
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result38 = numbers2.SkipWhile(a => a % 3 != 0);
            PrintFunction(result38);
            Console.WriteLine(" Get the elements of the array starting from the first element less than its position. ");
            var result39 = numbers.SkipWhile((a, b) => a > b);
            PrintFunction(result39);
            Console.WriteLine("Return a sequence of just the names of a list of products. ");
            var result40 = ListGenerators.ProductList.Select(a => a.ProductName);
            PrintFunction(result40);
            Console.WriteLine(" Produce a sequence of the uppercase and lowercase versions of each word in the \r\noriginal array (Anonymous Types). ");
            string[] words99 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var result41 = words99.Select(a => new { Upper = a.ToUpper(), Lower = a.ToLower() });
            PrintFunction(result41);
            Console.WriteLine(" Produce a sequence containing some properties of Products, including UnitPrice which \r\nis renamed to Price in the resulting type.");
            var result42 = ListGenerators.ProductList.Select((a => new { Price = a.UnitPrice }));
            PrintFunction(result42);
            Console.WriteLine(". Determine if the value of ints in an array match their position in the array. ");
            int[] Arr10 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result43 = Arr10.Select((a, b) => new { value = a, result = a == b });
            foreach(var item in result43)
            {
                Console.WriteLine($"{item.value}:{item.result}");
            }
            Console.WriteLine(". Returns all pairs of numbers from both arrays such that the number from numbersA is \r\nless than the number from numbersB. ");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var result44= from a in numbersA
                                       from b in numbersB
                                       where a < b
                                       select new { A = a, B = b };

            
            foreach (var pair in result44)
            {
                Console.WriteLine($"{pair.A} is less than {pair.B}");
            }
            Console.WriteLine("Select all orders where the order total is less than 500.00. ");
            var result45 = ListGenerators.CustomerList.SelectMany(a => a.Orders).Where(a=>a.Total<500);
            PrintFunction(result45);
            Console.WriteLine(" Select all orders where the order was made in 1998 or later. ");
            var result46 = ListGenerators.CustomerList.SelectMany(a => a.Orders).Where(a => a.OrderDate.Year >= 1998);
            PrintFunction(result46);
            Console.WriteLine(" Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into \r\nArray of String First) contain the substring 'ei'");
            var result47 = dictionaryArray.Any(a => a.Contains("ei"));
            Console.WriteLine(result47);
            Console.WriteLine(" Return a grouped a list of products only for categories that have at least one product \r\nthat is out of stock. ");
            var res48 = dictionaryArray.Any(a => a.Contains("ei"));
            Console.WriteLine(res48);
            Console.WriteLine(" Return a grouped a list of products only for categories that have all of their products in \r\nstock. \r\n");
            var res49 = ListGenerators.ProductList.GroupBy(a => a.Category).Where(a => a.Any(a => a.UnitsInStock == 0));
            foreach (var item in res49)
            {
                PrintFunction(item);
            }
            Console.WriteLine(". Use group by to partition a list of numbers by their remainder when divided by 5 ");
            List<int> numbers5 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var res55 = numbers5.GroupBy(a => a % 5).ToList();
            foreach (var item in res55)
            {
                Console.WriteLine($"\n{item.Key}\n");
                PrintFunction(item);
            }
            Console.WriteLine("Uses group by to partition a list of words by their first letter. \r\nUse dictionary_english.txt for Input ");
            var res56 = dictionaryArray.GroupBy(a => a[0]).ToList();
            foreach (var item in res56)
            {
                Console.WriteLine(string.Join(", ", item));
            }
            Console.WriteLine("Use Group By with a custom comparer that matches words that are consists of the same \r\nCharacters Together ");
            string[] Arr30 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var res57 = Arr30.Select(a => a.Trim()).GroupBy(a => new string(a.OrderBy(a => a).ToArray()));
            foreach (var item in res57)
            {
                PrintFunction(item);
            }





















        }
    }
    }

