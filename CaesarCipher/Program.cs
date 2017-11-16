// Hello, this is Nick
// Boop
using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(StringExtensions.Boop());
            //StringExtensions.Cracked("Hello!");
            //Console.WriteLine(StringExtensions.Let2nat('a'));
            //Console.WriteLine(StringExtensions.Nat2let(0));
            //Console.WriteLine(StringExtensions.Shift(3, 'z'));
            //Console.WriteLine(StringExtensions.Encode(3, "haskell is fun"));
            //Console.WriteLine(StringExtensions.Decode(3, "kdvnhoo lv ixq"));
            //Console.WriteLine(StringExtensions.Lowers("haskell is fun"));
            //Console.WriteLine(StringExtensions.Count('s',"haskell is fun"));
            //int count = StringExtensions.Count('s', "haskell is fun");
            //int total = StringExtensions.Lowers("haskell is fun");
            //Console.WriteLine(StringExtensions.Percent(count, total));
            float[] freq = StringExtensions.Freqs("haskell is fun");
            for(int i = 0; i < 26; i++)
            {
                if (i == 25)
                    Console.Write(freq[i] + "\n");
                else
                    Console.Write(freq[i] + ", "); 
            }
        
        }
    }
    public static class StringExtensions
    {

        static float[] table = {8.2f, 1.5f, 2.8f, 4.3f, 12.7f, 2.2f, 2.0f, 6.1f, 7.0f, 0.2f, 0.8f, 4.0f,
            2.4f, 6.7f, 7.5f, 1.9f, 0.1f, 6.0f, 6.3f, 9.1f, 2.8f, 1.0f, 2.4f, 0.2f, 2.0f, 0.1f};

        // Tester function
        public static String Boop()
        {
            return "Boop!";
        }
        // Function that will be called
        public static void Cracked(String input)
        {
            Console.WriteLine("Found the crack");
        }
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
                return Nat2let((Let2nat(c) - i) % 26);

            // Otherwise
            return Nat2let(Let2nat(c) - i);
        }
        // Encodes a given string
        public static String Encode(int i, String s)
        {
            String result = "";
            foreach (char c in s)
                result += Shift(i, c);

            return result;
        }
        // Decodes a given string
        public static String Decode(int i, String s)
        {
            String result = "";
            foreach (char c in s)
                result += Unshift(i, c);

            return result;
        }
        public static int Lowers(String s)
        {
            int i = 0;
            foreach (char c in s)
            {
                if (Char.IsLower(c))
                    i++;
            }

            return i;
        }
        public static int Count(char c, String s)
        {
            int i = 0;
            foreach (char l in s)
            {
                if (c == l)
                    i++;
            }

            return i;
        }

        public static float Percent(int count, int total)
        {
            return 100f * ((float)count / (float)total);
        }

        public static float[] Freqs(String word)
        {
            float[] freq = new float[26];

            for (int i = 0; i < 26; i++)
                freq[i] = Percent(Count(Nat2let(i), word), Lowers(word));

            return freq;
        }
    }
}
