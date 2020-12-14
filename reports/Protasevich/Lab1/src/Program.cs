using System;
using System.Collections.Generic;

namespace LAB1_SSP
{
    class Program
    {
        static int x, y;
        static void Main(string[] args)
        {
            Console.Write("Result of Task 1:\n");
            Task1(args);

            Console.Write("Task 2:\n");
            Console.Write("Enter count lines ");
            int.TryParse(Console.ReadLine(), out x);
            Console.Write("Enter count columns ");
            int.TryParse(Console.ReadLine(), out y);
            double[,] array = new double[x, y];
            Console.WriteLine($"Enter matrix {x}x{y}");
            try
            {
                int count = 0;
                string enterString = Console.ReadLine();
                string[] arrayString = enterString.Split(new char[] { ' ' });
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        array[i, j] = Convert.ToDouble(arrayString[count]);
                        count++;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("invalid format");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("index out of range");
            }
            randomPerturbations(ref array);
            Console.WriteLine();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Result of Task 3:\n");
            String a;
            do
            {
                Console.Write("Enter value\n");
                a = Console.ReadLine();
                Console.WriteLine($"{a} is Lower - {isAllLowerCase(a)}");
            } while (a != "0");
            Console.ReadKey();
        }
        static void Task1(string[] args)

        {
            
            try
            {
                List<int> array = new List<int>(); ;
                foreach (var item in args)
                {
                    if (int.Parse(item) is int)
                        array.Add(Convert.ToInt32(item));
                    else
                        throw new FormatException("Not all args is int");
                }
                if (array == null)
                    throw new ArgumentNullException("Args Nullable");
                for (int i = 0; i < array.Count - 1; i++)
                {
                    for (int j = i + 1; j < array.Count; j++)
                    {
                        if (array[i] == array[j])
                        {
                            array.RemoveAt(j);
                            array.RemoveAt(i);
                            continue;
                        }
                    }
                    Console.WriteLine(array[i]);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void randomPerturbations(ref double[,] args)
        {
            
            Random r = new Random();
            int count = r.Next(0, args.Length - 1);
            Console.WriteLine();
            Console.WriteLine($"Count random {count}");
            while (count != 0)
            {
                int x1 = r.Next(0, x);
                int y1 = r.Next(0, y);
                int x2 = r.Next(0, x);
                int y2 = r.Next(0, y);
                var buffer = args[x1, y1];
                args[x1, y1] = args[x2, y2];
                args[x2, y2] = buffer;
                count--;
            }
        }
        static bool isAllLowerCase(String cs)
        {
            if (cs == null || cs == "" || cs == " ")
                return false;
            if (cs == cs.ToLower())
                return true;
            return false;
        }
    }
}
