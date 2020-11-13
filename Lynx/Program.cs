using System;
using System.IO;

namespace Lynx
{
    class Program
    {
        static void Main(string[] args)
        {
            if (TryPrintOperations())
            {
                Environment.Exit(0);
            }

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
            if (NamedArguments.TryGetAs("CodeFile", out string codeFile))
            {
                return File.ReadAllText(codeFile);
            }

            if (NamedArguments.TryGetAs("CodeText", out string codeText))
            {
                return codeText;
            }

            Console.WriteLine("Missing code argument. Use either \"--CodeFile\" or \"--CodeText\" argument to input the code.");
            Environment.Exit(1);
            return null;
        }

        private static bool TryPrintOperations()
        {
            if (NamedArguments.GetAs("PrintOperations", false))
            {
                foreach (var o in OperationsRegister.Operations)
                {
                    Console.WriteLine($"{o.Identifier} ({o.VerboseIdentifier}), Name: {o.GetType().Name}, Arity: {o.Arity}");
                }

                return true;
            }

            return false;
        }
    }
}
