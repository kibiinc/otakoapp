using System;
namespace otako
{
    public class Logger
    {
        public static void Log(string Source, string Message, ConsoleColor Color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = Color;
            Console.Write(Source + " ");
            Console.ResetColor();
            Console.Write(Message + "\n");
        }
    }
}