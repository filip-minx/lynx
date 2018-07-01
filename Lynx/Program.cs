using System;
using System.Diagnostics;
using System.IO;

namespace Lynx
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var debug = false;

            if (debug)
            {
                var output = new StreamWriter(Console.OpenStandardOutput())
                {
                    AutoFlush = true
                };

                Console.SetOut(output);

                var listener = new TextWriterTraceListener(output);
                Debug.AutoFlush = true;
                Debug.Listeners.Add(listener);
            }

            var interpreter = new Interpreter();

            var result = interpreter.Execute("2f2f\"x:{@1} y:{0}\"$l;;ˇ");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
