using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Helper
{
    internal class Dice
    {
        private List<string> rolls = new List<string>();
        private List<string> probs = new List<string>();
        private List<string> charts = new List<string>();

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
            rolls.Add(input + ": " + results);
            return results;
        }

        public String Prob(String diceInput, String rString, String yString, bool chart) //Formula: P(X=r) = nCr * p^r * (1-p)^(n-r)
        {
            String output = "";
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
                    if (yString != "1+") 
                    { 
                        output = "99.999%"; 
                    } else { 
                        output = result.ToString() + "%"; 
                    }
                    break;
                case (0):
                    output = "<0.001%";
                    break;
                default:
                    output = result.ToString() + "%";
                    break;
            }
            if(!chart) probs.Add(diceInput + " " + rString + " " + yString + ": " + output);
            return output;
        }

        private double Fact(int num) //Factorial Function
        {
            double output = num;

            if (num == 0) return 1; //this is just how factorials work

            for (int i = num - 1; i > 1; i--)
            {
                output = output * i;
            }
            return output;
        }

        private double CalcNCR(int n, int r)
        {
            return (double)Fact(n) / ((double)Fact(r) * (double)Fact(n - r));
        }

        public void Chart(String diceInput)
        {
            charts.Add(diceInput);
            
            String[] rollArray = new String[2];
            rollArray = diceInput.Split('d');
            int n = Int32.Parse(rollArray[0]);  //number of dice
            int s = Int32.Parse(rollArray[1]);  //number of sides
            String tempX;
            String tempY;
            String[,] chart = new string[s,n+1];
            
            

            chart[0, 0] = "      ";

            for (int i = 1; i <= n; i++)
            {
                if(i < 10) chart[0, i] = "    ";
                if (i >= 10) chart[0, i] = "   ";
                chart[0, i] += i + "+";
                chart[0, i] += "    ";
            }

            for (int yAxis = 2; yAxis <= s; yAxis++)
            {
                tempY = "";
                if (yAxis < 10) tempY += "  ";
                if (yAxis < 100 && yAxis >= 10) tempY += " ";
                tempY += yAxis;
                chart[yAxis-1,0] = " " + tempY + "+  ";
                for (int xAxis = 1; xAxis <= n; xAxis++)
                {
                    tempX = Prob(diceInput, xAxis.ToString() + "+", yAxis.ToString() + "+", true);
                    //ensure consistent length of result
                    while (tempX.Length < 7)
                    {
                        tempX += " ";
                    }
                    chart[yAxis-1, xAxis] = " " + tempX + " ";
                }
            }

            //Print Chart
            Console.WriteLine("\n _| x = successes \n y = success condition \n\n");

            for (int printY = 0; printY < chart.GetLength(0); printY++)
            {
                for (int printX = 0; printX < chart.GetLength(1); printX++)
                {
                    Console.Write(chart[printY, printX]);
                    if (printX < chart.GetLength(1) - 1 && printX > 0 && printY > 0) Console.Write("|");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

        }

        public string PrintRolls()
        {
            String output = "\n Rolls \n";
            foreach(string roll in rolls)
            {
                output += "   " + roll + "\n";
            }
            return output;
        }

        public string PrintCharts()
        {
            String output = "\n Charts \n";
            foreach (string chart in charts)
            {
                output += "   " + chart + "\n";
            }
            return output;
        }

        public string PrintProbs()
        {
            String output = "\n Probabilities \n";
            foreach (string prob in probs)
            {
                output += "   " + prob + "\n";
            }
            return output;
        }
    }
}
