using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace MathTestsX86
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are they the same in 32 bit?");

            //#1
            DoubleTest();   

            //#2
            BigIntTest();
            LongTest();

            //#3
            BigIntDoubleTest();

            Console.ReadKey();
        }

        private static void DoubleTest()
        {            
            //https://connect.microsoft.com/VisualStudio/feedback/details/914964/double-round-trip-conversion-via-a-string-is-not-safe
            double d1 = 0.84551240822557006;
            string s = d1.ToString("R");
            double d2 = double.Parse(s);

            Console.WriteLine("this works in 32 bit");
            Console.WriteLine("Double Test: {0}", d1 == d2);
        }

        private static void BigIntTest()
        {
            BigInteger value = BigInteger.Parse("-903145792771643190182");

            Console.WriteLine("BigInt values are truncated.");
            Console.WriteLine("big int flat\t{0}", value);
            Console.WriteLine("big int E8\t{0:E8}", value);
            Console.WriteLine("big int E\t{0:E}", value);
            Console.WriteLine("big int E4\t{0:E4}\n\n", value);

            NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
            bigIntegerFormatter.NegativeSign = "~";
            string[] specifiers = { "C", "D", "D25", "E", "E4", "e8", "F0", 
                        "G", "N0", "P", "R", "X", "0,0.000", 
                        "#,#.00#;(#,#.00#)" };

            foreach (string specifier in specifiers)
                Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier,
                                  bigIntegerFormatter));

            Console.WriteLine("\n\n", value);
        }

        private static void LongTest()
        {
            long l = long.Parse("-9031457927716431901");

            Console.WriteLine("long values are rounded.");
            Console.WriteLine("long flat\t{0}", l);
            Console.WriteLine("long E8\t\t{0:E8}", l);
            Console.WriteLine("long E\t\t{0:E}", l);
            Console.WriteLine("long E4\t\t{0:E4}\n\n", l);
        }

        private static void BigIntDoubleTest()
        {
            BigInteger roundMeDown = 0x0020000000000001UL;
            double expectedRoundedDown = Math.Pow(2, 53);

            BigInteger roundMeUp = 0x00020000000000003UL;
            double expectedRoundedUp = Math.Pow(2, 53) + 4;
            double actual = Math.Pow(2, 53) + 2;

            Console.WriteLine("expectedRoundedDown: {0} \t {1} \t {2}", expectedRoundedDown == (double)roundMeDown, expectedRoundedDown, roundMeDown);
            Console.WriteLine("expectedRoundedUp  : {0} \t {1} \t {2}", expectedRoundedUp == (double)roundMeUp, expectedRoundedUp, roundMeUp);
            Console.WriteLine("actual             : {0} \t {1} \t {2}", actual == (double)roundMeUp, actual, roundMeUp);
        }
    }
}
