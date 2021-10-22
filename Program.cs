using System;
using System.Linq;
using UsingLinq.Models;
using static System.Console;

namespace UsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.PersonList();

            // x equals person. It just doesn't repeat itself like the foreach. However x can be any other value ex:. "K" , "value" , "Nothing" 
            //Order by FirstName
            person = person.OrderBy(x=> x.FirstName).ToList();

            WriteLine("Order by FirstName");
            foreach (var p in person)
            {
                WriteLine($"{p.FirstName} | {p.LastName} | {p.FullName} | {p.Age}");
            }

            WriteLine("*************************************");

            //Order by FirstName and then by age desc
            person = person.OrderBy(x => x.FirstName).ThenByDescending(x=>x.Age).ToList();

            WriteLine("Order by FirstName and then by age desc");
            foreach (var p in person)
            {
                WriteLine($"{p.FirstName} | {p.LastName} | {p.FullName} | {p.Age}");
            }

            WriteLine("*************************************");

            //Filter list to a smaller group where age above 25 yo
            person = person.Where(y => y.Age > 25).ToList();

            WriteLine("Filter list to a smaller group where age above 25 yo");
            foreach (var p in person)
            {
                WriteLine($"{p.FirstName} | {p.LastName} | {p.FullName} | {p.Age}");
            }

            WriteLine("*************************************");

            //Filter list to a smaller group where age above 25 yo and birthday month == 3
            person = person.Where(y => y.Age > 25 && y.Birthday.Month == 03).ToList();

            WriteLine("Filter list to a smaller group where age above 25 yo and birthday month == 3");
            foreach (var p in person)
            {
                WriteLine($"{p.FirstName} | {p.LastName} | {p.FullName} | {p.Age}");
            }

            WriteLine("*************************************");

            //Sum the age of all the people in the list
            int totalAge = person.Sum(k => k.Age);

            WriteLine("Sum the age of all the people in the list");
            WriteLine($"The sum of the age is: {totalAge}");

            WriteLine("*************************************");

            //Sum the age of the people where age is above 20
            int ageOfSome = person.Where(k => k.Age > 20).Sum(k => k.Age);

            WriteLine("Sum the age of the people where age is above 20");
            WriteLine($"The sum of the age is: {ageOfSome}");

            WriteLine("*************************************");

            //Average age
            double averageAge = person.Average(k => k.Age);

            WriteLine("Average age.");
            WriteLine($"The average age is: {averageAge}");

            WriteLine("*************************************");

            //Complex query using from -- Must use group or select at the end
            var names = from not in person where not.Age > 20 && not.Age < 50 select not.FullName;

            WriteLine($"Complex query using from -- Must use group or select at the end");
            foreach (var item in names)
            {
                WriteLine(item);
            }

            WriteLine("*************************************");

            //Complex query using from , ordering by the new key and group by lastname
            var complexQuery = from not in person where not.Age > 20 && not.Age < 70 group not by not.FullName into newList orderby newList.Key select newList.Key;

            WriteLine($"Complex query using from , ordering by the new key and group by lastname");
            foreach (var item in complexQuery)
            {
                WriteLine(item);
            }

            WriteLine("*************************************");

            WriteLine("Recommended website: https://www.tutorialsteacher.com/linq/sample-linq-queries");

            ReadLine();
        }
    }
}
