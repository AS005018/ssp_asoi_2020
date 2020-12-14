using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab2_1SSP
{
    class PasteException : Exception
    {
        public PasteException(string message) : base(message) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Task();
        }
        static void Task()
        {
            string line = "";
            while (true)
            {
                Console.Write("~ ");
                line = Console.ReadLine();
                if (line.Equals("help paste") || line.Equals("help"))
                {
                    ShowCommand();
                }
                else if (line.Equals("clear"))
                {
                    Console.Clear();
                }
                else if (!line.Equals("quit"))
                {
                    string[] array = line.Split(' ');
                    if (array[0] == "")
                    {
                        continue;
                    }
                    List<string> listTextDocuments = new List<string>();
                    Dictionary<int, List<string>> dictionaryOutput = new Dictionary<int, List<string>>();
                    SelectNameTextDocuments(ref listTextDocuments, array);
                    List<Dictionary<int, List<string>>> listDictionary = GetListDictionary(listTextDocuments);
                    try
                    {
                        if (!CheckPaste(array))
                        {
                            throw new PasteException("Incorrect syntax");
                        }
                        if (listDictionary.Count == 0)
                        {
                            throw new PasteException("TXT-File(s) not found");
                        }
                        if (CheckPaste(array))
                        {
                            dictionaryOutput = OptionsS(listDictionary, array);
                            dictionaryOutput = OptionsD(dictionaryOutput, array);
                        }
                                              
                        OutputDictionary(ref dictionaryOutput);
                    }
                    catch (PasteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }                
                else break;
            }
        }
        static void ShowCommand()
        {
            Console.WriteLine("paste [options] [file1 file2 ...]");
            Console.WriteLine("\n[options]:\n\t-s -> Changes the position of rows with columns" +
                "\n\t-d -> delimiter Change the delimiter to the specified one (TAB by default)");
        }
        static void SelectNameTextDocuments(ref List<string> listTextDocuments, params string[] array)
        {
            foreach (var item in array)
            {
                if (item.Contains(".txt"))
                {
                    listTextDocuments.Add(item);
                }
            }
        }
        static bool CheckPaste(params string[] array)
        {
            if (array.Length > 0)
            {
                if (array[0] == "paste")
                {
                    return true;
                }
            }
            return false;
        }
        static bool CheckOptionsS(params string[] array)
        {
            if (array.Length > 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (array[i].Contains("-s"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static Dictionary<int, List<string>> OptionsS(List<Dictionary<int, List<string>>> listDictionary, params string[] array)
        {
            Dictionary<int, List<string>> tempDictionary = new Dictionary<int, List<string>>();
            List<string> tempList = new List<string>();
            if (CheckOptionsS(array))
            {
                int count = 0;
                for (int i = 0; i < listDictionary.Count; i++)
                {
                    tempList = new List<string>();
                    for (int list = 0; list < listDictionary.Max(z => z.Count); list++)
                    {
                        try
                        {
                            if (list < listDictionary[i].Count)
                            {
                                string outputLine = "";
                                foreach (var item in listDictionary[i][list].ToList())
                                {
                                    outputLine += item +" ";
                                }
                                tempList.Add(outputLine);
                            }
                            else
                                throw new Exception();
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    tempDictionary.Add(count++, tempList);
                }
                return tempDictionary;
            }
            else
            {
                int count = 0;
                for (int list = 0; list < listDictionary.Max(z => z.Count); list++)
                {
                    tempList = new List<string>();
                    for (int i = 0; i < listDictionary.Count; i++)
                    {

                        try
                        {
                            if (list < listDictionary[i].Count)
                            {
                                string outputLine = "";
                                foreach (var item in listDictionary[i][list].ToList())
                                {
                                    outputLine += item + " ";
                                }
                                tempList.Add(outputLine);

                            }
                            else
                                throw new Exception();
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    tempDictionary.Add(count++, tempList);
                }
                return tempDictionary;
            }

        }
        static bool CheckOptionsD(params string[] array)
        {
            if (array.Length > 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (array[i].Contains("-d"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static Dictionary<int, List<string>> OptionsD(Dictionary<int, List<string>> listDictionary, params string[] array)
        {
            Dictionary<int, List<string>> tempDictionary = new Dictionary<int, List<string>>();
            if (CheckOptionsD(array))
            {
                int index = -1;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Contains("-d"))
                    {
                        index = ++i;
                        continue;
                    }
                }
                if (array[index].Contains(".txt"))
                {
                    for (int i = 0; i < listDictionary.Count; i++)
                    {
                        for (int j = 0; j < listDictionary[i].Count; j++)
                        {
                            listDictionary[i][j] += "\t";
                        }
                    }
                }
                else if (Regex.IsMatch(array[index], @"[\a\b\f\n\r\t\v\\""]"))
                {
                    int count = 0;
                    Dictionary<string, string> dictionaryEscapes = new Dictionary<string, string>()
                    {
                        {"\\a", "\a" },
                        {"\\b", "\b" },
                        {"\\f", "\f" },
                        {"\\n", "\n" },
                        {"\\r", "\r" },
                        {"\\t", "\t" },
                        {"\\v", "\v" },
                    };
                    List<string> number = new List<string>();
                    foreach (var key in dictionaryEscapes.Keys)
                    {
                        if (array[index].Contains(key))
                        {
                            number.Add(key);
                        }
                    }
                    for (int i = 0; i < listDictionary.Count; i++)
                    {
                        for (int j = 0; j < listDictionary[i].Count; j++)
                        {
                            if (count >= number.Count)
                                count = 0;
                            listDictionary[i][j] = listDictionary[i][j].Remove(listDictionary[i][j].Length - 1, 1) + dictionaryEscapes[number[count++]];
                        }
                    }
                }
                else if (Regex.IsMatch(array[index], @"\W"))
                {
                    int count = 0;
                    List<char> symbol = array[index].ToList<char>();
                    for (int i = 0; i < listDictionary.Count; i++)
                    {
                        for (int j = 0; j < listDictionary[i].Count; j++)
                        {
                            if (count >= symbol.Count)
                                count = 0;
                            listDictionary[i][j] = listDictionary[i][j].Remove(listDictionary[i][j].Length - 1, 1) + symbol[count++];
                        }
                    }
                }
            }
            return listDictionary;
        }
        static List<Dictionary<int, List<string>>> GetListDictionary(List<string> names)
        {
            List<Dictionary<int, List<string>>> listDictionary = new List<Dictionary<int, List<string>>>();
            try
            {
                Dictionary<int, List<string>> dictionary;
                foreach (var file in names)
                {
                    using (StreamReader stream = new StreamReader(file))
                    {
                        dictionary = new Dictionary<int, List<string>>();
                        int count = 0;
                        while (!stream.EndOfStream)
                        {
                            string line = stream.ReadLine();
                            dictionary.Add(count++, line.Split(' ').ToList<string>());
                        }
                        listDictionary.Add(dictionary);
                    }
                }
                return listDictionary;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return listDictionary;
            }

        }
        static void OutputDictionary(ref Dictionary<int, List<string>> dictionary)
        {
            for (int i = 0; i < dictionary.Count; i++)
            {
                for (int j = 0; j < dictionary[i].Count; j++)
                {
                    Console.Write(dictionary[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
