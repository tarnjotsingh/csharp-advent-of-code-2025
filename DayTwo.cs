namespace AdventOfCode;

public class DayTwo()
{
    bool HasRepeatedPattern(long testVal)
    {
        // If the value has an odd number of digits, then it automatically passes.
        string stringVal = testVal.ToString();
        if (stringVal.Length % 2 != 0)
            return false;
        else
        {
            string firstString = stringVal.Substring(0, stringVal.Length / 2);
            string secondString = stringVal.Substring(stringVal.Length / 2);
            return firstString.Equals(secondString);
        }
    }
    // Process full id pair 11111-22222
    List<Int64> CheckInvalidIds(string susId)
    {
        List<Int64> splitIds = susId.Split("-").Select(s => Int64.Parse(s)).ToList();
        List<Int64> invalidIds = [];
        for(long i = splitIds[0]; i <= splitIds[1]; i++)
        {
            if(HasRepeatedPattern(i))
                invalidIds.Add(i);
        }
        return invalidIds;
    }

    string ReadInput(string filePath)
    {
        string fileText = File.ReadAllText(filePath);
        string[] linesArray = fileText.Split(
            new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.RemoveEmptyEntries
        );
        return linesArray[0];
    }

    public void Run()
    {
        string[] inputs = ReadInput("inputs/daytwo/inputs.txt").Split(",");
        List<Int64> idsToTotal = [];

        foreach(string s in inputs)
            idsToTotal.AddRange(CheckInvalidIds(s));

        Int64 result = idsToTotal.Sum();
        Console.WriteLine(result);
    }

    static void Main()
    {
        DayTwo dayTwo = new DayTwo();
        dayTwo.Run();
    }
}