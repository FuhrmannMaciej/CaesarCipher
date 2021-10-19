using System;
using System.Collections;
using System.IO;

namespace CaesarCipher
{
    class Program
    {
        private const string answersPath = @"C:\Users\fuhrm\source\repos\CaesarCipher\CaesarCipher\answers.txt";
        private const string dictionaryPath = @"C:\Users\fuhrm\source\repos\CaesarCipher\CaesarCipher\dictionary.txt";
        private static string alphabet = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        private static int alphabetSize = alphabet.Length;

        static int Mod(int x, int m)
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
                symbol = (char)(Mod(((symbol + key) - offset), alphabetSize) + offset);
                array[i] = symbol;
            }
            return new string(array);
        }

        private static ArrayList FileReader ()
        {
            ArrayList allDictionaryWords = new ArrayList();
            foreach (string word in File.ReadLines(dictionaryPath))
            {
                allDictionaryWords.Add(word);
            }
            return allDictionaryWords;
        }

        private static void BruteForce(string text)
        {
            Console.WriteLine("Started brute-force");
            ArrayList dictionary = FileReader();
            StreamWriter sw = File.AppendText(answersPath);
            for (int i = 1; i <= alphabetSize; i++)
            {
                string textToSplit = CaesarCipher(text, i);
                string[] words = textToSplit.Split(" ");
                sw.WriteLine("Key: " + i + " . Looping through possible words.");
                for (int j = 0; j < dictionary.Count; j++)
                {
                    foreach (var word in words)
                    {
                        if (word.ToLower() == (string)dictionary[j])
                        {
                            sw.WriteLine(Array.IndexOf(words, word) + " " + word);
                        }
                    }
                }
            }
            Console.WriteLine("Finished brute-force");
            sw.Close();
        }

        private static void ClearAnswersFile ()
        {
            File.WriteAllText(answersPath, string.Empty);
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

            ClearAnswersFile();

            BruteForce("The only thing we have to fear is fear itself");

        }
    }
}
