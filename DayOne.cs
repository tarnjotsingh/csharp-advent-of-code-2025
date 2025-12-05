namespace AdventOfCode;

using System.Collections;

// Program.cs
// The execution starts here without explicit 'Main' method or 'class' definition.


// Dial with number from 0 to 99
// If number goes below 0, then start at 99 backwards
// If number goes above 99, then start from 0 onwards

public class DayOne {
    int RotateDial(int val, string rotate) {
        string turnDir = rotate.Substring(0, 1);
        int turnVal = int.Parse(rotate.Substring(1));

        switch(turnDir) {
            case "L":
                return (val - turnVal) % 100;
            case "R":
                return (val + turnVal) % 100;
            default:
                throw new ArgumentException("Invalid turn value.");
        }
    }

    int ProcessRotations(int startVal, string[] rotations) {
        int lastVal = startVal;
        int zeroCount = 0;
        foreach(string r in rotations){
            lastVal = RotateDial(lastVal, r);
            if(lastVal == 0) zeroCount++;
        }
        return zeroCount;
    }


    string[] ReadInput(string filePath) {
        string fileText = File.ReadAllText(filePath);
        string[] linesArray = fileText.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.RemoveEmptyEntries
        );
        return linesArray;
    }

    public void Run() {
        string[] inputs = ReadInput("inputs/dayone/inputs.txt");
        int result = ProcessRotations(50, inputs);
        Console.WriteLine(result);
    }

    static void Main() {
        DayOne dayTwo = new DayOne();
        dayTwo.Run();
    }
}