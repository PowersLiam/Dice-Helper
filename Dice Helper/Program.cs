using Dice_Helper;
using System.Text.RegularExpressions;

bool loop = true;
Random random = new Random();
String diceEx = "(^([1-9][0-9]?|100)[d]([1-9][0-9]?|100)$)|(^[d]([1-9][0-9]?|100)$)";
String probEx = @"^[1-9][0-9]*\+?$";
Dice dice = new Dice();

while (loop)
{
    Console.WriteLine("What would you like to do?");
    String? input = Console.ReadLine();
    if (input == null) input = "";
    input = input.ToLower();
    String[] inputArray = input.Split(' ');

    switch (inputArray[0])
    {
        case ("exit"): 
            loop = false;
            break;
        case ("clear"):
            Console.Clear();
            break;
        case ("roll"):
            if (inputArray.Length > 2)
            {
                Console.WriteLine("Too much information, invalid phrasing. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }
            else if (inputArray.Length < 2)
            {
                Console.WriteLine("Not enough information. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }
            else
            {
                if (Regex.IsMatch(inputArray[1], diceEx))
                {
                    if (inputArray[1][0] == 'd') inputArray[1] = '1' + inputArray[1];
                    Console.WriteLine(dice.Roll(inputArray[1]) + "\n");
                }
                else
                {
                    Console.WriteLine("Invalid dice expression, try again. Type \"Help\" to see valid phrasing.\n");
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
                }
            }
            break;
        case ("prob"):
            if (Regex.IsMatch(inputArray[1], diceEx))
            {
                if (inputArray.Length == 4)
                {
                    if (inputArray[1][0] == 'd') inputArray[1] = '1' + inputArray[1];
                    if (Regex.IsMatch(inputArray[2], probEx) && Regex.IsMatch(inputArray[3], probEx))
                    {
                        Console.WriteLine(dice.Prob(inputArray[1], inputArray[2], inputArray[3], false) + "\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid dice success quantity/target. Type \"Help\" to see valid phrasing.\n");
                        File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
                    }
                }
                else if (inputArray.Length < 4)
                {
                    Console.WriteLine("Not enough information. Type \"Help\" to see valid phrasing.\n");
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
                }
                else
                {
                    Console.WriteLine("Too much information, invalid phrasing. Type \"Help\" to see valid phrasing.\n");
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid dice expression, try again. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }
            break;
        case ("chart"):
            if (inputArray.Length > 2)
            {
                Console.WriteLine("Too much information, invalid phrasing. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }else if (inputArray.Length < 2)
            {
                Console.WriteLine("Not enough information. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }
            else
            {
                if (Regex.IsMatch(inputArray[1], diceEx))
                {
                    if (inputArray[1][0] == 'd') inputArray[1] = '1' + inputArray[1];
                    var temp = inputArray[1].Split('d');
                    if (Int32.Parse(temp[0]) <= 20)
                    {
                        dice.Chart(inputArray[1]);
                    }
                    else
                    {
                        Console.WriteLine("Cannot chart more than 20 dice.\n");
                        File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid dice expression, try again. Type \"Help\" to see valid phrasing.\n");
                    File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
                }
            }
            break;
        case ("see"):
            if(inputArray.Length < 2)
            {
                Console.WriteLine("Not enough information, invalid phasing. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }
            else if (inputArray.Length > 2)
            {
                Console.WriteLine("Too much information, invalid phasing. Type \"Help\" to see valid phrasing.\n");
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            }
            else
            {
                switch (inputArray[1])
                {
                    case ("rolls"): Console.WriteLine(dice.PrintRolls()); break;
                    case ("probs"): Console.WriteLine(dice.PrintProbs()); break;
                    case ("charts"): Console.WriteLine(dice.PrintCharts()); break;
                    default: Console.WriteLine("Invalid input, try again or type \"Help\" for commands.\n"); break;
                }
            }
            break;
        case ("help"):
            Console.Clear();
            Console.WriteLine("Here are the acceptable commands for this program" +
                "\n exit (end program)" +
                "\n clear (clear console)" +
                "\n roll #d# (#=a number greater than 0, the former is amount of dice, the latter is the number of sides)" +
                "\n prob #d# #(+) #(+) (#=a number greater than 0 and + is option to signify at least this number, " +
                "\n      1st is amount of dice, 2nd is number of sides, 3rd quantity of target results, 4th is the target result)" +
                "\n chart #d# (#=a number greater than 0,the former is amount of dice, the latter is the number of sides," +
                "\n      creates a chart of probabilities for every success condition (except 1+) at any possible amount)" +
                "\n see (\"rolls\" or \"probs\" or \"charts\") (shows recorded log of all rolls, probabilities, or chart requests " +
                "\n      from the current session)\n");
            break;
        default: 
            Console.WriteLine("Invalid input, try again or type 'help' for commands.\n");
            File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "InvalidInputLog.txt"), input + "\n");
            break;
    }
}