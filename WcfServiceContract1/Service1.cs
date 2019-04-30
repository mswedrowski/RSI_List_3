using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator
    {
        double sum = 0;

        public double getSum(double numberToAdd)
        {
            return sum += numberToAdd;
        }

        public double addNumbers(double number1, double number2)
        {
            var result = number1 + number2;
            Console.WriteLine("Add:" + result);
            return result;
        }


        public double multiplyNumbers(double number1, double number2)
        {
            var result = number1 * number2;
            Console.WriteLine("Multiply:" + result);
            return result;
        }

        public double substractNumbers(double number1, double number2)
        {
            var result = number1 - number2;
            Console.WriteLine("Subtract:" + result );
            return result;
        }

        public double divideNumber(double number1, double number2)
        {
            if (number2 == 0)
                return 0;

            else
            {
                var result = number1 / number2;
                Console.WriteLine("Divide:" + result);
                return result;
            }
        }
    }
}
