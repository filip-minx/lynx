using System;

namespace Lynx
{
    public class LynxLanguageProvider : ILanguageProvider
    {
        ICodeParser parser = new CodeParser();

        public LynxAssembly Compile(string code)
        {
            var tokens = parser.Parse(code);

            var assembly = new LynxAssembly(tokens);

            return assembly;
        }

        public string GenerateCode(LynxAssembly assembly)
        {
            throw new NotImplementedException();
        }
    }
}
