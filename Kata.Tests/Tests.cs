using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Codewars
{
    [TestFixture]
    public class UpdateLight
    {
        [TestCase("green", "yellow")]
        [TestCase("yellow", "red")]
        [TestCase("red", "green")]
        public void BasicTests(string s, string expected)
        {
            Assert.That(Kata.UpdateLight(s), Is.EqualTo(expected));
        }
        [Test]
        public void RandomTests()
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var s = "green yellow red".Split()[rnd.Next(0, 3)];
                var expected = SolutionUpdateLight(s);
                Assert.That(Kata.UpdateLight(s), Is.EqualTo(expected));
            }
        }
        readonly List<string> a = new List<string> { "green", "yellow", "red", "green" };
        string SolutionUpdateLight(string current) => a[a.IndexOf(current) + 1];
    }


    [TestFixture]
    public class GreetTest
    {
        [Test]
        public void ShouldReturnHelloWorld()
        {
            Assert.AreEqual(Kata.Greet(), "hello world!");
        }
    }


    [TestFixture]
    public class GetMiddleTest
    {
        [Test]
        public void GenericTests()
        {
            Assert.That(() => Kata.GetMiddle(null), Throws.ArgumentException, "didnt throw when input is null");
            Assert.That(() => Kata.GetMiddle(""), Throws.ArgumentException, "didnt throw when input is empty");
            Assert.AreEqual("es", Kata.GetMiddle("test"));
            Assert.AreEqual("t", Kata.GetMiddle("testing"));
            Assert.AreEqual("dd", Kata.GetMiddle("middle"));
            Assert.AreEqual("A", Kata.GetMiddle("A"));
        }
    }

    [TestFixture]
    public class CheckIfFlush
    {
         [Test]
        public void BasicTests()
        {
            string[] cards={"AS", "3S", "9S", "KS", "4S"};
            Assert.AreEqual(true, Kata.CheckIfFlush(cards));
            string[] cards2={"AD", "4S", "7H", "KC", "5S"};
            Assert.AreEqual(false, Kata.CheckIfFlush(cards2));
                string[] cards3={"10D", "4S", "7H", "KC", "5S"};
            Assert.AreEqual(false, Kata.CheckIfFlush(cards3));    
                string[] cards4={"10D", "QD", "7D", "KD", "5D"};
            Assert.AreEqual(true, Kata.CheckIfFlush(cards4));
        }
    } 

    [TestFixture]
    public class SortArrayTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4 }, Kata.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
            Assert.AreEqual(new int[] { 1, 3, 5, 8, 0 }, Kata.SortArray(new int[] { 5, 3, 1, 8, 0 }));
            Assert.AreEqual(new int[] { }, Kata.SortArray(new int[] { }));
        }
    }
}