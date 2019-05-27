namespace Barker.Calculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Parser
    {
        public static decimal Parse(string Expression)
        {            
            var stack = new Stack<string>();
            
            string value = "";
            
            for (int i = 0; i < Expression.Length; i++)
            {
                string s = Expression.Substring(i, 1);
                char chr = s.ToCharArray()[0];

                if (!char.IsDigit(chr) && chr != '.' && value != "")
                {
                    stack.Push(value);
                    value = "";
                }

                string[] Operands = { "+", "-", "*", "/" };

                if (Operands.Contains(s))
                {
                    stack.Push(s);
                }
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += s;

                    if (value.Split('.').Length > 2)
                        throw new ParserInvalidExpressionException("Invalid decimal");

                    if (i == (Expression.Length - 1))                    
                    {
                        stack.Push(value);
                    }

                }
                else
                    throw new ParserInvalidExpressionException("Invalid character");

            }

            decimal result = 0;
            while (stack.Count >= 3)
            {
                try
                {
                    decimal right = Convert.ToDecimal(stack.Pop());
                    string op = stack.Pop();
                    decimal left = Convert.ToDecimal(stack.Pop());

                    if (op == "+") result = left + right;
                    else if (op == "-") result = left - right;
                    else if (op == "*") result = left * right;
                    else if (op == "/") result = left / right;
                }
                catch (DivideByZeroException)
                {
                    throw new ParserInvalidExpressionException("DIVIDE BY ZERO");
                }
                catch (Exception ex)
                {
                    throw new ParserInvalidExpressionException($"ERROR: {ex}");
                }
                finally
                {
                    stack.Push(result.ToString());
                }
            }

            return Convert.ToDecimal(stack.Pop());
        }
    }
}
