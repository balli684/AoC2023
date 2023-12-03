using System;
using System.Collections.Generic;
using System.Data;


class Pair(string color, int count)
{
    public string Color { get; set; } = color;
    public int Count { get; set; } = count;
}

class Program
{
    static void Main()
    {
        string filePath = @"../../../Input.txt";

        try
        {
            int count = 0;
            int game = 1;
            using StreamReader sr = new(filePath);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Console.WriteLine(line);
                bool possible = true;
                var gameStrings = line.Split(':');
                // Console.WriteLine(gameStrings[1]);
                var rounds = gameStrings[1].Trim().Split(';');
                foreach (var round in rounds)
                {
                    var pairs = round.Trim().Split(',');
                    foreach (var pair in pairs)
                    {
                        // Console.WriteLine(pair);
                        var splitPair = pair.Trim().Split(' ');
                        Pair p = new(splitPair[1],int.Parse(splitPair[0]));
                        if ((p.Color == "red") && (p.Count > 12))
                        {
                            possible = false;
                        }
                        if ((p.Color == "green") && (p.Count > 13))
                        {
                            possible = false;
                        }
                        if ((p.Color == "blue") && (p.Count > 14))
                        {
                            possible = false;
                        }
                    }
                }
                if (possible)
                {
                    count += game;
                }
                game++;
               
            }
            Console.WriteLine(count);
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }


        
    }
}
