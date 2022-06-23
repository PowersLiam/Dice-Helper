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
            int sides = Int32.Parse(rollArray[1]);

            String results = "";

            for (int i = 0; i < quantity; i++)
            {
                if (i == 0)
                {
                    results += random.Next(1, sides + 1);
                }
                else
                {
                    results += ", " + random.Next(1, sides + 1);
                }
            }
            return results;
        }

        public String Prob(String diceInput, String rString, String yString)
        {
            String output;
            double result = 0;
            Random random = new Random();
            String[] rollArray = new String[2];
            rollArray = diceInput.Split('d');
            int n = Int32.Parse(rollArray[0]);  //number of dice
            int s = Int32.Parse(rollArray[1]);  //number of sides
            double p = 1/(double)s;  //probability of rolling any value from a die

            int r;  //number of successes

            int y;  //the target number(s), what would be considered a success with this roll

            double nCr; //number of combinations

            
            if (rString.Contains("+")){
                r = Int32.Parse(rString.Remove(rString.Length - 1, 1));
                nCr = (double)Fact(n) / ((double)Fact(r) * (double)Fact(n - r));

                if (yString.Contains("+"))
                {
                    y = Int32.Parse(yString.Remove(yString.Length - 1, 1));
                }
                else
                {
                    y = Int32.Parse(yString);
                }
                for (int ir = r; ir <= n; ir++)
                {
                    nCr = (double)Fact(n) / ((double)Fact(ir) * (double)Fact(n - ir));
                    result += nCr * Math.Pow(p, ir) * Math.Pow(1 - p, n - ir);
                }
            }
            else
            {
                r = Int32.Parse(rString);
                nCr = (double)Fact(n) / ((double)Fact(r) * (double)Fact(n - r));

                if (yString.Contains("+"))
                {
                    y = Int32.Parse(yString.Remove(yString.Length - 1, 1)); 
                }
                else
                {
                    y = Int32.Parse(yString);
                }
                result = nCr * Math.Pow(p, r) * Math.Pow(1 - p, n - r);
            }
            
            result = Math.Round(result * 100, 3);
            output = result.ToString() + "%";
            

            return output;
        }

        private int Fact(int num) //Factorial Function
        {
            if (num == 0) return 1; //this is just how factorials work

            for (int i = num-1; i > 1; i--)
            {
                num = num * i;
            }
            return num;
        }
    }
}
