using System;
using System.IO;

namespace Lynx
{
    class Program
    {
        static void Main(string[] args)
        {
            var languageProvider = GetLanguageProvider();
            var code = GetCode();

            var runtime = new LynxRuntime();

            runtime.Execute(
                languageProvider.Compile(code));
        }

        private static ILanguageProvider GetLanguageProvider()
        {
            if (NamedArguments.GetAs("Verbose", false))
            {
                return new VerboseLynxLanguageProvider();
            }
            else
            {
                return new LynxLanguageProvider();
            }
        }

        private static string GetCode()
        {
            if (!NamedArguments.TryGetAs("CodeFile", out string codeFile))
            {
                Console.WriteLine("Missing argument \"CodeFile\"");
                Environment.Exit(1);
            }

            return File.ReadAllText(codeFile);
        }
    }
}
