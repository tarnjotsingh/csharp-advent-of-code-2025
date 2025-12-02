using System.Collections;

// Program.cs
// The execution starts here without explicit 'Main' method or 'class' definition.


// Dial with number from 0 to 99
// If number goes below 0, then start at 99 backwards
// If number goes above 99, then start from 0 onwards

int minVal = 0;
int maxVal = 99;


int turnLeft(int val, int turnVal)
{
    int g = turnVal / maxVal;
    double f = ((((double)turnVal / maxVal)) - g) * maxVal;
    int result = val == turnVal ? 0 : val - (int)f;
    if(result < minVal)
        return result + (maxVal + 1);
    else
        return result;

}

int turnRight(int val, int turnVal)
{
    int g = turnVal / maxVal;
    double f = ((((double)turnVal / maxVal)) - g) * maxVal;
    int result = val == turnVal ? 0 : val + (int)f;
    if(result > maxVal)
        return result - (maxVal + 1);
    else
        return result;
}

int rotateDial(int val, String rotate)
{
    String turnDir = rotate.Substring(0, 1);
    int turnVal = Int32.Parse(rotate.Substring(1));

    switch(turnDir)
    {
        case "L":
            return turnLeft(val, turnVal);
        case "R":
            return turnRight(val, turnVal);
        default:
            throw new ArgumentException("Invalid turn value.");
    }
}

int processRotations(int startVal, string[] rotations) {
    int lastVal = startVal;
    int zeroCount = 0;
    foreach(string r in rotations){
        lastVal = rotateDial(lastVal, r);
        if(lastVal == 0) zeroCount++;
    }
    return zeroCount;
}


string[] readInput(string filePath)
{
    string fileText = File.ReadAllText(filePath);
    string[] linesArray = fileText.Split(
        new string[] { "\r\n", "\r", "\n" },
        StringSplitOptions.RemoveEmptyEntries
    );
    return linesArray;
}


string[] inputs = readInput("inputs.txt");
int result = processRotations(50, inputs);
Console.WriteLine(result);