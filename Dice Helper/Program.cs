using Dice_Helper;

bool loop = true;
Random random = new Random();
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
            Console.WriteLine(dice.Roll(inputArray[1]));
            Console.ReadLine();
            Console.Clear();
            break;
        default: 
            Console.WriteLine("Invalid input, try again."); 
            break;
    }
}