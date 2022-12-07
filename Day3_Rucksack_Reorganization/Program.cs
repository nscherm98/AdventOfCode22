using System.Linq;
public class Solution
{
    public static void Main(string[] args)
    {
        string path = "C:\\Users\\n.scherm\\source\\repos\\AdventOfCode22\\Day3_Rucksack_Reorganization\\input.txt";
        int summedPrios = 0;
        foreach (string line in System.IO.File.ReadLines(path))
        {
            summedPrios += getPrio(getDuplicate(line));
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

    public static int getPrio(char c)
    {
        if (c >= 'a' && c <= 'z') return (int)c - 'a' + 1;
        else return (int)c - 'A' + 27;
    }
}