
class Program
{
    static void Main()
    {
        // string filePath = "../../../Input.txt";
        // string[] input = File.ReadAllLines(filePath);

        // int[ , ] input = { { 7, 9}, { 15, 40 }, { 30, 200 } };

        //Time:        56     97     78     75
        //Distance:   546   1927   1131   1139
        int[ , ] input = { { 56, 546}, { 97, 1927 }, { 78, 1131 }, { 75, 1139 } };

        int output = 1;

        for (int i = 0; i < input.GetLength(0); i++)
        {
            int win = 0;
            for (int hold = 1; hold < input[i,0]; hold++)
            {
                if ((input[i,0] - hold) * hold > input[i,1]){
                    win++;
                }
            }
            output *= win;
        }
        Console.WriteLine(output);
    }
}
