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
        int pickablePaperRolls, removedPaperRolls = 0;
        List<string> updatedPaperStack, currentPaperStack = rollStack;

        do {
            pickablePaperRolls = 0;
            updatedPaperStack = [];

            // Traverse down the 2d array
            for(int i = 0; i < currentPaperStack.Count; i++){
                string crossIndicatedString = "";
                int pickableThisRow = 0, strLen = currentPaperStack[0].Length;

                // Traverse the tmpStack left to right.
                for(int j = 0; j < strLen; j++) {
                    int adjacentRolls = 0;
                    char currentChar = currentPaperStack[i][j];

                    // While traversing left to right, if we land on a paper roll @, then we check around it.
                    if(currentChar == '@') {
                        List<int> rowPos = [i - 1, i, i + 1];
                        List<int> colPos = [j - 1, j, j + 1];

                        // If current pos is a paper roll, then check above and below and count adjacent vals.
                        // Loop to check row above and below.
                        foreach(int r in rowPos) {
                            if(r >= 0 && r < currentPaperStack.Count) {
                                foreach(int c in colPos) {
                                    if(c >= 0 && c < strLen)
                                        adjacentRolls += currentPaperStack[r][c] == '@' ? 1 : 0;
                                }
                            }
                        }

                        adjacentRolls--;
                        bool pickable = adjacentRolls < 4;
                        pickableThisRow += pickable ? 1 : 0;
                        crossIndicatedString += pickable ? '.' : '@';
                    } else {
                        crossIndicatedString += '.';
                    }
                }

                Console.Write(crossIndicatedString + " ");
                Console.WriteLine(pickableThisRow);

                pickablePaperRolls += pickableThisRow;
                updatedPaperStack.Add(crossIndicatedString);

            }
            currentPaperStack = updatedPaperStack;
            removedPaperRolls += pickablePaperRolls;
        } while(pickablePaperRolls != 0);

        return removedPaperRolls;
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