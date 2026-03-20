using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kambarova_libb
{
    public class Kambarova
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль");
            return a / b;
        }
        public static double Power(double a, double b) => Math.Pow(a, b);

        public static double Execute(double x, char op, double y)
        {
            return op switch
            {
                '+' => Add(x, y),
                '-' => Subtract(x, y),
                '*' => Multiply(x, y),
                '/' => Divide(x, y),
                '^' => Power(x, y),
                _ => throw new ArgumentException($"Неизвестный оператор: {op}")
            };
        }

        public static string Parse(string s)
        {
            try
            {
                s = s.Replace(" ", "");
                double r = EvaluateExpression(s);
                return r.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (DivideByZeroException)
            {
                return "Ошибка";
            }
            catch (Exception)
            {
                return "Ошибка вычисления";
            }
        }

        private static double EvaluateExpression(string s)
        {
            s = RemoveSpaces(s);
            while (s.Contains("("))
            {
                int i = s.LastIndexOf('(');
                int j = s.IndexOf(')', i);
                if (j == -1) throw new ArgumentException("Неверные скобки");
                string sub = s.Substring(i + 1, j - i - 1);
                double subRes = EvaluateExpression(sub);
                s = s.Substring(0, i) + subRes.ToString(System.Globalization.CultureInfo.InvariantCulture) + s.Substring(j + 1);
            }
            return EvaluateSimple(s);
        }

        private static double EvaluateSimple(string s)
        {
            s = ProcessOperator(s, '^');
            s = ProcessOperator(s, '*', '/');
            s = ProcessOperator(s, '+', '-');
            return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        }

        private static string ProcessOperator(string s, params char[] ops)
        {
            int i = 0;
            while (i < s.Length)
            {
                if (Array.IndexOf(ops, s[i]) != -1)
                {
                    int l = i - 1;
                    while (l >= 0 && (char.IsDigit(s[l]) || s[l] == '.'))
                        l--;
                    l++;
                    int r = i + 1;
                    while (r < s.Length && (char.IsDigit(s[r]) || s[r] == '.'))
                        r++;
                    double a = double.Parse(s.Substring(l, i - l),
                        System.Globalization.CultureInfo.InvariantCulture);
                    double b = double.Parse(s.Substring(i + 1, r - i - 1),
                        System.Globalization.CultureInfo.InvariantCulture);
                    double res = Execute(a, s[i], b);
                    string resultStr = res.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    s = s.Substring(0, l) + resultStr + s.Substring(r);
                    i = l + resultStr.Length - 1;
                }
                i++;
            }
            return s;
        }

        private static string RemoveSpaces(string s)
        {
            return s.Replace(" ", "");
        }
    }
}
