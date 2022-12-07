public class Solution
{
    static void Main(string[] args)
    {
        string path = "C:\\Users\\n.scherm\\source\\repos\\AdventOfCode22\\Day2_Rock_Paper_Scissors\\input.txt";
        var parsedInput = new List<Tuple<char, char>>();
        foreach (string line in System.IO.File.ReadLines(path))
        {
            parsedInput.Add(parseInput(line));
        }
        var replacedSelection = replacePlayerSelection(parsedInput);
        var totalPoints = determineTotalPoints(replacedSelection);
        Console.WriteLine("Total: " + totalPoints);
    }

    public static Tuple<char, char> parseInput(string line)
    {
        return Tuple.Create(line[0], line[2]);
    }

    public static int determineSelectionPoints(char move)
    {
        if (move == 'X') return 1;
        else if (move == 'Y') return 2;
        else return 3;
    }

    public static int determineWinnerPoints(char moveOpponent, char movePlayer)
    {
        // case: draw
        if ((moveOpponent == 'A' && movePlayer == 'X') ||
            (moveOpponent == 'B' && movePlayer == 'Y') ||
            (moveOpponent == 'C' && movePlayer == 'Z')) return 3;

        // case: player wins
        else if ((moveOpponent == 'A' && movePlayer == 'Y') ||
            (moveOpponent == 'B' && movePlayer == 'Z') ||
            (moveOpponent == 'C' && movePlayer == 'X')) return 6;

        // case: player loses
        else return 0;
    }

    public static int determineTotalPoints(List<Tuple<char, char>> moves)
    {
        int totalPoints = 0;
        foreach (var move in moves)
        {
            totalPoints += determineSelectionPoints(move.Item2);
            totalPoints += determineWinnerPoints(move.Item1, move.Item2);
        }
        return totalPoints;
    }

    public static List<Tuple<char, char>> replacePlayerSelection(List<Tuple<char, char>> moves)
    {
        var result = new List<Tuple<char, char>>();
        foreach (var move in moves)
        {
            char moveOpponent = move.Item1;
            char movePlayer = move.Item2;
            char newSelection;

            if (movePlayer == 'X') newSelection = getLosingSelection(moveOpponent); // player has to lose
            else if (movePlayer == 'Z') newSelection = getWinningSelection(moveOpponent); // player has to win
            else newSelection = getDrawSelection(moveOpponent); // player need to draw
            result.Add(Tuple.Create(moveOpponent, newSelection));
        }
        return result;
    }

    public static char getLosingSelection(char move)
    {
        if (move == 'A') return 'Z';
        else if (move == 'B') return 'X';
        else return 'Y';
    }

    public static char getWinningSelection(char move)
    {
        if (move == 'A') return 'Y';
        else if (move == 'B') return 'Z';
        else return 'X';
    }

    public static char getDrawSelection(char move)
    {
        if (move == 'A') return 'X';
        else if (move == 'B') return 'Y';
        else return 'Z';
    }
}
