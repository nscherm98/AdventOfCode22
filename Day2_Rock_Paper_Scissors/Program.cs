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
        var totalPoints = determineTotalPoints(parsedInput);
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
}
