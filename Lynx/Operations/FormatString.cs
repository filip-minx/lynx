using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lynx.Operations
{
    public class FormatString : Operation
    {
        private static Regex formatRegex = new Regex(@"{(@?(\d+))}");

        private static string PeekPattern = "@";

        public override string Identifier => "$";

        public override int Arity => 1;

        public override string VerboseIdentifier => "Format";

        public override object[] Execute(Arguments arguments, LynxRuntime runtime)
        {
            var str = arguments.Get<string>(0);

            var matches = formatRegex.Matches(str);

            var formatPatterns = new SortedList<int, string>();
            var formatArguments = new object[matches.Count];

            foreach (Match match in matches)
            {
                var pattern = match.Groups[1].Value;

                int index;

                if (pattern.StartsWith(PeekPattern))
                {
                    index = int.Parse(pattern.Substring(1));
                }
                else
                {
                    index = int.Parse(pattern);
                }

                if (!formatPatterns.ContainsKey(index))
                {
                    formatPatterns.Add(index, pattern);
                }
            }

            for (int i = formatPatterns.Count - 1; i >= 0; i--)
            {
                var pattern = formatPatterns[i];

                var peek = pattern.StartsWith(PeekPattern);

                int index = int.Parse(peek ? pattern.Substring(1) : pattern);

                formatArguments[index] = peek ? runtime.Stack[index] : runtime.Stack.PopAt(index);
            }

            str = formatRegex.Replace(str, "{$2}");

            var formatted = string.Format(str, formatArguments);

            return new object[] { formatted };
        }
    }
}
