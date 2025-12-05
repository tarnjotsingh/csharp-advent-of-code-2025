namespace AdventOfCode;

public class DayTwo() {
    bool HasRepeatedPattern(long testVal){
        string stringVal = testVal.ToString();

        if (stringVal.Length == 1)
            return false;
        // Iterate over to see if a given pattern matches?
        for(int i = 1; i <= stringVal.Length / 2; i++){
            string subStr = stringVal.Substring(0, i);

            // Build a potential pattern and test it against the actual value.
            // If val has length 6 and current substring is length 2. Do 6 / 2 which is 3. Repeat string 3 times to build new string.
            string testStr = "";
            int size = stringVal.Length / subStr.Length;
            for (int j = 0; j <= size -1; j++)
                testStr += subStr;

            if(testStr.Equals(stringVal))
                return true;
        }
        return false;
    }

    List<Int64> CheckInvalidIds(string susId){
        List<Int64> splitIds = susId.Split("-").Select(s => Int64.Parse(s)).ToList();
        List<Int64> invalidIds = [];
        for(long i = splitIds[0]; i <= splitIds[1]; i++)
            if(HasRepeatedPattern(i))
                invalidIds.Add(i);

        return invalidIds;
    }

    string ReadInput(string filePath) {
        string fileText = File.ReadAllText(filePath);
        string[] linesArray = fileText.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.RemoveEmptyEntries
        );
        return linesArray[0];
    }

    public void Run() {
        string[] inputs = ReadInput("inputs/daytwo/inputs.txt").Split(",");
        List<Int64> idsToTotal = [];

        foreach(string s in inputs)
            idsToTotal.AddRange(CheckInvalidIds(s));

        Int64 result = idsToTotal.Sum();
        Console.WriteLine(result);
    }

    static void Main() {
        DayTwo dayTwo = new DayTwo();
        dayTwo.Run();
    }
}