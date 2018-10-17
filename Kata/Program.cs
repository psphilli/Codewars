using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Codewars
{
    public class Kata
    {
        #region ValidatePin

        /// <summary>
        /// https://www.codewars.com/kata/regex-validate-pin-code/train/csharp
        /// </summary>
        public static bool ValidatePin(string pin)
        {
            var pattern = @"^(\d{4})(\d{2})?$";
            return Regex.Match(pin, pattern).Success;
        } 

        #endregion

        #region Revrot

        /// <summary>
        /// https://www.codewars.com/kata/56b5afb4ed1f6d5fb0000991/train/csharp
        /// </summary>
        public static string RevRot(string strng, int sz)
        {
            if (sz <= 0 || sz > (strng?.Length ?? 0))
                return string.Empty;

            if (!Regex.IsMatch(strng, @"^[0-9]*$"))
                throw new ArgumentException($"{nameof(strng)} must only contain numeric characters");

            // Strip of extraneous chars that appear after chunk(s)
            var str = strng.Substring(0, ((strng.Length / sz) * sz ));

            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i += sz)
            {
                var chunk = str.Substring(i, sz);

                // Calculate sum of qubes for digits in the chunck size
                var sumOfQubes = chunk.ToCharArray().Select(s => Math.Pow(s % 10, 3)).Sum();

                if ((sumOfQubes % 2) == 0)
                {
                    // Reverse
                    sb.Append(new string(chunk.Reverse().ToArray()));
                }
                else
                {
                    // Rotate
                    if (chunk.Length > 1)
                    {
                        sb.Append(chunk.Substring(1));
                        sb.Append(chunk.Substring(0, 1));
                    }
                    else
                        // jic sz == 1
                        sb.Append(chunk);
                }
            }
        
            return sb.ToString();
        }

        #endregion

        #region IsPrime

        /// <summary>
        /// https://www.codewars.com/kata/is-a-number-prime
        /// </summary>
        public static bool IsPrime(int n)
        {
            //https://stackoverflow.com/questions/1801391/what-is-the-best-algorithm-for-checking-if-a-number-is-prime
            if (n <= 1)
                return false;
            if (n == 2 || n == 3)
                return true;
            if (n % 2 == 0)
                return false;
            if (n % 3 == 0)
                return false;

            var i = 5;
            var w = 2;

            while (i * i <= n)
            {
                if (n % i == 0)
                    return false;

                i += w;
                w = 6 - w;
            }

            return true;
        }

        #endregion

        #region Bouncing Balls

        /// <summary>
        /// https://www.codewars.com/kata/bouncing-balls
        /// </summary>
        public static int bouncingBall(double h, double bounce, double window) 
        {
            // initial drop height must not be zero
            if (h == 0)
                return -1;

            // bounce must have fractional value between zero and one
            if (bounce <= 0 || bounce >= 1)
                return -1;

            // window must be below initial drop height
            if (window >= h)
                return -1;

            return (int)(Math.Ceiling((Math.Log(window / h) / Math.Log(bounce))) * 2) - 1;
        }

        #endregion

        #region Timed Reading

        /// <summary>
        /// https://www.codewars.com/kata/simple-fun-number-40-timed-reading
        /// </summary>
        public static int TimedReading(int MaxLength, string text) 
        {
            return Regex.Replace(text, @"\p{P}", "")
                .Split(" ")
                .Where(w => w.Length > 0 && w.Length <= MaxLength)
                .Count();
        }

        #endregion

        #region RGB To Hex Conversion

        /// <summary>
        /// https://www.codewars.com/kata/rgb-to-hex-conversion/train/csharp
        /// </summary>
        public static string Rgb(int r, int g, int b) 
        {
            byte[] ba = new byte[3];
            var idx = 0;
            foreach(var i in new int[] {r, g, b})
            {
                b = i < 0 ? 0 : i; 
                b = b > 255 ? 255 : b;
                ba[idx++] = (byte)b;
            }

            return $"{String.Concat(ba.Select(e =>e.ToString("X2")))}";
        }

        #endregion

        #region Human Readable Time

        /// <summary>
        /// https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
        /// </summary>
        public static string GetReadableTime(int seconds) 
        {
            if (0 > seconds || seconds > 359999 )
                throw new ArgumentException($"{nameof(seconds)} must be greater than or equal 0 and less than or equal to 359999");

            int hh = seconds / (60 * 60);
            int mm = (seconds - (hh * 60 * 60)) / 60;
            int ss = seconds - (hh * 60 * 60) - (mm * 60 * 60) / 60;

            return $"{hh:D2}:{mm:D2}:{ss:D2}";
        }

        #endregion

        static void Main(string[] args)
        {
            //Console.WriteLine($"{ValidatePin("92495")}");
            //Console.WriteLine($"{RevRot("9249590956065", 4)}");
            //Console.WriteLine($"{bouncingBall(109, 0.75, 1.09)}");
            //Console.WriteLine($"{TimedReading(1,"...")}");
            //Console.WriteLine($"{Rgb(257,-10,254)}");
            Console.WriteLine($"{GetReadableTime(359999)}");
            //Console.WriteLine($"{GetReadableTime(5)}");
            //Console.ReadKey();
        }
    }
}
