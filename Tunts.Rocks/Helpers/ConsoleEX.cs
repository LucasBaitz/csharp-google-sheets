
namespace Tunts.Rocks.Helpers
{
    public static class ConsoleEX
    {
        public static void WriteLineWithColor(string text = "", ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            ResetColor();
        }

        private static void ResetColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
