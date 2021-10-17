using System;

namespace CaesarCipher
{
    class Program
    {
        private static string alphabet = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private static int alphabetSize = alphabet.Length;

        static int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
        private static string CaesarCipher(string text, int key)
        {
            char[] array = text.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char symbol = array[i];

                if (Char.IsWhiteSpace(symbol))
                {
                    continue;
                }
                char offset = '!';
                symbol = (char)(mod(((symbol + key) - offset), alphabetSize) + offset);
                array[i] = symbol;
            }
            return new string(array);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine(alphabet);
            Console.WriteLine(alphabetSize);
            Console.WriteLine();
            string a = "To be or not to be, that is the question";
            Console.WriteLine(a);
            string b = CaesarCipher(a, 13); // Ok
            Console.WriteLine(b);

            string c = CaesarCipher(b, -13); // Ok
            Console.WriteLine(c);

            string d = CaesarCipher(a, 25); // Ok
            Console.WriteLine(d);
            string e = CaesarCipher(d, -25); // Ok
            Console.WriteLine(e);


        }
    }
}
