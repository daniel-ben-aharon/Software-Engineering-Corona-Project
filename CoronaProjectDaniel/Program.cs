using System;
using System.IO;

namespace CoronaProjectDaniel
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " <commandFileName>");
                return;
            }
            try
            {
                FileStream stream = File.OpenRead(args[0]);
                Interpreter.Interpret(stream);
                stream.Close();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Can't open file " + args[0]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
