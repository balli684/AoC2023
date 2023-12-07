
class Program
{
    static void Main()
    {
        // string filePath = "../../../Input.txt";
        // string[] input = File.ReadAllLines(filePath);

        // int[ , ] input = { { 7, 9}, { 15, 40 }, { 30, 200 } };

        //Time:        56     97     78     75
        //Distance:   546   1927   1131   1139

        // long time = 71530;
        // long record = 940200;

        long time = 56977875;
        long record = 546192711311139;



        long win = 0;
        for (long hold = 1; hold < time; hold++)
        {
            if ((time - hold) * hold > record){
                win++;
            }
            else
            {
                if (win > 0)
                {
                    hold = time;
                }
            }
        }

        Console.WriteLine(win);
    }
}
