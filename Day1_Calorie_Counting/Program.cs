using System;
public class Solution
{
    static void Main(String[] args)
    {
        string path = "C:\\Users\\n.scherm\\source\\repos\\AdventOfCode22\\Day1_Calorie_Counting\\input.txt";
        string[] lines = File.ReadAllLines(path);

        var totalCalories = new List<int>();
        int calories = 0;

        foreach (var line in lines)
        {
            if (!String.IsNullOrWhiteSpace(line))
            {
                calories += int.Parse(line);
                continue;
            }
            totalCalories.Add(calories);
            calories = 0;
        }
        totalCalories.Add(calories);

        // find maximum
        var maxCalories = totalCalories.Max();
        Console.WriteLine("Maximum: " + maxCalories);

        // PART TWO
        int totalCaloriesTopThree = getTotalTopN(totalCalories, 3);
        Console.WriteLine("Total Top 3: " + totalCaloriesTopThree);
    }

    public static int getTotalTopN(List<int> list, int n)
    {
        list.Sort();
        list.Reverse();
        var selection = list.GetRange(0, n);
        return selection.Sum();
    }
}
