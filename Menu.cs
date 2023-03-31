using System;

namespace CalculatorCli
{
    internal static class Menu
    {
        private static bool watch = true;

        public static void MainLoop()
        {
            Console.WriteLine("CALCULADORA");
            do
            {
                PrintOptions();
                if (Enum.TryParse(Console.ReadLine(), out Mode option))
                {
                    switch (option)
                    {
                        case Mode.Exit:
                            watch = false;
                            break;
                        case Mode.Manual:
                            ManualMode();
                            break;
                        case Mode.Automatic:
                            AutomaticMode();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("No he encontrado la opción que ha ingresado.");
                }
                Console.WriteLine();
            } while (watch);
        }
        private static void PrintOptions()
        {
            Console.WriteLine("1 - Modo manual.");
            Console.WriteLine("2 - Modo automático.");
            Console.WriteLine("0 - Salir.");
            Console.WriteLine();
        }
        private static void AutomaticMode()
        {
            Console.Write("Introduzca una expresión: ");
            string expression = Console.ReadLine().Trim();
            int operatorIndex = Operator.IndexIn(expression);
            if (operatorIndex != -1)
            {
                string[] elements = expression.Split(expression[operatorIndex]);
                if (
                    Operator.TryParse(expression[operatorIndex].ToString(), out Operator operation)
                    && int.TryParse(elements[0], out int numberOne)
                    && int.TryParse(elements[1], out int numberTwo))
                {
                    Console.WriteLine(operation.PerformOperation(numberOne, numberTwo));
                }
                else
                {
                    Console.WriteLine("Lo siento, no he podido entender la expresión.");
                }
            }
            else
            {
                Console.WriteLine("Lo siento, no he encontrado niguna operación soportada.");
            }
        }
        private static void ManualMode()
        {
            Console.Write("Ingrese el tipo de operación (+, -, /, *, ^): ");
            if (Operator.TryParse(Console.ReadLine().Trim(), out Operator operation))
            {
                Console.Write("Introduza el primer operando: ");
                int numberOne = ReadInt();
                Console.Write("Introduzca el segundo operando: ");
                int numberTwo = ReadInt();
                Console.WriteLine(operation.PerformOperation(numberOne, numberTwo));
            }
            else
            {
                Console.WriteLine("Lo siento, parece que no implemento esa operación");
            }
        }
        private static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out int number))
                {
                    return number;
                }
                else
                {
                    Console.Write("No ha introducido un número entero, intentelo de nuevo por favor: ");
                }
            }
        } 
    }
}