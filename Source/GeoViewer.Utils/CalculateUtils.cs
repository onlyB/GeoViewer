/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GeoViewer.Utils
{
    public static class CalculateUtils
    {
        public static decimal Linear(decimal vi, decimal c0, decimal c1)
        {
            return c0 + c1 * vi;
        }

        public static double ArcToLengthDegree(double Vi, double Length)
        {
            return Length * Math.Sin(Vi * Math.PI / 180);
        }

        public static double ArcToLengthRadian(double Vi, double Length)
        {
            return Length * Math.Sin(Vi);
        }

        public static double Polynomial(double Vi, double C0, double C1, double C2, double C3, double C4, double C5)
        {
            return C0 + C1 * Vi + Math.Pow(Vi, 2) * C2 + Math.Pow(Vi, 3) * C3 + Math.Pow(Vi, 4) * C4 + Math.Pow(Vi, 5) * C5;
        }

        public static double TemperatureComp(double Vi, double Tk, double Ti, double Tc, double C0, double C1, double C2, double C3, double C4, double C5)
        {
            double V1 = Vi * (1 - Tk * (Tc - Ti));
            return C0 + C1 * V1 + Math.Pow(V1, 2) * C2 + Math.Pow(V1, 3) * C3 + Math.Pow(V1, 4) * C4 + Math.Pow(V1, 5) * C5;
        }

        public static double VwLinear(double Tk, double Ti, double Tc, double Ck, double Li, double Lm, double Lc, double Bi, double Bc, double D, double E)
        {
            return (Ck * (Li * Lm - Lc) - Tk * (Ti - Tc) + D * (Bi - Bc) + E);
        }

        public static double VwPoly(double Tk, double Ti, double Tc, double A, double B, double Lm, double Lc, double Bi, double Bc, double C, double D, double E)
        {
            return A * Math.Pow((Lc * Lm), 2) + B * (Lc * Lm) + C + Tk * (Tc - Ti) - D * (Bc - Bi) + E;
        }



        #region Calculate Infix expression

        private static int GetPriority(string op)
        {
            if (op == "^")
                return 3;
            if (op == "*" || op == "/" || op == "%")
                return 2;
            if (op == "+" || op == "-")
                return 1;
            return 0;
        }

        private static void FormatExpression(ref string expression)
        {
            expression = expression.Replace(" ", "");
            expression = Regex.Replace(expression, @"\+|\-|\*|\/|\%|\^|\)|\(", match => " " + match.Value + " ");
            expression = expression.Replace("  ", " ");
            expression = expression.Trim();
        }

        private static bool IsOperator(string str)
        {
            return Regex.Match(str, @"\+|\-|\*|\/|\%|\^").Success;
        }

        private static bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\-?\d?\.?\d+$|^x$").Success;
        }

        public static string Infix2Postfix(string infix)
        {
            FormatExpression(ref infix);

            IEnumerable<string> str = infix.Split(' ');
            Stack<string> stack = new Stack<string>();
            StringBuilder postfix = new StringBuilder();

            foreach (string s in str)
            {
                if (IsOperand(s))
                    postfix.Append(s).Append(" ");
                else if (s == "(")
                    stack.Push(s);
                else if (s == ")")
                {
                    string x = stack.Pop();
                    while (x != "(")
                    {
                        postfix.Append(x).Append(" ");
                        x = stack.Pop();
                    }
                }
                else// IsOperator(s)
                {
                    while (stack.Count > 0 && GetPriority(s) <= GetPriority(stack.Peek()))
                        postfix.Append(stack.Pop()).Append(" ");
                    stack.Push(s);
                }
            }

            while (stack.Count > 0)
                postfix.Append(stack.Pop()).Append(" ");

            return postfix.ToString();
        }

        public static double CalculatePostfix(string postfix)
        {
            Stack<double> stack = new Stack<double>();
            postfix = postfix.Trim();

            IEnumerable<string> enumer = postfix.Split(' ');

            foreach (string s in enumer)
            {
                bool isOperator = IsOperator(s);
                if (isOperator)
                {
                    double x = stack.Pop();
                    double y = stack.Pop();

                    switch (s)
                    {
                        case "+": y += x; break;
                        case "-": y -= x; break;
                        case "*": y *= x; break;
                        case "/": y /= x; break;
                        case "%": y %= x; break;
                        case "^": y = Math.Pow(y, x); break;
                    }
                    stack.Push(y);
                }
                else
                {
                    stack.Push(s.ToDoubleTryParse());
                }
            }
            return stack.Pop();
        }

        public static double CalculateInfixExpression(string expression, string parameter, object parameterValue)
        {
            string postfix = Infix2Postfix(expression).Replace(parameter, parameterValue.ToString());
            return CalculatePostfix(postfix);
        }
        #endregion

    }
}
