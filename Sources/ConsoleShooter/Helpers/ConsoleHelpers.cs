using System.Text;

namespace ConsoleShooter.Helpers
{
    public class ConsoleHelpers
    {
        public static string ReadNonEmptyString(string prompt)
        {
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine(prompt + ':');
                string result = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    return result.Trim();
                }
            }
        }

        public static int ReadPositiveNumber(string prompt, int maxValue = int.MaxValue)
        {
            while (true)
            {
                Console.WriteLine(prompt + ':');
                string input = Console.ReadLine()!;
                bool parsed = int.TryParse(input, out int result);
                if (!parsed)
                {
                    continue;
                }
                if (result <= 0 || result > maxValue)
                {
                    continue;
                }
                return result;
            }
        }

        internal static TItem SelectObject<TItem>(IEnumerable<TItem> objects) where TItem : class
        {
            Console.WriteLine("Select " + typeof(TItem).Name + ':');
            int counter = 0;
            foreach (var item in objects)
            {
                counter++;
                Console.WriteLine("{0}. {1}", counter, item.ToString());
            }
            int selected = ReadPositiveNumber("Type number of line", objects.Count());
            return objects.ElementAt(selected - 1);
        }
    }
}