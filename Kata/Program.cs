using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Codewars
{
    public class Kata
    {
        #region Mexican Wave

        /// <summary>
        /// https://www.codewars.com/kata/58f5c63f1e26ecda7e000029/train/csharp
        /// </summary>
        public List<string> wave(string str)
        {
            var list = new List<string>();
            if (String.IsNullOrEmpty(str))
                return list;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    continue;
                    
                var sb = new System.Text.StringBuilder(str);
                sb[i] = char.ToUpper(str[i]);
                list.Add($"{sb}");
            }

            return list;
        } 

        #endregion

        #region Weight for weight

        /// <summary>
        /// https://www.codewars.com/kata/55c6126177c9441a570000cc/train/csharp
        /// </summary>
        public static string orderWeight(string strng)
        {
            if (strng == null)
                throw new ArgumentException($"{nameof(strng)} cannot be null");
            if (strng.Length == 0)
                return strng;
            if (!Regex.IsMatch(strng, @"^[\d\s]+$"))
                throw new ArgumentException($"{nameof(strng)} contains invalid characters: '{strng}'");

            var weights = strng.Split(' ').ToList();
            weights.Sort((s1, s2) =>
            {
                var s1Sum = s1.Select(x => int.Parse(x.ToString())).Sum();
                var s2Sum = s2.Select(x => int.Parse(x.ToString())).Sum();
                if (s1Sum > s2Sum)
                    return 1;
                if (s1Sum < s2Sum)
                    return -1;

                // same sum value, now compare string value
                return String.CompareOrdinal(s1, s2);
            });

            return String.Join(" ", weights);
        }
        
        #endregion

        #region Moving Zeros To The End

        /// <summary>
        /// https://www.codewars.com/kata/55c6126177c9441a570000cc/train/csharp
        /// </summary>
        public static int[] MoveZeroes(int[] arr)
        {
            return arr.Where(w => w != 0).Concat(arr.Where(w => w == 0)).ToArray();
        }

        #endregion

        #region First Variation on Caesar Cipher

        /// <summary>
        /// https://www.codewars.com/kata/first-variation-on-caesar-cipher/train/csharp
        /// </summary>
        public static List<string> movingShift(string s, int shift)
        {
           var sShifted = new String(s
                .ToCharArray()
                .Select((c,i) =>  
                {
                    if (!Char.IsLetter(c))
                        return c;

                    var low = (c >= 'A' && c <= 'Z') ? 'A' : 'a';
                    var high = (c >= 'A' && c <= 'Z') ? 'Z' : 'z';
                    var cShifted = (int)c + (shift+i);
                    return cShifted > (int)high ? (char)(((cShifted - (int)low) % 26) + (int)low) : (char)cShifted;
                })
                .ToArray());

            // break into chunks
            var l = new List<string>();
            var chunkSize = (sShifted.Length / 5) + (sShifted.Length % 5 == 0 ? 0 : 1);
            for (int i = 0; i < 5; i++)
            {
                if (sShifted.Length - chunkSize*i > 0)
                    l.Add(sShifted.Substring(chunkSize*i, Math.Min(chunkSize, sShifted.Length - chunkSize*i)));
                else
                    l.Add(String.Empty);
            }
            return l;
        }

        public static string demovingShift(List<string> s, int shift)
        {
            return new String(String.Concat(s)
                .ToCharArray()
                .Select((c,i) =>  
                {
                    if (!Char.IsLetter(c))
                        return c;

                    var low = (c >= 'A' && c <= 'Z') ? 'A' : 'a';
                    var high = (c >= 'A' && c <= 'Z') ? 'Z' : 'z';

                    var cShifted = (int)c - (shift+i);
                    if (cShifted >= (int)low)
                        return (char)cShifted;

                    var cShiftedRotated = ((int)high + 1 - (((int)low - cShifted) % 26));
                    return (cShiftedRotated > (int)high) ? low : (char)cShiftedRotated;
                })
                .ToArray());
        }

        #endregion

        #region Maximum subarray sum

        /// <summary>
        /// https://www.codewars.com/kata/maximum-subarray-sum/train/csharp
        /// https://www.geeksforgeeks.org/largest-sum-contiguous-subarray
        /// </summary>
        public static int MaxSequence(int[] arr) { 
            int maxSoFar = 0;
            int maxEndingHere = 0;
                      
            Array.ForEach(arr, element =>
            {
                maxEndingHere = maxEndingHere + element;

                if (maxSoFar < maxEndingHere) 
                    maxSoFar = maxEndingHere; 
              
                if (maxEndingHere < 0) 
                    maxEndingHere = 0; 
            });

            return maxSoFar;
        }

        #endregion

        #region k-Primes

        /// <summary>
        /// https://www.codewars.com/kata/k-primes/train/csharp
        /// https://www.geeksforgeeks.org/k-primes-numbers-k-prime-factors-range
        /// </summary>        
        private static bool IsKPrime(int k, long number)
        {
            int primes = 0;
            for (int p = 2; p * p <= number && primes < k; ++p)
            {
                while (number % p == 0 && primes < k)
                {
                    number /= p;
                    ++primes;
                }
            }
            if (number > 1)
            {
                ++primes;
            }
            return primes == k;
        }

        public static long[] CountKprimes(int k, long start, long end) {
    
            // Store for kprimes
            var kPrimes = new List<long>();
            for(int i = 0; i < end - start + 1; i++)
            {
                if (IsKPrime(k, start + i))
                    kPrimes.Add(start + i); 
            }
                
            
            return kPrimes.ToArray();
        }

        public static int Puzzle(int s) 
        {
            const byte MIN_KPRIME_7 = 128;
            const byte MIN_KPRIME_3 = 8;
            const byte MIN_KPRIME_1 = 2;

            // Return zero if less than minimum realizable number
            if (s < MIN_KPRIME_7 + MIN_KPRIME_3 + MIN_KPRIME_1)  
                return 0;

            // Get the three sets of KPrimes for the given value
            var kPrimes1 = CountKprimes(1, 0, s);   
            var kPrimes3 = CountKprimes(3, 0, s);   
            var kPrimes7 = CountKprimes(7, 0, s);

            var count = 0;
            foreach (var kPrime7 in kPrimes7)
            {              
                for (int i = 0; i < kPrimes3.Length && s >= (kPrime7 + kPrimes3[i] + MIN_KPRIME_1); i++) 
                {
                    if (kPrimes1.Contains(s - kPrime7 - kPrimes3[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    
        #endregion

        #region Are they the "same"?

        /// <summary>
        /// https://www.codewars.com/kata/are-they-the-same/train/csharp
        /// </summary>        
        public static bool comp(int[] a, int[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;
 
            var list = new List<int>(b);
            for (int i = 0; i < a.Length; i++)
            {
                var idx = list.IndexOf(a[i]*a[i]);
                if (idx > -1)
                {
                    list.RemoveAt(idx);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    
        #endregion

        static void Main(string[] args)
        {
            //new Kata().wave("two words").ForEach(s => Console.WriteLine(s));
            //Console.WriteLine($"'{orderWeight("56 65 74 100 99 68 86 180 90")}'");
            //Console.WriteLine($"'{String.Join(' ', MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}))}'");
            //Console.WriteLine($"{String.Concat(movingShift("I should have known that you would have a perfect answer for me!!!", 1))}");
            //Console.WriteLine($"{demovingShift(movingShift("I should have known that you would have a perfect answer for me!!!", 2), 2)}");
            //Console.WriteLine($"{MaxSequence(new int[] { -2, -3, 4, -1, -2, 1, 5, -3 })}");
            //Console.WriteLine($"{String.Join(", ", CountKprimes(3, 0, 100))}");
            //Console.WriteLine($"{Puzzle(143)}");
            var a = new int[] {121, 144, 19, 161, 19, 144, 19, 11};
            var b = new int[] {11*11, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19};
            Console.WriteLine($"{comp(a,b)}");

            // Console.ReadKey()
        }
    }
}