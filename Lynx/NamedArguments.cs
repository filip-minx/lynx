using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lynx
{
    public static class NamedArguments
    {
        private static Dictionary<string, string> arguments = new Dictionary<string, string>();

        static NamedArguments()
        {
            ParseArguments();
        }

        private static void ParseArguments()
        {
            var namedArgumentRegex = new Regex(@"^\s*-\s*.+");

            var args = Environment.GetCommandLineArgs();

            string name, value;

            for (int i = 0; i < args.Length; i++)
            {
                name = args[i];

                if (namedArgumentRegex.IsMatch(name))
                {
                    name = name.Substring(name.IndexOf('-') + 1);
                    value = null;

                    if ((i < args.Length - 1) && (!namedArgumentRegex.IsMatch(args[i + 1])))
                    {
                        value = args[i + 1];
                        i++;
                    }
                    else
                    {
                        value = "true";
                    }

                    arguments[name] = value;
                }
            }
        }

        public static bool TryGetAs<T>(string argName, out T value)
        {
            if (!arguments.TryGetValue(argName, out var strValue))
            {
                value = default(T);
                return false;
            }

            value = (T)Convert.ChangeType(strValue, typeof(T));
            return true;
        }
    }
}
