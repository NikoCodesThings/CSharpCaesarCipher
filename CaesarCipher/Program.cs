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
            //Console.WriteLine(StringExtensions.Encode(3, "haskell is fun"));
            //Console.WriteLine(StringExtensions.Decode(3, "kdvnhoo lv ixq"));
            //Console.WriteLine(StringExtensions.Lowers("haskell is fun"));
            //Console.WriteLine(StringExtensions.Count('s', "haskell is fun"));
            //int count = StringExtensions.Count('s', "haskell is fun");
            //int lowers = StringExtensions.Lowers("haskell is fun");
            //Console.WriteLine(StringExtensions.Percent(count, lowers));
            String word = "haskell is fun";
            float[] freqs = StringExtensions.Freqs(StringExtensions.Rotate(3, word));
            /*for (int i = 0; i < 26; i++)
                Console.WriteLine(freqs[i]);*/
            //Console.WriteLine(StringExtensions.Rotate(3, "haskell is fun"));
            Console.WriteLine(StringExtensions.Chisqr(freqs));

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

        // Calculates the total number of lower case letters in the word
        public static int Lowers(String word)
        {
            int i = 0;

            foreach(char c in word)
            {
                if (Char.IsLower(c))
                    i++;
            }

            return i;
        }
        
        // Calculates the number of times a given letter appears 
        public static int Count(char letter, String word)
        {
            int i = 0;

            foreach (char c in word)
            {
                if (c.Equals(letter))
                    i++;
            }

            return i;
        }

        // Calculates the percentage of which a letter appears
        public static float Percent(int count, int lowers)
        {
            return 100.0f * ((float)count / (float)lowers);
        }

        // Obtains the letter frequencies of an array
        public static float[] Freqs(String word)
        {
            int count, lowers = Lowers(word);
            float[] freqs = new float[26];

            for (int i = 0; i < 26; i++)
            {
                count = Count(Nat2Let(i), word);

                freqs[i] = Percent(count, lowers);
            }

            return freqs;
        }
        // Recursively rotates a string by a given amount
        public static String Rotate(int amt, String word)
        {
            if (amt == 0)
                return word;

            return Rotate(amt - 1, word.Substring(1) + word.Substring(0, 1));
        }

        // Calculates the chisqr value from a given float array
        public static float Chisqr(float[] input)
        {
            float chisqr = 0.0f;

            for (int i = 0; i < 26; i++)
                chisqr += (float)Math.Pow((double)input[i] - (double)table[i], 2.0) / table[i];

            return chisqr;
        }
        // Determines the position of a value, if nothing is found, then -1 is returned
        public static int Position(float value, float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (value.Equals(array[i]))
                    return i;
            }
            return -1;
        }
    }
}
