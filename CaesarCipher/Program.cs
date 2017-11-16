// Nicholas Espinosa
// COP 4020
// C# Caesar Cipher
// Boop
using System;
using System.Text;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            String encodedWord = StringExtensions.Encode(3, "haskell is fun");
            //Console.WriteLine(StringExtensions.Rotate(3, "haskell is fun"));
            float[] list = StringExtensions.Chilist("haskell is fun");
            //Console.WriteLine(encodedWord);
            //String decodedWord = StringExtensions.Decode(3, encodedWord);
            //Console.WriteLine(decodedWord);
            //StringExtensions.Cracked(encodedWord);
            //char l = StringExtensions.Nat2let((StringExtensions.Let2nat('c') - 3 + 26) % 26);
            //char m = StringExtensions.Unshift(3, 'c');
            //Console.WriteLine(l + " " + m);
        }
    }
    public static class StringExtensions
    {

        static float[] table = {8.2f, 1.5f, 2.8f, 4.3f, 12.7f, 2.2f, 2.0f, 6.1f, 7.0f, 0.2f, 0.8f, 4.0f,
            2.4f, 6.7f, 7.5f, 1.9f, 0.1f, 6.0f, 6.3f, 9.1f, 2.8f, 1.0f, 2.4f, 0.2f, 2.0f, 0.1f};

        // Given a character, return a number
        public static int Let2nat(char c)
        {
            return ((int)c - 97);
        }
        // Given a number, return a character
        public static char Nat2let(int i)
        {
            return ((char)(i + 97));
        }
        // Shifts a given character by a certain amount
        public static char Shift(int i, char c)
        {
            if (!Char.IsLower(c))
                return c;

            // If the character exceeds the lowercase letters
            if (Let2nat(c) + i > 25)
                return Nat2let((Let2nat(c) + i) % 26);

            // Otherwise
            return Nat2let(Let2nat(c) + i);
        }
        public static char Unshift(int i, char c)
        {
            if (!Char.IsLower(c))
                return c;

            // If the character exceeds the lowercase letters
            if (Let2nat(c) - i < 0)
                return Nat2let((Let2nat(c) - i + 26) % 26);

            // Otherwise
            return Nat2let(Let2nat(c) - i);
        }
        // Encodes a given string
        public static String Encode(int i, String s)
        {
            StringBuilder sb = new StringBuilder("");
            foreach (char c in s)
                sb.Append(Shift(i, c));

            return sb.ToString();
        }
        // Decodes a given string
        public static String Decode(int i, String s)
        {
            StringBuilder sb = new StringBuilder("");
            String result = "";
            foreach (char c in s)
            {
                sb.Append(Unshift(i, c));
            }

            return sb.ToString();
        }
        // Determines the number of lowercase characters in a string
        public static int Lowers(String s)
        {
            int i = 0;
            foreach (char c in s)
            {
                // Only increment if a lower case string is found
                if (Char.IsLower(c))
                    i++;
            }

            return i;
        }
        
        // Determines the number of a certain character within a string
        public static int Count(char c, String s)
        {
            int i = 0;
            foreach (char l in s)
            {
                // Only increment if the caracter is found
                if (c == l)
                    i++;
            }

            return i;
        }

        // Determines the percentage of which a character makes up in a String
        public static float Percent(int count, int total)
        {
            return 100f * ((float)count / (float)total);
        }

        // Creates a list that shows the frequencies of each letter in a string
        public static float[] Freqs(String word)
        {
            // Created the array
            float[] freq = new float[26];

            // Determining the frequency for each letter
            for (int i = 0; i < 26; i++)
                freq[i] = Percent(Count(Nat2let(i), word), Lowers(word));

            return freq;
        }

        // Rotates a string a given number of spaces
        public static String Rotate(int amt, String word)
        {
            for (int i = 0; i < amt; i++)
                word = word.Substring(1) + word.Substring(0, 1);

            return word;
        }
        // Finds the position of the given value
        public static int Position(float value, float[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (value == input[i])
                    return i;
            }
            return -1;
        }
        public static float GetMin(float[] input)
        {
            float test = float.MaxValue;

            foreach (float f in input)
            {
                if (f < test)
                    test = f;
            }
            return test;
        }

        // Calculates the chisqr function
        public static float Chisqr(float[] input)
        {
            float chisqr = 0.0f;

            for (int i = 0; i < 26; i++)
            {
                chisqr += (float)Math.Pow(input[i] - table[i], 2.0f)/table[i];
            }

            return chisqr;
        }

        public static float[] Chilist(String word)
        {
            float[] chilist = new float[26];

            for (int i = 0; i < 26; i++)
            {
                chilist[i] = Chisqr(Freqs(Rotate(i, word)));
                Console.WriteLine(Rotate(i, word) + " " + Chisqr(Freqs(Rotate(i, word))));
            }

            return chilist;
        }

        public static void Cracked(String word)
        {
            float[] chilist = Chilist(word);
            int shiftAmt = Position(GetMin(chilist), chilist);
            for (int i = 0; i < 26; i++)
            {
                    Console.Write(chilist[i] + " ");
            }
            Console.WriteLine(shiftAmt);
            String result = Decode(shiftAmt, word);
            Console.WriteLine(result);
        }
    }
}
