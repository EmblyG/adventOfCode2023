namespace AdventOfCode2023;

public class Day3
{
    // this does not work yet and I must fix to get my stars
    public static void Day3Part1()
    {
        var file = File.ReadAllLines(".\\TextFiles\\day3aoc.txt");
        var sum = 0;
        //index for each line in the file
        for (var index = 0; index < file.Length; index++)
        {
            var line = file[index];
            //i for each char in the line
            for (var i = 0; i < line.Length;)
            {
                if (line[i] == 46 || !char.IsDigit(line[i]))
                {
                    i++;
                }
                else
                {
                    //check if 1 or 2 or 3 digit #
                    if (!char.IsDigit((line[i + 1])))
                    {
                        if (((i - 1) > 0 && line[i - 1] != 46) || ((i + 1 < line.Length) && line[i + 1] != 46))
                        {
                            sum += int.Parse(line.Substring(i, 1));
                            Console.WriteLine($"{line.Substring(i, 1)}");
                            i++;
                            continue;
                        }

                        string upperLine = null;
                        string lowerLine = null;
                        if (index - 1 > 0)
                        {
                            upperLine = file[index - 1];
                        }

                        if (index + 1 < file.Length)
                        {
                            lowerLine = file[index + 1];
                        }

                        //upper or lower line is symbol
                        for (int j = i - 1; j < i + 1; j++)
                        {
                            if ((upperLine is not null && upperLine[j] != 46 && !char.IsDigit(upperLine[j])) ||
                                (lowerLine is not null && lowerLine[j] != 46 && !char.IsDigit(lowerLine[j])))
                            {
                                sum += int.Parse(line.Substring(i, 1));
                                Console.WriteLine($"{line.Substring(i, 1)}");
                                break;
                            }
                        }

                        i++;
                    }
                    else if (char.IsDigit(line[i + 2]))
                    {
                        //3 digit #
                        //left or right in line is symbol
                        if (((i - 1) > 0 && line[i - 1] != 46) || ((i + 3 < line.Length) && line[i + 3] != 46))
                        {
                            sum += int.Parse(line.Substring(i, 3));
                            Console.WriteLine($"{line.Substring(i, 3)}");
                            i += 3;
                            continue;
                        }

                        string upperLine = null;
                        string lowerLine = null;
                        if (index - 1 > 0)
                        {
                            upperLine = file[index - 1];
                        }

                        if (index + 1 < file.Length)
                        {
                            lowerLine = file[index + 1];
                        }

                        //upper or lower line is symbol
                        for (int j = i - 1; j < i + 4; j++)
                        {
                            if (j < 0 || j >= 140) continue;
                            if ((upperLine is not null && upperLine[j] != 46 && !char.IsDigit(upperLine[j])) ||
                                (lowerLine is not null && lowerLine[j] != 46 && !char.IsDigit(lowerLine[j])))
                            {
                                sum += int.Parse(line.Substring(i, 3));
                                Console.WriteLine($"{line.Substring(i, 3)}");
                                break;
                            }
                        }

                        i += 3;

                    }
                    else
                    {
                        //2 digit #
                        //left or right in line is symbol
                        if (line[i - 1] != 46 || line[i + 2] != 46)
                        {
                            sum += int.Parse(line.Substring(i, 2));
                            Console.WriteLine($"{line.Substring(i, 2)}");
                            i += 2;
                            continue;
                        }

                        string upperLine = null;
                        string lowerLine = null;
                        if (index - 1 > 0)
                        {
                            upperLine = file[index - 1];
                        }

                        if (index + 1 < file.Length)
                        {
                            lowerLine = file[index + 1];
                        }

                        //upper or lower line is symbol
                        for (int j = i - 1; j < i + 3; j++)
                        {
                            if ((upperLine is not null && upperLine[j] != 46 && !char.IsDigit(upperLine[j])) ||
                                (lowerLine is not null && lowerLine[j] != 46 && !char.IsDigit(lowerLine[j])))
                            {
                                sum += int.Parse(line.Substring(i, 2));
                                Console.WriteLine($"{line.Substring(i, 2)}");
                                i += 2;
                                break;
                            }
                        }

                        i += 2;
                    }
                }
            }
        }

        Console.WriteLine(sum);
    }
}