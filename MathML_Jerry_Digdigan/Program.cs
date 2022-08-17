using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq; // namespace to be used if file is in JSON format

namespace MathML_Jerry_Digdigan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instance of ConvertWordsToNumbers() class
            ConvertWordsToNumbers wn = new ConvertWordsToNumbers();

            // Deserializes the XML file
            XDocument mathXdoc = XDocument.Load("math.xml");

            /*
            // In the case where the input data is in JSON format
            // convert JSON file to XML format
            XmlDocument mathXdoc = (XmlDocument) JsonConvert.DeserializeXmlNode("math.json");
            */

            // Parse add operation
            var addOperation = from operation in mathXdoc.Descendants("Add")
                               select new
                               {
                                   Description = operation.Element("Description").Value.Split(';'),
                                   Value1 = operation.Element("Value1").Value,
                                   Value2 = operation.Element("Value2").Value
                               };

            // Parse subtract operation
            var subtractOperation = from operation in mathXdoc.Descendants("Subtract")
                                    select new
                                    {
                                        Description = operation.Element("Description").Value.Split(';'),
                                        Value1 = operation.Element("Value1").Value,
                                        Value2 = operation.Element("Value2").Value
                                    };

            // Parse multiply operation
            var multiplyOperation = from operation in mathXdoc.Descendants("Multiply")
                                    select new
                                    {
                                        Description = operation.Element("Description").Value.Split(';'),
                                        Value1 = operation.Element("Value1").Value,
                                        Value2 = operation.Element("Value2").Value
                                    };

            // Parse divide operation
            var divideOperation = from operation in mathXdoc.Descendants("Divide")
                                  select new
                                  {
                                      Description = operation.Element("Description").Value.Split(';'),
                                      Value1 = operation.Element("Value1").Value,
                                      Value2 = operation.Element("Value2").Value
                                  };

            // Parse in the case the XML file contains a Power operation
            var powerOperation = from operation in mathXdoc.Descendants("Power")
                                  select new
                                  {
                                      Description = operation.Element("Description").Value.Split(';'),
                                      Value1 = operation.Element("Value1").Value,
                                      Value2 = operation.Element("Value2").Value
                                  };

            
            // Performs addition operation and outputs message
            foreach (var operation in addOperation)
            {
                char add = '+';

                // Try to convert value into int, calculate, and output message
                try
                {
                    int v1 = Convert.ToInt32(operation.Value1);
                    int v2 = Convert.ToInt32(operation.Value2);
                    float calculation = Calculate(v1, v2, add);

                    Console.WriteLine("{0} - {1} - {2} + {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
                // Catch if unable to convert value to int, call WordsToNumbers() method in ConvertWordsToNumbers class
                // Once string is returned as a float, calculate and output message
                catch (Exception)
                {
                    float v1 = wn.WordsToNumbers(operation.Value1);
                    float v2 = wn.WordsToNumbers(operation.Value2);
                    float calculation = Calculate(v1, v2, add);

                    Console.WriteLine("{0} - {1} - {2} + {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
            }

            // Performs subtraction operation and outputs message
            foreach (var operation in subtractOperation)
            {
                char minus = '-';

                // Try to convert value into int, calculate, and output message
                try
                {
                    int v1 = Convert.ToInt32(operation.Value1);
                    int v2 = Convert.ToInt32(operation.Value2);
                    float calculation = Calculate(v1, v2, minus);

                    Console.WriteLine("{0} - {1} - {2} - {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value2, operation.Value1);
                }
                // Catch if unable to convert value to int, call WordsToNumbers() method in ConvertWordsToNumbers class
                // Once string is returned as a float, calculate and output message
                catch (Exception)
                {
                    float v1 = wn.WordsToNumbers(operation.Value1);
                    float v2 = wn.WordsToNumbers(operation.Value2);
                    float calculation = Calculate(v1, v2, minus);

                    Console.WriteLine("{0} - {1} - {2} - {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value2, operation.Value1);
                }
            }

            // Performs multiplication operation and outputs message
            foreach (var operation in multiplyOperation)
            {
                char mult = '*';

                // Try to convert value into int, calculate, and output message
                try
                {
                    int v1 = Convert.ToInt32(operation.Value1);
                    int v2 = Convert.ToInt32(operation.Value2);
                    float calculation = Calculate(v1, v2, mult);

                    Console.WriteLine("{0} - {1} - {2} * {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
                // Catch if unable to convert value to int, call WordsToNumbers() method in ConvertWordsToNumbers class
                // Once string is returned as a float, calculate and output message
                catch (Exception)
                {
                    float v1 = wn.WordsToNumbers(operation.Value1);
                    float v2 = wn.WordsToNumbers(operation.Value2);
                    float calculation = Calculate(v1, v2, mult);

                    Console.WriteLine("{0} - {1} - {2} * {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
            }

            // Performs division operation and outputs message
            foreach (var operation in divideOperation)
            {
                char div = '/';

                // Try to convert value into float, calculate, and output message
                try
                {
                    float v1 = (float)Convert.ToDouble(operation.Value1);
                    float v2 = (float)Convert.ToDouble(operation.Value2);
                    float calculation = Calculate(v1, v2, div);

                    Console.WriteLine("{0} - {1} - {2} / {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
                // Catch if unable to convert value to float, call WordsToNumbers() method in ConvertWordsToNumbers class
                // Once string is returned as a float, calculate and output message
                catch (Exception)
                {
                    float v1 = wn.WordsToNumbers(operation.Value1);
                    float v2 = wn.WordsToNumbers(operation.Value2);
                    float calculation = Calculate(v1, v2, div);

                    Console.WriteLine("{0} - {1} - {2} / {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
            }

            // Performs power operation and outputs message
            foreach (var operation in powerOperation)
            {
                char pow = '^';

                // Try to convert value into float, calculate, and output message
                try
                {
                    float v1 = (float)Convert.ToDouble(operation.Value1);
                    float v2 = (float)Convert.ToDouble(operation.Value2);
                    float calculation = Calculate(v1, v2, pow);

                    Console.WriteLine("{0} - {1} - {2} ^ {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
                // Catch if unable to convert value to float, call WordsToNumbers() method in ConvertWordsToNumbers class
                // Once string is returned as a float, calculate and output message
                catch (Exception)
                {
                    float v1 = wn.WordsToNumbers(operation.Value1);
                    float v2 = wn.WordsToNumbers(operation.Value2);
                    float calculation = Calculate(v1, v2, pow);

                    Console.WriteLine("{0} - {1} - {2} ^ {3} = " + calculation,
                        operation.Description[0], operation.Description[1], operation.Value1, operation.Value2);
                }
            }

            Console.ReadLine();
        }

        // Helper function used to calculate based on indicated operator
        static float Calculate(float value1, float value2, char op)
        {
            float solution = 0;

            switch (op)
            {
                case '+':
                    solution = value1 + value2;
                    break;
                case '-':
                    solution = value2 - value1;
                    break;
                case '*':
                    solution = value1 * value2;
                    break;
                case '/':
                    solution = value1 / value2;
                    break;
                case '^':
                    solution = (float) Math.Pow(value1, value2);
                    break;
            }

            return solution;
        }
    }
}
