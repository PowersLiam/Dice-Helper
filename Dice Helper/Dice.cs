using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Helper
{
    internal class Dice
    {
        public String Roll(String input)
        {
            Random random = new Random();
            String[] rollArray = new String[2];
            rollArray = input.Split('d');
            int quantity = Int32.Parse(rollArray[0]);
            int die = Int32.Parse(rollArray[1]);

            String results = "";

            for (int i = 0; i < quantity; i++)
            {
                if (i == 0)
                {
                    results += random.Next(1, die + 1);
                }
                else
                {
                    results += ", " + random.Next(1, die + 1);
                }
            }
            return results;
        }
    }
}
