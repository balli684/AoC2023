using System;
using System.Linq;
using System.Xml;

class Program
{
    static void Main()
    {
        string filePath = "../../../Input.txt";
        string[] input = File.ReadAllLines(filePath);

        // Parse seeds
        // string[] seedsStrings = input[0].Split(':')[1].Trim().Split(' ');

        // Int64[] seeds = Array.ConvertAll(seedsStrings, Int64.Parse);

        long[] seeds = Array.ConvertAll(input[0].Split(':')[1].Trim().Split(' '), long.Parse);

        for (int i = 3; i < input.Length; i++)
        {
            if(input[i] != "")
            {
                Console.WriteLine(input[i]);
            }
        }
            
        
    }
}



