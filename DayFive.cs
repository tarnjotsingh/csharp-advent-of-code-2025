using System.Text.RegularExpressions;

namespace AdventOfCode;

public class DayFive() {

    string[] ReadInput(string filePath) {
        string fileText = File.ReadAllText(filePath);
        string[] linesArray = fileText.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.TrimEntries
        );
        return linesArray;
    }

    bool TestInRange(string testVal, string testRange) {
        long toCheck = Int64.Parse(testVal);

        string[] split = testRange.Split('-');
        long lower = Int64.Parse(split[0]);
        long higher = Int64.Parse(split[1]);

        return toCheck >= lower && toCheck <= higher;
    }

    int CountIDs(string[] testRanges) {
        List<string> newRanges = [];
        foreach(string testRange in testRanges) {
            // Scan over all ranges to see if there's an overlap.
            foreach(string scan in testRanges) {
                string[] scanSplit = scan.Split('-');
                long scanLower = Int64.Parse(scanSplit[0]);
                long scanHigher = Int64.Parse(scanSplit[1]);

                bool inRange = TestInRange(scanLower.ToString(), testRange);
                if(!scan.Equals(testRange) && inRange) {
                    Console.Write(scan + " ");
                    Console.WriteLine(testRange);
                }
                else {
                    newRanges.Add(testRange);
                }
            }

        }

        return 0;
    }


    // Determine which ingredients are FRESH or SPOILED
    // Top portion of the input are ranges
    // Split by a single blank line
    // Bottom portion are the list of available ingredient IDs
    //
    // Idea is that while processing an ingredient ID, if it falls within one of the ranges
    // the ingredient is considered to be FRESH, otherwise SPOILED.
    public void Run() {
        string[] inputs = ReadInput("inputs/dayfive/testinputs.txt");

        // Use regex to cleanly filter out the values from the input.
        var rangesRegex = new Regex(@"^(\d+)-(\d+)$");
        var valueRegex = new Regex(@"^(\d+)$");
        string[] ranges = inputs.Where(s => rangesRegex.IsMatch(s)).ToArray();
        string[] values = inputs.Where(s => valueRegex.IsMatch(s)).ToArray();

        int result = CountIDs(ranges);
        // Console.Write(result);
    }

    static void Main() {
        DayFive dayFive = new DayFive();
        dayFive.Run();
    }
}