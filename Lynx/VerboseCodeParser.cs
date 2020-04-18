using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lynx
{
    class VerboseCodeParser : ICodeParser
    {
        private static Regex operationPattern = new Regex(@"\s*(?!""|\.|\s)\D");
        private static Regex integerPattern = new Regex(@"^\s*\d+(?!\.)$");
        private static Regex floatPattern = new Regex(@"\s*\d*\.\d*");
        private static Regex stringPattern = new Regex(@"\s*([""'])((\\{2})*|(.*?[^\\](\\{2})*))\1");

        private Regex tokenParsingRegex = new Regex(@"\d*\.\d*|\d+(?!\.)|\w+|([""'])((\\{2})*|(.*?[^\\](\\{2})*))\1|;");

        public IEnumerable<Token> Parse(string code)
        {
            var matches = tokenParsingRegex.Matches(code);

            foreach (Match match in matches)
            {


                if (integerPattern.Match(match.Value).Success)
                {
                    yield return new ValueToken(match.Value, ValueType.Integer);
                }
                else if (floatPattern.Match(match.Value).Success)
                {
                    var value = match.Value;
                    if (value == ".") value = "0.0";

                    yield return new ValueToken(value, ValueType.Float);
                }
                else if (stringPattern.Match(match.Value).Success)
                {
                    yield return new ValueToken(match.Value.Substring(1, match.Value.Length - 2), ValueType.String);
                }
                else if (operationPattern.Match(match.Value).Success)
                {
                    var operation = OperationsRegister.GetOperationVerbose(match.Value);
                    yield return new OperationToken(operation.Identifier);
                }
            }
        }
    }
}
