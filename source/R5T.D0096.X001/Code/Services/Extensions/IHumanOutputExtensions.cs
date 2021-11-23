using System;

using R5T.D0096;


namespace System
{
    public static class IHumanOutputExtensions
    {
        public static void WriteLine(this IHumanOutput humanOutput,
            string text,
            string newLine)
        {
            var line = text + newLine;

            humanOutput.Write(line);
        }

        public static void WriteLine(this IHumanOutput humanOutput,
            string line)
        {
            humanOutput.WriteLine(line, Environment.NewLine);
        }
    }
}
