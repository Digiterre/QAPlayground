using System;
using System.Text;

namespace FunctionalTest.Helpers
{
    public class Utilities
    {
        public static string RandomAlphabeticString(int size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }

            return builder.ToString();

        }

        public static string RandomAlphaNumericString(int size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }

            return builder.ToString();

        }
    }
}
