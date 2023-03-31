using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCli
{
    internal class Operator
    {
        static readonly char[] operators = { '+', '-', '/', '*', '^' };
        private char _operator;

        public char Value
        {
            get { return _operator; }
            private set
            {
                int index = Array.IndexOf(operators, value);
                if (index != -1)
                {
                    _operator = value;
                }
                else
                {
                    throw new ArgumentException("Operations defined are the following: +, -, /, *, ^.");
                }
            }
        }
        public static bool TryParse(string operatorIntent, out Operator operation)
        {
            try
            {
                operation = new Operator
                {
                    Value = char.Parse(operatorIntent)
                };
                return true;
            }
            catch (Exception)
            {
                operation = null;
                return false;
            }
        }
        public static int IndexIn(string s)
        {
            return s.IndexOfAny(operators);
        }
        public string PerformOperation(int numberOne, int numberTwo)
        {
            if (Value == '/' && numberTwo == 0)
            {
                return "Lo siento, no puedo dividir entre cero.";
            }

            switch (Value)
            {
                case '+':
                    return $"La suma de {numberOne} y {numberTwo} es {numberOne + numberTwo}.";
                case '-':
                    return $"La resta de {numberOne} y {numberTwo} es {numberOne - numberTwo}.";
                case '*':
                    return $"La multiplicación de {numberOne} y {numberTwo} es {numberOne * numberTwo}.";
                case '/':
                    double result = (double)numberOne / (double)numberTwo;
                    return $"La división de {numberOne} y {numberTwo} es {result.ToString("0.00")}.";
                case '^':
                    return $"{numberOne} elevado a {numberTwo} es {Pow(numberOne, numberTwo)}.";
                default:
                    return "Ha tenido lugar un error desconocido.";
            }
        }
        private static int Pow(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; i++)
            {
                result *= a;
            }
            return result;
        }
        private Operator() {}
    }
}
