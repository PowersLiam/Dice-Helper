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

            if (yString.Contains("+"))
            {
                y = Int32.Parse(yString.Remove(yString.Length - 1, 1));
                p = (s - y + 1) / (double)s;
            }
            else
            {
                y = Int32.Parse(yString);
            }

            if (rString.Contains("+")){
                r = Int32.Parse(rString.Remove(rString.Length - 1, 1));
                for (int ir = r; ir <= n; ir++)
                {
                    nCr = CalcNCR(n, ir);
                    result += nCr * Math.Pow(p, ir) * Math.Pow(1 - p, n - ir);
                }
            }
            else
            {
                r = Int32.Parse(rString);
                nCr = CalcNCR(n, r);
                result = nCr * Math.Pow(p, r) * Math.Pow(1 - p, n - r);
            }
            
            result = Math.Round(result * 100, 3);
            switch (result)
            {
                case (100):
                    output = "99.999%";
                    break;
                case (0):
                    output = "<0.001%";
                    break;
                default:
                    output = result.ToString() + "%";
                    break;
            }

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

        private double CalcNCR(int n, int r)
        {
            return (double)Fact(n) / ((double)Fact(r) * (double)Fact(n - r));
        }

        public String Chart(String diceInput)
        {
            String[] rollArray = new String[2];
            rollArray = diceInput.Split('d');
            int n = Int32.Parse(rollArray[0]);  //number of dice
            int s = Int32.Parse(rollArray[1]);  //number of sides
            String output = "\n _| x = successes \n y = success condition \n\n";
            String temp;

            output += "      ";

            for (int i = 1; i <= n; i++)
            {
                
                output += "    " + i + "+    ";
            }

            output += "\n";

            for (int yAxis = 2; yAxis <= s; yAxis++)
            {
                if (yAxis < 10) output += " ";
                output += " " + yAxis + "+  ";
                for (int xAxis = 1; xAxis <= n; xAxis++)
                {
                    output += "|";
                    temp = Prob(diceInput, xAxis.ToString() + "+", yAxis.ToString() + "+");
                    //ensure consistent length of result
                    while (temp.Length < 7)
                    {
                        temp += " ";
                    }
                    output += " " + temp + " ";
                }
                output += "\n";
            }
            output += "\n";

            return output;
        }
    }
}
