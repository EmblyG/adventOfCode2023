namespace AdventOfCode2023;

public class Day1
{
    public static void Day1Execute()
    {
        List<KeyValuePair<string, int>> numbersAsWords = new()
        {
            new KeyValuePair<string,int>("one",1),
            new KeyValuePair<string,int>("two",2),
            new KeyValuePair<string,int>("three",3),
            new KeyValuePair<string,int>("four",4),
            new KeyValuePair<string,int>("five",5),
            new KeyValuePair<string,int>("six",6),
            new KeyValuePair<string,int>("seven",7),
            new KeyValuePair<string,int>("eight",8),
            new KeyValuePair<string,int>("nine",9),
        };
        
        var file = File.ReadAllLines(".\\TextFiles\\day1aoc.txt");
        var sum = 0;
        foreach (var line in file)
        {
            int first = 0, last = 0;
            for (var index = 0; index < line.Length; index++)
            {
                var c = line[index];
                if (char.IsDigit(c))
                {
                    if (first == 0)
                    {
                        first = int.Parse(c.ToString());
                    }
                    else
                    {
                        last = int.Parse(c.ToString());
                    }
                }
                else
                {
                    foreach (var number in numbersAsWords)
                    {
                        if (line.Substring(index).StartsWith(number.Key))
                        {
                            if (first == 0)
                            {
                                first = number.Value;
                            }
                            else
                            {
                                last = number.Value;
                            }
                        }
                        
                    }
                    
                }
            }
            if (last == 0)
            {
                last = first;  
            }
            sum +=int.Parse(first.ToString()+last.ToString());
        }
        Console.WriteLine(sum);
    }
}