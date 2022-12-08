using System.Linq;
public class Solution
{
    public static void Main(string[] args)
    {
        string path = "C:\\Users\\n.scherm\\source\\repos\\AdventOfCode22\\Day3_Rucksack_Reorganization\\input.txt";
        int summedPrios = 0;
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            if (i % 3 == 0)
            {
                var group = new Tuple<string, string, string>(lines[i], lines[i + 1], lines[i + 2]);
                summedPrios += getPrio(getDuplicateTriplet(group));
            }
        }
        Console.WriteLine("Total Prios: " + summedPrios);
    }

    public static char getDuplicate(string rucksack)
    {
        int numberOfItems = rucksack.Length;
        string firstCompartment = rucksack.Substring(0, numberOfItems / 2);
        string secondCompartment = rucksack.Substring(numberOfItems / 2);
        char duplicate = new char();

        foreach (char c in firstCompartment)
        {
            if (secondCompartment.Contains(c))
            {
                duplicate = c;
                break;
            }
        }
        return duplicate;
    }

    public static char getDuplicateTriplet(Tuple<string, string, string> group)
    {
        char duplicate = new char();
        foreach (char c in group.Item1)
        {
            if (group.Item2.Contains(c) && group.Item3.Contains(c))
            {
                duplicate = c;
                break;
            }
        }
        return duplicate;
    }

    public static int getPrio(char c)
    {
        if (c >= 'a' && c <= 'z') return (int)c - 'a' + 1;
        else return (int)c - 'A' + 27;
    }
}