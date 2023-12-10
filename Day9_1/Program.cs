
class Program
{
    static void Main()
    {

        string filePath = "../../../Input.txt";
        List<string> input = [.. (File.ReadAllLines(filePath))];

        int output = 0;

        foreach (var line in input)
        {
            // Console.WriteLine(line);
            List<List<int>> x = [];
            List<int> ints = line
                        .Split(" ")
                        .Select(s => Int32.TryParse(s, out int n) ? n : (int?)null)
                        .Where(n => n.HasValue)
                        .Select(n => n.Value)
                        .ToList();
            
            x.Add(ints);
            

            while(Enumerable.Sum(x[^1]) != 0)
            {
                List<int> y = [];
                int i = 0;

                while (i < x[^1].Count - 1)
                {
                    // y.Add(Math.Abs(x[^1][i] - x[^1][i+1]));
                    y.Add(x[^1][i+1] - x[^1][i]);
                    i++;
                }
                x.Add(y);
            }

            x.RemoveAll(s => s == null);

            foreach(var a in x)
            {
                foreach(var b in a)
                {
                    Console.Write("{0} ",b);
                }
                Console.WriteLine();
                
            }
            Console.ReadLine();

            foreach(var z in x)
            {
                if (z.Count > 0)
                {
                    output += z[^1];
                }
                // Console.WriteLine(z[^1]);
                // Console.WriteLine(output);
            }

        }
        Console.WriteLine(output);
    }
}
