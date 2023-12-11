
class Program
{
    static void Main()
    {

        string filePath = "../../../Input.txt";
        List<string> input = [.. (File.ReadAllLines(filePath))];

        int output = 0;

        foreach (var line in input)
        {
            List<List<int>> x = [];
            List<int> ints = line
                        .Split(" ")
                        .Select(s => Int32.TryParse(s, out int n) ? n : (int?)null)
                        .Where(n => n.HasValue)
                        .Select(n => n.Value)
                        .ToList();
            
            x.Add(ints);

            while(x[^1].Any(o => o != 0))
            {
                List<int> y = [];
                int i = 0;

                while (i < x[^1].Count - 1)
                {
                    y.Add(x[^1][i+1] - x[^1][i]);
                    i++;
                }
                x.Add(y);
            }

            x.RemoveAll(s => s == null);

            int j = 0;
            while (j < x.Count)
            {
                if (j%2 == 0){
                    output += x[j][0];
                }
                else {
                    output -= x[j][0];
                }
                j++;
            }
        }
        Console.WriteLine(output);
    }
}
