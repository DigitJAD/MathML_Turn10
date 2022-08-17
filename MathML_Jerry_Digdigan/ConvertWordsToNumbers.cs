using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathML_Jerry_Digdigan
{
    // Helper class to convert numbers that are in string form to float
    public class ConvertWordsToNumbers
    {
        // Dictionary used to compare number strings with their corresponding integers
        private static Dictionary<string, int> numberTable = new Dictionary<string, int>
        {
            {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8},
            {"nine", 9}, {"ten", 10}, {"eleven", 11}, {"twelve", 12}, {"thirteen", 13}, {"fourteen", 14}, {"fifteen", 15},
            {"sixteen", 16}, {"seventeen", 17}, {"eighteen", 18}, {"nineteen", 19}, {"twenty", 20}, {"thirty", 30}, {"forty", 40},
            {"fifty", 50}, {"sixty", 60}, {"seventy", 70}, {"eighty", 80}, {"ninety", 90}, {"hundred", 100}, {"thousand", 1000},
            {"million", 1000000}, {"billion", 1000000000}
        };

        // Function used to take in string number and convert to float if needed
        public float WordsToNumbers(string num)
        {
            // Break up spelled out number into separate strings and store in array
            string[] words = num.ToLower().Split(new char[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int result = 0;

            // Compare each string in the array and convert to float if needed
            foreach (string word in words)
            {
                if (numberTable.ContainsKey(word))
                {
                    result += numberTable[word];
                }
                else if (numberTable.ContainsValue(Int32.Parse(word)))
                {
                    result = Int32.Parse(num);
                }
                else
                {
                    result += 0;
                }
            }
            return result;
        }
    }
}
