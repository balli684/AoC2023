
class Program
{
    static void Main()
    {
        string filePath = "../../../Input.txt";
        string[] input = File.ReadAllLines(filePath);

        long[] seeds = Array.ConvertAll(input[0].Split(':')[1].Trim().Split(' '), long.Parse);

        List<List<long[]>> maps = [];

        long min = 9223372036854775807;

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

        
        foreach (var seed in seeds)
        {
            var location = seed;
            int mapCounter = 0;
            while (mapCounter < maps.Count)
            {
                int rowCounter = 0;
                
                while (rowCounter < maps[mapCounter].Count)
                {
                    if (location >= maps[mapCounter][rowCounter][1] && location < maps[mapCounter][rowCounter][1] + maps[mapCounter][rowCounter][2])
                    {
                        location = location + maps[mapCounter][rowCounter][0] - maps[mapCounter][rowCounter][1];
                        rowCounter = maps[mapCounter].Count;

                    }
                    else
                    {
                        rowCounter++;
                    }
                }
                mapCounter++;
                
            }
            if (location < min)
            {
                min = location;
            }
        }

        Console.WriteLine(min);

    }
}



