using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Codewars
{
    [TestFixture]
    class MexicanWaveTests
    {
        [TestCase]
        public void BasicTest1()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { "Hello", "hEllo", "heLlo", "helLo", "hellO" };
            Assert.AreEqual(result, kata.wave("hello"), "it should return '"+result+"'");
        }

        [TestCase]
        public void BasicTest2()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { "Codewars", "cOdewars", "coDewars", "codEwars", "codeWars", "codewArs", "codewaRs", "codewarS" };
            Assert.AreEqual(result, kata.wave("codewars"), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest3()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { };
            Assert.AreEqual(result, kata.wave(""), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest4()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { "Two words", "tWo words", "twO words", "two Words", "two wOrds", "two woRds", "two worDs", "two wordS" };
            Assert.AreEqual(result, kata.wave("two words"), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest5()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { " Gap ", " gAp ", " gaP " };
            Assert.AreEqual(result, kata.wave(" gap "), "it should return '" + result + "'");
        }
    }

    [TestFixture]
    public class WeightSortTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual("2000 103 123 4444 99", Kata.orderWeight("103 123 4444 99 2000"));
            Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", Kata.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
            Assert.AreEqual("100 180 90 56 65 74 68 86 99", Kata.orderWeight("56 65 74 100 99 68 86 180 90"));
        }
    }

    [TestFixture]
    public class MoveZeroesToTheEnd
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}, Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));
        }
    }

    [TestFixture]
    public class CaesarCipherTests {

        [Test]
        public void Test1() {
            string u = "I should have known that you would have a perfect answer for me!!!";
            Assert.AreEqual(u, Kata.demovingShift(Kata.movingShift(u, 1), 1));
        }
    }

    [TestFixture]
    public class MaxSequence
    {
        [Test]
        public void Test0()
        {
            Assert.AreEqual(0, Kata.MaxSequence(new int[0]));
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(6, Kata.MaxSequence(new int[]{-2, 1, -3, 4, -1, 2, 1, -5, 4}));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(0, Kata.MaxSequence(new int[]{-2, -1, -3, -4, -1, -2, -1, -5, -4}));
        }
    }
    
    [TestFixture]
    public static class KPrimesTests 
    {

        private static string Array2String( long[] list )
        {
            return "[" + string.Join(", ", list) + "]";
        }
        private static void testing(string actual, string expected) 
        {
            Assert.AreEqual(expected, actual);
        }
    
        [Test]
        public static void test1() 
        {        
            Console.WriteLine("Basic Tests CountKprimes");
            testing(Array2String(Kata.CountKprimes(2, 0, 100)), 
                    Array2String(new long[] 
                    {4, 6, 9, 10, 14, 15, 21, 22, 25, 26, 33, 34, 35, 38, 39, 46, 49, 51,
                    55, 57, 58, 62, 65, 69, 74, 77, 82, 85, 86, 87, 91, 93, 94, 95}));
            testing(Array2String(Kata.CountKprimes(3, 0, 100)), 
                    Array2String(new long[] 
                    {8, 12, 18, 20, 27, 28, 30, 42, 44, 45, 50, 52, 63, 66, 68, 70, 75, 76,
                    78, 92, 98, 99}));
            testing(Array2String(Kata.CountKprimes(5, 1000, 1100)), 
                    Array2String(new long[] 
                    {1020, 1026, 1032, 1044, 1050, 1053, 1064, 1072, 1092, 1100}));
            testing(Array2String(Kata.CountKprimes(5, 500, 600)), 
                    Array2String(new long[] 
                    {500, 520, 552, 567, 588, 592, 594}));
        }
    }

    [TestFixture]
    public class AreTheySameTests {

        [Test]
        public void Test1() {
            int[] a = new int[] {121, 144, 19, 161, 19, 144, 19, 11};
            int[] b = new int[] {11*11, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19};
            bool r = Kata.comp(a, b); // True
            Assert.AreEqual(true, r);
        }
    }
}