using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace XUnitTestProject
{
    public class NumberToEnglishTests
    {
        [TestFixture]
        internal class Tests
        {
            [TestCase(-4, "")]
            [TestCase(0, "zero")]
            [TestCase(7, "seven")]
            [TestCase(11, "eleven")]
            [TestCase(20, "twenty")]
            [TestCase(47, "forty seven")]
            [TestCase(100, "one hundred")]
            [TestCase(305, "three hundred five")]
            [TestCase(4002, "four thousand two")]
            [TestCase(20005, "twenty thousand five")]
            [TestCase(6800, "six thousand eight hundred")]
            [TestCase(14111, "fourteen thousand one hundred eleven")]
            [TestCase(3892, "three thousand eight hundred ninety two")]
            [TestCase(99999, "ninety nine thousand nine hundred ninety nine")]
            public void BasicTest(int n, string expected)
            {
                Assert.That(NumberToEnglish(n), Is.EqualTo(expected));
            }

            private string NumberToEnglish(int n)
            {
                var result = "";
                var singular = new List<string>() { "", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine " };
                var teens = new List<string>() { "", "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ", "sixteen ", "seventeen ", "eighteen ", "nineteen " };
                var tens = new List<string>() { "", "ten ", "twenty ", "thirty ", "forty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety " };
                var hundred = "hundred ";
                var thousend = "thousand ";

                if (n < 0) return "";
                else if (n == 0) return "zero";
                else if (n > 10 && n < 20) return teens[n % 10];
                result += singular[(n / 1000) % 10];
                if (result != "") result += thousend;
                result += singular[(n / 100) % 10];
                if (result != "") result += hundred;
                result += tens[(n / 10) % 10];
                result += singular[n % 10];

                return result.Trim();
            }
        }
    }
}
