using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Lynx
{
    class Program
    {
        private static LynxLanguageProvider ConciseLanguageProvider = new LynxLanguageProvider();
        private static VerboseLynxLanguageProvider VerboseLanguageProvider = new VerboseLynxLanguageProvider();

        static void Main(string[] args)
        {
            if (TryPrintOperations() || TryConvertCode())
            {
                Environment.Exit(0);
            }

            var languageProvider = GetLanguageProvider();
            var code = GetCode();
            
            var runtime = new LynxRuntime();

            if (TryGetInput(out var input))
            {
                runtime.Execute(
                    languageProvider.Compile(Regex.Unescape(input)));
            }

            runtime.Execute(
                languageProvider.Compile(code));

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        private static ILanguageProvider GetLanguageProvider()
        {
            if (NamedArguments.GetAs("Verbose", false))
            {
                return VerboseLanguageProvider;
            }
            else
            {
                return ConciseLanguageProvider;
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
        
        private static bool TryConvertCode()
        {
            if (NamedArguments.GetAs("Convert", false))
            {
                var code = GetCode();
                var verbose = NamedArguments.GetAs("Verbose", false);

                if (verbose)
                {
                    Console.WriteLine(VerboseLanguageProvider.GenerateCode(ConciseLanguageProvider.Compile(code)));
                }
                else
                {
                    Console.WriteLine(ConciseLanguageProvider.GenerateCode(VerboseLanguageProvider.Compile(code)));
                }

                return true;
            }

            return false;
        }

        private static bool TryGetInput(out string input)
        {
            return NamedArguments.TryGetAs("InputText", out input)
                || NamedArguments.TryGetAs("InputFile", out input);
        }
    }
}
