using System;
using Kambarova_libb;

namespace Kambarova_Console
{
    class Kambarova_Console
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консоль калькулятора Kambarova");
            Console.WriteLine("Поддерживаются операции: + - * / ^ и скобки ()");
            Console.WriteLine("Для десятичных дробей используйте точку (.)");
            Console.WriteLine("Для выхода введите 'exit'");
            Console.WriteLine();
            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;
                if (input.ToLower() == "exit")
                    break;
                try
                {
                    input = input.Replace(" ", "");
                    input = input.Replace(',', '.');
                    string result = Kambarova_libb.Kambarova.Parse(input);
                    Console.WriteLine($"= {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ошибка: деление на ноль");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine();
            }
        }
    }
}