namespace Barker.Calculator.Core
{
    using System;
    using System.Collections.Generic;

    public static class Parser
    {
        public static decimal Parse(string Expression)
        {
            if (!ValidExpression(Expression))
                throw new ParserInvalidExpressionException(Expression);
            Stack<String> stack = new Stack<String>();
            
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

                if (s.Equals("("))
                {

                    string innerExp = "";
                    i++; //Fetch Next Character
                    int bracketCount = 0;
                    for (; i < Expression.Length; i++)
                    {
                        s = Expression.Substring(i, 1);

                        if (s.Equals("("))
                            bracketCount++;

                        if (s.Equals(")"))
                            if (bracketCount == 0)
                                break;
                            else
                                bracketCount--;


                        innerExp += s;
                    }

                    stack.Push(Parse(innerExp).ToString());

                }
                else if (s.Equals("+")) stack.Push(s);
                else if (s.Equals("-")) stack.Push(s);
                else if (s.Equals("*")) stack.Push(s);
                else if (s.Equals("/")) stack.Push(s);
                else if (s.Equals("sqrt")) stack.Push(s);
                else if (s.Equals(")"))
                {
                }
                else if (char.IsDigit(chr) || chr == '.')
                {
                    value += s;

                    if (value.Split('.').Length > 2)
                        throw new ParserInvalidExpressionException("Invalid decimal.");

                    if (i == (Expression.Length - 1))
                        stack.Push(value);

                }
                else
                    throw new ParserInvalidExpressionException("Invalid character.");

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
                catch (DivideByZeroException ex)
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

        private static bool ValidExpression(string expression)
        {
            return true;            
        }
    }
}
