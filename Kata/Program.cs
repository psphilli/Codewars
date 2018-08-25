using System;
using System.Linq;

namespace Codewars
{
    public class Kata
    {
        #region UpdateLight

        public static string UpdateLight(string current)
        {
            switch (current)
            {
                case "green":
                    return "yellow";
                case "yellow":
                    return "red";
                case "red":
                    return "green";
                default:
                    throw new ArgumentException($"Unexpected {nameof(current)} value: {current}");
            }
        }

        #endregion

        #region Greet

        public static string Greet() => "hello world!";

        #endregion

        #region GetMiddle

        public static string GetMiddle(string s)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentException($"{nameof(s)} must not be null or empty string");

            var offset = (1 == s.Length % 2) ? 0 : 1;
            return s.Substring((s.Length / 2) - offset, 1 + offset);
        }

        #endregion

        #region CheckIfFlush

        /// <summary>
        /// https://www.codewars.com/kata/determine-if-the-poker-hand-is-flush/train/csharp
        /// </summary>
        public static bool CheckIfFlush(string[] cards)
        {
            if ((cards?.Count() ?? 0) != 5)
                throw new ArgumentException($"{nameof(cards)} must contain 5 elements");

            var suit = cards[0].Substring(cards[0].Length - 1);
            return !cards.Any(a => !a.EndsWith(suit));
        }

        #endregion

        #region SortArray

        /// <summary>
        /// https://www.codewars.com/kata/sort-the-odd/train/csharp
        /// </summary>
        public static int[] SortArray(int[] array)
        {
            if (array == null)
                throw new ArgumentException($"{nameof(array)} must not be null");

            var oddsSorted = array.Where(w => (w % 2) != 0).OrderBy(o => o);
            var idx = 0;
            return array.Select(s => 
            { 
                    if ((s % 2) != 0)
                        return oddsSorted.ElementAt(idx++);
                    return s;
            }).ToArray();
        }

        #endregion


        static void Main(string[] args)
        {
            //Console.WriteLine($"green -> {UpdateLight("green")}");
            //Console.WriteLine($"{greet()}");
            //Console.WriteLine($"{GetMiddle("test")}");
            //Console.WriteLine($"{Kata.CheckIfFlush(new string[] {"AS", "3S", "9S", "KS", "4S"})}");
            Console.WriteLine(String.Join(",", Kata.SortArray(new int[] {5, 3, 2, 8, 1, 4}).Select(s => s.ToString())));

            //Console.ReadKey();
        }
    }
}
