
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        string filePath = "../../../ExampleInput.txt";
        string[] input = File.ReadAllLines(filePath);

        long[] temp = Array.ConvertAll(input[0].Split(':')[1].Trim().Split(' '), long.Parse);

        long[,] seeds = new long[temp.Length / 2, 2];
        for (int x = 0; x < temp.Length; x++){
            if (x%2 == 0)
            {
                seeds[x/2,0] = temp[x];
            }
            else
            {
                seeds[x/2,1] = temp[x]; 
            }
        }

        // for (int i = 0; i < seeds.GetLength(0); i++)
        // {
        //     for (int j = 0; j < seeds.GetLength(1); j++)
        //     {
        //         Console.Write(seeds[i,j]);
        //         Console.Write(" ");
        //     }
        //     Console.WriteLine();
        // }


        List<List<long[]>> maps = [];

        // long min = 9223372036854775807;

        int i = 3;
        do
        {
            
            List<long[]> map = [];

            while(i < input.Length && input[i] != "")
            {
                long[] row = Array.ConvertAll(input[i].Split(' '), long.Parse);
                map.Add(row);
                i++;
            }
            maps.Add(map);
            i += 2;
        } while (i < input.Length);

        var sortedLocations = maps[^1].OrderBy(arr => arr[0]).ToList();
        bool found = false;
        foreach (var locationLine in sortedLocations)
        {
            long location = locationLine[0];
            Console.WriteLine("Start Location {0}",location);
            while (!found && location < locationLine[0] + locationLine[2])
            {
                int mapCounter = 2;
                while (mapCounter < maps.Count)
                {
                    int rowCounter = 0;
                    
                    while (rowCounter < maps[^mapCounter].Count)
                    {
                        if (location >= maps[^mapCounter][rowCounter][0] && location < maps[^mapCounter][rowCounter][0] + maps[^mapCounter][rowCounter][2])
                        {
                            location = location + maps[^mapCounter][rowCounter][1] - maps[^mapCounter][rowCounter][0];
                            rowCounter = maps[^mapCounter].Count;
                            
                        }
                        else
                        {
                            rowCounter++;
                        }
                    }
                    mapCounter++;
                    Console.WriteLine("Mapnr {0}, Location {1}",maps.Count - mapCounter,location);
                }


                location++;
            }
        }
        
        



        // foreach (var row in maps[^y])
        // {
        //     foreach (var x in row)
        //     {
        //         Console.Write("{0} ", x);
        //     }
        //     Console.WriteLine();
        // }

        // for (int x = 0; x < seeds.GetLength(0); x++)
        // {
        //     var seed = seeds[x,0];
        //     while (seed < seeds[x,0] + seeds[x,1])
        //     {
        //         //Console.WriteLine("Seed: {0}", seed);
        //         var location = seed;
        //         int mapCounter = 0;
        //         while (mapCounter < maps.Count)
        //         {
        //             int rowCounter = 0;
                    
        //             while (rowCounter < maps[mapCounter].Count)
        //             {
        //                 if (location >= maps[mapCounter][rowCounter][1] && location < maps[mapCounter][rowCounter][1] + maps[mapCounter][rowCounter][2])
        //                 {
        //                     location = location + maps[mapCounter][rowCounter][0] - maps[mapCounter][rowCounter][1];
        //                     rowCounter = maps[mapCounter].Count;
                            
        //                 }
        //                 else
        //                 {
        //                     rowCounter++;
        //                 }
        //             }
        //             mapCounter++;
        //             //Console.WriteLine("Mapnr {0}, Location {1}",mapCounter,location);
        //         }
        //         if (location < min)
        //         {
        //             min = location;
        //         }
        //         //Console.WriteLine("Location: {0}", location);
        //         seed++;
        //     }
        // }

        // Console.WriteLine(min);

    }
}



