using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowManyDuplicates
{
    class Program
    {

        static void Main(string[] args)
        {
            CountRecords();
        }

        public static void CountRecords()
        {
            List<string> hostDocument = new List<string>();
            string[] documentLines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
           
            foreach (string line in documentLines)
            {
                hostDocument.Add(line.Split(' ')[0]);
            }

            var duplicates = hostDocument.GroupBy(x => x)
                        .Select(s => new { Value = s.Key, Count = s.Count() })
                        .OrderByDescending(x => x.Count);

            foreach (var x in duplicates.OrderBy(x=> x.Value).ThenBy(m => m.Value))
            {
                Console.WriteLine(x.Value + " " + x.Count);
            }
        }
    }
}
