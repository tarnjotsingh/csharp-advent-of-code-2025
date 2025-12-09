namespace AdventOfCode;

public class DayThree() {

    string[] ReadInput(string filePath) {
        string fileText = File.ReadAllText(filePath);
        string[] linesArray = fileText.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.RemoveEmptyEntries
        );
        return linesArray;
    }

    long ProcessString(string input) {
        string joltage = "";
        int largestNum = 0, numIndex = 0, currentLrgIndex = 0;

        // Need to run the main loop 12 times
        // Need to limit which numbers can bee looped over based on how many of the 12 digits have been selected yet
        for (int j = 11; j >= 0; j--) {
            for(int i = numIndex; i < input.Length - j; i++) {
                int v = input[i] - '0';
                if (v > largestNum) {
                    largestNum = v;
                    currentLrgIndex = i;
                }
            }
            joltage += largestNum;
            numIndex = currentLrgIndex + 1;
            largestNum = 0;
        }
        return Int64.Parse(joltage);
    }

    public void Run() {
        string[] inputs = ReadInput("inputs/daythree/inputs.txt");
        List<long> joltages = [];
        foreach (string s in inputs)
            joltages.Add(ProcessString(s));

        long total = joltages.Sum();
        Console.WriteLine(total);
    }

    static void Main() {
        DayThree dayThree = new DayThree();
        dayThree.Run();
    }
}