using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_no16
{
    public static class FixConverter
    {
	    private static readonly char[] _operators = { '*', '-', '+', '/', '^' };

	    private static int Precision(char charOperator)
	    {
		    switch (charOperator)
		    {
			    case '+':
			    case '-':
				    return 1;

			    case '*':
			    case '/':
				    return 2;

			    case '^':
				    return 3;
		    }
		    return 0;
		}

	    public static string PostfixToInfix(string postfix)
	    {
		    var s = new Stack<string>();

		    foreach (var c in postfix)
		    {
			    if (_operators.Contains(c))
			    {
				    var b = s.Pop();
				    var a = s.Pop();
				    s.Push($"({a}{c}{b})");
			    }
			    else
			    {
				    s.Push(c.ToString());
			    }
		    }

		    return s.Pop();
	    }

	    public static string InfixToPostfix(string infix)
	    {
            var result = "";

            var stack = new Stack<char>();

            foreach (var c in infix)
            {
                if (char.IsLetterOrDigit(c))
                    result += c;

                else if (c == '(')
                    stack.Push(c);

                else if (c == ')')
                {
                    while (stack.Count > 0 &&
                           stack.Peek() != '(')
                        result += stack.Pop();

                    if (stack.Count > 0 && stack.Peek() != '(')
                        throw new ArgumentException(nameof(infix));
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 &&
                           Precision(c) <= Precision(stack.Peek()))
                        result += stack.Pop();
                    stack.Push(c);
                }
            }

            while (stack.Count > 0)
                result += stack.Pop();

            return result;
        }

	    public static string PrefixToInfix(string prefix)
	    {
			var stack = new Stack<string>();
			var l = prefix.Length;
			for (var i = l - 1; i >= 0; i--)
			{
				var c = prefix[i];
				if (_operators.Contains(c))
				{
					var op1 = stack.Pop();
					var op2 = stack.Pop();

					var temp = "(" + op1 + c + op2 + ")";
					stack.Push(temp);
				}
				else
					stack.Push(c + "");
			}
			return stack.Pop();
		}

	    public static string InfixToPrefix(string infix)
	    {
		    var reversedArray = infix.Reverse().ToArray();

			for (var i = 0; i < infix.Length; i++)
			{
				if (reversedArray[i] == '(')
				{
					reversedArray[i] = ')';
					i++;
				}
				else if (infix[i] == ')')
				{
					reversedArray[i] = '(';
					i++;
				}
			}

			var prefix = InfixToPostfix(String.Concat(reversedArray));
			var result = String.Concat(prefix.Reverse());
			return result;
		}
	}
}
