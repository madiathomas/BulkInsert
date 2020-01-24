using Recurso.BulkInsert.Sample.Common;
using System;
using System.Collections.Generic;

namespace Recurso.BulkInsert.Sample.Tests
{
    public class TestHelpers
    {
        public static string[] GetCSVLines()
        {
            return new string[]
            {
                "FirstName,LastName,Gender,Age,Email,Phone,Education,Occupation,Experience,MaritalStatus",
                "James,Chapman,Male,22,j.chapman@randatmail.com,646-3513-39,Master,Electrician,0,Married",
                "Catherine,Perkins,Female,26,c.perkins@randatmail.com,108-1037-92,Lower secondary,Meteorologist,10,Single",
                "Elise,Douglas,Female,19,e.douglas@randatmail.com,702-5289-39,Bachelor,Salesman,0,Married",
                "Brooke,Cameron,Female,29,b.cameron@randatmail.com,731-7073-10,Upper secondary,Lawer,13,Single",
                "Kristian,Hamilton,Male,18,k.hamilton@randatmail.com,149-4683-07,Lower secondary,Aeroplane Pilot,4,Single",
                "Evelyn,Fowler,Female,26,e.fowler@randatmail.com,686-2173-75,Primary,Interior Designer,5,Single",
                "Lydia,Campbell,Female,20,l.campbell@randatmail.com,074-0738-54,Bachelor,Journalist,5,Married"
            };
        }
    }
}
