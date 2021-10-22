using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLinq.Models
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - Birthday.Year);
            }
        }

        public Person()
        {

        }

        public static List<Person> PersonList()
        {
            List<Person> person = new List<Person>();

            person.Add(new Person { FirstName = "Tim", LastName = "Corey", Birthday = Convert.ToDateTime("25/02/1970")});
            person.Add(new Person { FirstName = "Joe", LastName = "Smith", Birthday = Convert.ToDateTime("31/03/1980")});
            person.Add(new Person { FirstName = "Sue", LastName = "Storm", Birthday = Convert.ToDateTime("03/01/1964")});
            person.Add(new Person { FirstName = "Sara", LastName = "Jones", Birthday = Convert.ToDateTime("06/03/1996")});
            person.Add(new Person { FirstName = "Jamie", LastName = "Doe", Birthday = Convert.ToDateTime("18/02/2001")});
            person.Add(new Person { FirstName = "Mary", LastName = "Smith", Birthday = Convert.ToDateTime("23/01/1988")});

            return person;
        } 
    }
}
