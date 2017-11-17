// Nicholas Espinosa
// COP 4020
// C# Caesar Cipher

using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(StringExtensions.Let2Nat('z'));
            //Console.WriteLine(StringExtensions.Nat2Let(25));
            //Console.WriteLine(StringExtensions.Shift(3, 'z'));
            Console.WriteLine(StringExtensions.Encode(3, "haskell is fun"));
            Console.WriteLine(StringExtensions.Decode(3, "kdvnhoo lv ixq"));
        }
    }
    public static class StringExtensions
    {
        // Table of averages for letter distribution
        static float[] table = {8.2f, 1.5f, 2.8f, 4.3f, 12.7f, 2.2f, 2.0f, 6.1f, 7.0f, 0.2f, 0.8f, 4.0f,
            2.4f, 6.7f, 7.5f, 1.9f, 0.1f, 6.0f, 6.3f, 9.1f, 2.8f, 1.0f, 2.4f, 0.2f, 2.0f, 0.1f};

        // Converts a letter to a number
        public static int Let2Nat(char c)
        {
            return (int)c - 97;
        }
        // Converts a number to a letter
        public static char Nat2Let(int i)
        {
            return (char)(i + 97);
        }

        // Shifts a character by a certain number of spaces
        public static char Shift(int amt, char letter)
        {
            // If char is not a lower case letter, then it is simply returned
            if (!Char.IsLower(letter))
                return letter;

            return Nat2Let((amt + Let2Nat(letter)) % 26);
        }

        // Encodes a string by shifting it a certain number of letters
        public static String Encode(int amt, String word)
        {
            StringBuilder sb = new StringBuilder("");

            foreach (char c in word)
                sb.Append(Shift(amt, c));

            return sb.ToString();
        }

        // Decodes a string by shifting it a certain number of letters
        public static String Decode(int amt, String word)
        {
            StringBuilder sb = new StringBuilder("");

            foreach (char c in word)
                sb.Append(Shift(26 - amt, c));

            return sb.ToString();
        }

    }
}
