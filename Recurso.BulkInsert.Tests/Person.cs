using System.Collections.Generic;

namespace Recurso.BulkInsert.Tests
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public static List<Person> GetTestList()
        {
            return new List<Person>()
            {
                new Person
                {
                    Name="John",
                    Surname="Smith" },
                new Person
                {
                    Name="Keegan",
                    Surname="Smith"
                },
                new Person
                {
                    Name="Kelly",
                    Surname="Smith"
                }
            };
        }
    }

}
