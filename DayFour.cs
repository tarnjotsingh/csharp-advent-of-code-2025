using System.Formats.Tar;

namespace AdventOfCode;

public class DayFour() {

    string[] ReadInput(string filePath) {
        string fileText = File.ReadAllText(filePath);
        string[] linesArray = fileText.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.RemoveEmptyEntries
        );
        return linesArray;
    }

    // Lookup above row, not if at top of row
    // Lookup current row
    // Lookup below row, not if at bottom of row
    int CalcAccessibleRolls(List<string> rollStack) {
        int pickablePaperRolls = 0;

        // Traverse down the 2d array
        for(int i = 0; i < rollStack.Count; i++){
            List<string> tmpStack = [];
            string crossIndicatedString = "";
            int previousRow = i - 1, nextRow = i + 1;
            int pickableThisRow = 0, strLen = rollStack[0].Length;

            if(previousRow >= 0) tmpStack.Add(rollStack[previousRow]);
            tmpStack.Add(rollStack[i]);
            if(nextRow < rollStack.Count) tmpStack.Add(rollStack[nextRow]);

            // Built temp array, then process through that.
            // Traverse the tmpStack left to right.
            for(int j = 0; j < strLen; j++) {
                int adjacentRolls = 0;
                int rowToTraverse = (i == rollStack.Count - 1) ? 1 : tmpStack.Count / 3;
                char currentChar = tmpStack[rowToTraverse][j];

                // While traversing left to right, if we land on a paper roll @, then we check around it.
                if(currentChar == '@') {
                    List<int> rowPos = [rowToTraverse - 1, rowToTraverse, rowToTraverse + 1];
                    List<int> colPos = [j - 1, j, j + 1];
                    // If current pos is a paper roll, then check above and below and count adjacent vals.
                    // Loop to check row above and below.

                    foreach(int r in rowPos) {
                        if(r >= 0 && r < tmpStack.Count) {
                            var curLine = tmpStack[r];
                            foreach(int c in colPos) {
                                if(c >= 0 && c < strLen) {
                                    adjacentRolls += tmpStack[r][c] == '@' ? 1 : 0;
                                }
                            }
                        }
                    }
                    adjacentRolls--;
                    pickableThisRow += adjacentRolls < 4 ? 1 : 0;
                    crossIndicatedString += adjacentRolls < 4 ? 'x' : '@';
                } else{
                    crossIndicatedString += '.';
                }
            }

            // Console.Write(crossIndicatedString + " ");
            // Console.Write(rollStack[i] + " ");
            // Console.WriteLine(pickableThisRow);
            pickablePaperRolls += pickableThisRow;
        }

        return pickablePaperRolls;
    }

    // A forklift can only pick up ONE roll of paper at a time.
    // You have to work through the 8 immediate positions around a rolls of paper.
    // Up, down, left, right, and each diag. You'll be processing a 3x3 2d array to work this out.
    // Assume all strings provided are the same length.
    public void Run() {
        string[] inputs = ReadInput("inputs/dayfour/inputs.txt");
        List<string> paperStack  = [];
        foreach (string s in inputs)
            paperStack.Add(s);


        Console.WriteLine(CalcAccessibleRolls(paperStack));

    }

    static void Main() {
        DayFour dayFour = new DayFour();
        dayFour.Run();
    }
}