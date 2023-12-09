
class Program
{
    static void Main()
    {

        string filePath = "../../../Input.txt";
        List<string> input = [.. (File.ReadAllLines(filePath))];

        int stepCount = 0;
        int currentStep = 0;
        string location = "AAA";

        while (location != "ZZZ")
        {
            var index = input.FindIndex(str => str.StartsWith(location));
            if (input[0][currentStep] == char.Parse("L"))
            {
                location = input[index].Substring(7,3);
            }
            else 
            {
                location = input[index].Substring(12,3);
            }
            stepCount++;
            currentStep++;
            
            if (currentStep >= input[0].Length)
            {
                currentStep = 0;
            }
        }
        Console.WriteLine(stepCount);
    }
}
