using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//pu@ geting the index of char where the regex matched for the number

namespace Calculator
{
    public class Calculator
    {
        public float Add(float f1, float f2)
        {
            return f1 + f2;
        }

        public float Subtract(float f1, float f2)
        {
            return f1 - f2;
        }

        public float Calculate(String exp)
        {
            //// Check for parenthesis
            //int openParenIdx = 0;
            //int closeParenIdx = 0;
            //while (exp.Contains("("))
            //{ 
            //    // opening Parenthesis
            //    openParenIdx = exp.IndexOf("(");

            //    // closing Parenthesis
            //    int parenDepth = 0;
            //    char[] expCA = exp.ToCharArray();
            //    for (int i = 0; i < exp.Length; i++)
            //    {
            //        if (expCA[i] == '(')
            //        {
            //            parenDepth++;
            //        }
            //        else if (expCA[i] == ')')
            //        {
            //            parenDepth--;
            //        }

            //        if (expCA[i] == ')' && parenDepth == 0)
            //        {
            //            closeParenIdx = i;
            //            break;
            //        }
            //    }

            //    // new exp
            //    string expPref = exp.Substring(0, openParenIdx);
            //    string expSuff = exp.Substring(closeParenIdx + 1, exp.Length - closeParenIdx);
            //    exp = expPref + this.Calculate(exp.Substring(openParenIdx + 1, closeParenIdx - openParenIdx - 1)) + expSuff;
            //}

            // Tokenize numbers and operations/signs
            List<Token> tokens = new List<Token>();
            TokenType tokenType = new TokenType("", "");
            MatchCollection matches;

            // Tokenize
            List<TokenType> tokenTypes = new List<TokenType>();
            tokenTypes.Add(new TokenType("Number", @"\d+(\.\d+)?"));
            tokenTypes.Add(new TokenType("Operation", @"[/+|-]"));

            foreach (TokenType tt in tokenTypes)
            {
                matches = Regex.Matches(exp, tt.Pattern);
                foreach (Match m in matches)
                {
                    tokens.Add(new Token(m.ToString(), tt, m.Index));
                }
            }

            // Sort tokens by Index
            tokens = tokens.OrderBy(x => x.Index).ToList();

            // Combine number tokens and sign tokens into entities
            for (int i = 0; i < tokens.Count; i++)
            { 
                if (i != tokens.Count)
                {
                    if (tokens[i].Value == "-")
                    { 
                        tokens
                    }
                }
            }

                // Display Tokens!
                if (tokens.Count > 0)
                {
                    Console.WriteLine("Tokens:");
                    for (int i = 0; i < tokens.Count; i++)
                    {
                        Console.WriteLine(i.ToString() + ": [" + tokens[i].Index + "] (" + tokens[i].Type.Name + "|" + tokens[i].Type.Pattern + ") " + tokens[i].Value);
                    }
                }
                else
                {
                    Console.WriteLine("No tokens were found :(");
                }

            // TODO: Add signs to tokens (+/-)
            // get sum of signed tokens (not ready for multiply/divide yet)

            return float.Parse("0"); // should be actual return NOT HARDCODED

        }
    }

    public class Token
    {
        public string Value;
        public TokenType Type;
        public int Index;
        public Token(string value, TokenType type, int index)
        {
            this.Value = value;
            this.Type = type;
            this.Index = index;
        }
    }

    public class TokenType
    {
        public string Name;
        public string Pattern;
        public TokenType(string name, string pattern)
        {
            this.Name = name;
            this.Pattern = pattern;
        }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nEnter expression:");
                string exp = Console.ReadLine();
                Calculator calc = new Calculator();
                calc.Calculate(exp);
            }
        }
    }
}
