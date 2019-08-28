﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzCh15
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=|DataDirectory|\\ContactDB.mdf";
            ContactDB context = new ContactDB(connectionString);
            var peopleData =
                from person in context.People
                select new { person.Name, person.Company };

            foreach (var person in peopleData)
                Console.WriteLine("{0} works at {1}", person.Name, person.Company);
        }
    }
}
