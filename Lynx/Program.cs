using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lynx
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //var debug = false;

            //if (debug)
            //{
            //    var output = new StreamWriter(Console.OpenStandardOutput())
            //    {
            //        AutoFlush = true
            //    };

            //    Console.SetOut(output);

            //    var listener = new TextWriterTraceListener(output);
            //    Debug.AutoFlush = true;
            //    Debug.Listeners.Add(listener);
            //}

//            var code =
//@"2 For
//	2 For
//		""x: {@1}, y: {0}"" Format
//        WriteLine
//    ;
//;
//PopAll";

            var code = "2f2f\"x: {@1}, y: {0}\"$l;;ˇ";

            var lynxLang = new LynxLanguageProvider();
            var verbLynx = new VerboseLynxLanguageProvider();
            var assembly = lynxLang.Compile(code);

            var runtime = new LynxRuntime();
            var result = runtime.Execute(assembly);

            var gc = lynxLang.GenerateCode(assembly);

            Console.WriteLine(gc);

            var vgc = verbLynx.GenerateCode(assembly);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(vgc);

            Console.ReadKey();
        }
    }
}
