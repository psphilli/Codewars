using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Codewars
{
    [TestFixture]
    public class ValidatePinTests
    {   
        [Test, Description("ValidatePin should return false for pins with length other than 4 or 6")]
        public void LengthTest()
        {
            Assert.AreEqual(false, Kata.ValidatePin("1"), "Wrong output for \"1\"");
            Assert.AreEqual(false, Kata.ValidatePin("12"), "Wrong output for \"12\"");
            Assert.AreEqual(false, Kata.ValidatePin("123"), "Wrong output for \"123\"");
            Assert.AreEqual(false, Kata.ValidatePin("12345"), "Wrong output for \"12345\"");
            Assert.AreEqual(false, Kata.ValidatePin("1234567"), "Wrong output for \"1234567\"");
            Assert.AreEqual(false, Kata.ValidatePin("-1234"), "Wrong output for \"-1234\"");
            Assert.AreEqual(false, Kata.ValidatePin("1.234"), "Wrong output for \"1.234\"");
            Assert.AreEqual(false, Kata.ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
            Assert.AreEqual(false, Kata.ValidatePin("00000000"), "Wrong output for \"00000000\"");
        }
        
        [Test, Description("ValidatePin should return false for pins which contain characters other than digits")]
        public void NonDigitTest()
        {
            Assert.AreEqual(false, Kata.ValidatePin("a234"), "Wrong output for \"a234\"");
            Assert.AreEqual(false, Kata.ValidatePin(".234"), "Wrong output for \".234\"");
        }
        
        [Test, Description("ValidatePin should return true for valid pins")]
        public void ValidTest()
        {
            Assert.AreEqual(true, Kata.ValidatePin("1234"), "Wrong output for \"1234\"");
            Assert.AreEqual(true, Kata.ValidatePin("0000"), "Wrong output for \"0000\"");
            Assert.AreEqual(true, Kata.ValidatePin("1111"), "Wrong output for \"1111\"");
            Assert.AreEqual(true, Kata.ValidatePin("123456"), "Wrong output for \"123456\"");
            Assert.AreEqual(true, Kata.ValidatePin("098765"), "Wrong output for \"098765\"");
            Assert.AreEqual(true, Kata.ValidatePin("000000"), "Wrong output for \"000000\"");
            Assert.AreEqual(true, Kata.ValidatePin("090909"), "Wrong output for \"090909\"");
        }
    }

    [TestFixture]
    public static class RevrotTests 
    {
        private static void testing(string actual, string expected) 
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1() 
        {
            Console.WriteLine("Testing RevRot");        
            testing(Kata.RevRot("1234", 0), "");
            testing(Kata.RevRot("", 0), "");
            testing(Kata.RevRot("1234", 5), "");
            String s = "733049910872815764";
            testing(Kata.RevRot(s, 5), "330479108928157");
        }
    }     

    [TestFixture]
    public class IsPrimeTests
    {
        private static IEnumerable<TestCaseData> sampleTestCases
        {
            get
            {
                yield return new TestCaseData(0).Returns(false);
                yield return new TestCaseData(1).Returns(false);
                yield return new TestCaseData(2).Returns(true);
            }
        }

        [Test, TestCaseSource("sampleTestCases")]
        public bool SampleTest(int n) => Kata.IsPrime(n);
    }

    [TestFixture]
    public class BouncingBallTests 
    {

        [Test]
        public void Test1() {
            Assert.AreEqual(3, Kata.bouncingBall(3.0, 0.66, 1.5));
        }

        [Test]
        public void Test2() {
            Assert.AreEqual(15, Kata.bouncingBall(30.0, 0.66, 1.5));
        }
    }
    
    [TestFixture]
    public class TimedReading
    {
        [Test]
        public void BasicTests(){
            Assert.AreEqual(7,  Kata.TimedReading(4,"The Fox asked the stork, 'How is the soup?'"));
            Assert.AreEqual(0,  Kata.TimedReading(1,"..."));
            Assert.AreEqual(3,  Kata.TimedReading(3,"This play was good for us."));
            Assert.AreEqual(5,  Kata.TimedReading(3,"Suddenly he stopped, and glanced up at the houses"));
            Assert.AreEqual(11,  Kata.TimedReading(6,"Zebras evolved among the Old World horses within the last four million years."));
            Assert.AreEqual(6,  Kata.TimedReading(5,"Although zebra species may have overlapping ranges, they do not interbreed."));
            Assert.AreEqual(0,  Kata.TimedReading(1,"Oh!"));
            Assert.AreEqual(14,  Kata.TimedReading(5,"Now and then, however, he is horribly thoughtless, and seems to take a real delight in giving me pain."));
        }
    }

    [TestFixture]
    public class RgbToHex 
    {
        [Test]
        public void FixedTests() 
        {
            Assert.AreEqual("FFFFFF", Kata.Rgb(255,255,255));
            Assert.AreEqual("FFFFFF", Kata.Rgb(255,255,300));
            Assert.AreEqual("000000", Kata.Rgb(0,0,0));
            Assert.AreEqual("9400D3", Kata.Rgb(148,0,211));
            Assert.AreEqual("9400D3", Kata.Rgb(148,-20,211), "Handle negative numbers.");
            Assert.AreEqual("90C3D4", Kata.Rgb(144,195,212));
            Assert.AreEqual("D4350C", Kata.Rgb(212,53,12), "Consider single hex digit numbers.");
        }                
    }

    [TestFixture]
    public class HumanReadableTime 
    {
        [Test]
        public void HumanReadableTimeTest() 
        {
            Assert.AreEqual("00:00:00", Kata.GetReadableTime(0));
            Assert.AreEqual("00:00:05", Kata.GetReadableTime(5));
            Assert.AreEqual("00:01:00", Kata.GetReadableTime(60));
            Assert.AreEqual("23:59:59", Kata.GetReadableTime(86399));
            Assert.AreEqual("99:59:59", Kata.GetReadableTime(359999));
        }                
    }
}