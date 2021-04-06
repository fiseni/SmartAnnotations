using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace SmartAnnotations.Internal
{
    // Mainly used for debugging.
    [ExcludeFromCodeCoverage]
    internal static class Utils
    {
        internal static void AttachDebugger()
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
        }

        internal static byte[] LoadFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            byte[] buffer = new byte[(int)fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            return buffer;
        }

        internal static string AddIndent(ushort count)
        {
            return new string(' ', count * 4);
        }

        // Used for debugging and tests.
        internal static void WriteToFile(string filename, IEnumerable<string> text)
        {
            var path = @"c:\temp";
            File.WriteAllText($"{path}\\{filename}.txt", string.Join(Environment.NewLine, text));
        }
        internal static void WriteToFile(string filename, string[] text)
        {
            var path = @"c:\temp";
            File.WriteAllText($"{path}\\{filename}.txt", string.Join(Environment.NewLine, text));
        }
        internal static void WriteToFile(string filename, string text)
        {
            var path = @"c:\temp";
            File.WriteAllText($"{path}\\{filename}.txt", text);
        }
    }
}
