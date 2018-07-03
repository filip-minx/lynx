namespace Lynx
{
    public interface ILanguageProvider
    {
        LynxAssembly Compile(string code);
        string GenerateCode(LynxAssembly assembly);
    }
}
