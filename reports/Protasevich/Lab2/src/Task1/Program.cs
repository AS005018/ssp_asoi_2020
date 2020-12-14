using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab2SSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();

            Console.ReadKey();
        }
        static void Task1()
        {
            string path = @"test.txt";
            Dictionary<int, List<string>> array = new Dictionary<int, List<string>>();
            using (StreamReader stream = new StreamReader(path))
            {
                int count = 0;
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    array.Add(count++, line.Split(' ').ToList<string>());
                }
            }
            Random r = new Random();
            List<string> temp = new List<string>();
            for (int i = 0; i < array.Count; i++)
            {
                if (r.Next(0, 2) == 1)
                {
                    temp = array.ElementAt(i).Value;
                    for (int j = 0; j < temp.Count; j++)
                    {
                        int x1 = r.Next(0, temp.Count);
                        int x2 = r.Next(0, temp.Count);
                        string buff = temp[x2];
                        temp[x2] = temp[x1];
                        temp[x1] = buff;
                    }
                    foreach (var item in temp)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
                else
                    continue;
            }
        }
    }
}
