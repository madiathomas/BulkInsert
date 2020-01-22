using System.Collections.Generic;

namespace Recurso.BulkInsert.Tests
{
    public class TestPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public static List<TestPerson> GetTestList()
        {
            return new List<TestPerson>()
            {
                new TestPerson
                {
                    Name="John",
                    Surname="Smith" },
                new TestPerson
                {
                    Name="Keegan",
                    Surname="Smith"
                },
                new TestPerson
                {
                    Name="Kelly",
                    Surname="Smith"
                }
            };
        }
    }

}
