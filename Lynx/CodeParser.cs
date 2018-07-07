using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lynx
{
    class CodeParser : ICodeParser
    {
        private static Regex operationPattern = new Regex(@"\s*(?!""|\.|\s)\D");
        private static Regex integerPattern = new Regex(@"\s*\d+(?!\.)");
        private static Regex floatPattern = new Regex(@"\s*\d*\.\d*");
        private static Regex stringPattern = new Regex(@"\s*([""'])((\\{2})*|(.*?[^\\](\\{2})*))\1");
        private static Regex whiteSpaceRegex = new Regex(@"(\s)");

        private int position;
        private string code;

        public IEnumerable<Token> Parse(string code)
        {
            this.code = code;
            position = 0;

            while (position != code.Length)
            {
                if (IsNext(whiteSpaceRegex))
                {
                    Read(whiteSpaceRegex);
                }

                if (IsNext(operationPattern, out var operationMatch))
                {
                    yield return new OperationToken(Read(operationMatch));
                }
                else
                {
                    if (IsNext(integerPattern, out var integerMatch))
                    {
                        yield return new ValueToken(Read(integerMatch), ValueType.Integer);
                    }

                    else if (IsNext(floatPattern, out var floatMatch))
                    {
                        var value = Read(floatMatch);
                        if (value == ".") value = "0.0";

                        yield return new ValueToken(value, ValueType.Float);
                    }

                    else if (IsNext(stringPattern, out var stringMatch))
                    {
                        var value = Read(stringMatch);

                        yield return new ValueToken(value.Substring(1, value.Length - 2), ValueType.String);
                    }
                }
            }
        }

        public IEnumerable<Token> ParseFile(string path)
        {
            return null;
        }

        private char Peek()
        {
            return code[position];
        }

        private string ReadOperation()
        {
            return code[position++].ToString();
        }

        private bool IsNext(Regex regex, out Match match)
        {
            match = regex.Match(code, position);

            return match.Index == position && match.Success;
        }

        private bool IsNext(Regex regex)
        {
            return regex.IsMatch(code, position);
        }

        private string Read(Regex regex)
        {
            var match = regex.Match(code, position);

            position += match.Length;

            return match.Value.Trim();
        }

        private string Read(Match match)
        {
            if (!match.Success)
            {
                throw new InvalidOperationException("Reading unsuccessful match.");
            }

            position += match.Length;

            return match.Value.Trim();
        }
    }
}
