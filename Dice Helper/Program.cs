using Dice_Helper;
using System.Text.RegularExpressions;

bool loop = true;
Random random = new Random();
String diceEx = "(^[1-9][0-9]{0,2}[d][1-9][0-9]{0,2}$)|(^[d][1-9][0-9]{0,2}$)";

while (loop)
{
    Console.WriteLine("What would you like to do?");
    String? input = Console.ReadLine();
    if (input == null) input = "";
    input = input.ToLower();
    String[] inputArray = input.Split(' ');
    Dice dice = new Dice();

    switch (inputArray[0])
    {
        case ("exit"): 
            loop = false;
            break;
        case ("roll"):
            if(Regex.IsMatch(inputArray[1], diceEx, RegexOptions.IgnoreCase)){
                if (inputArray[1][0] == 'd') inputArray[1] = '1' + inputArray[1];
                Console.WriteLine(dice.Roll(inputArray[1]));
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid dice expression, try again.");
            }


            
            break;
        default: 
            Console.WriteLine("Invalid input, try again."); 
            break;
    }
}