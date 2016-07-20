namespace _04.Number_in_Reversed_Order
{
    using System;
    public class Number_in_Reversed_Order
    {
        public static void Main()
        {
            string num = Console.ReadLine();
            Console.WriteLine(DecimalNumber.Reverse(num));
        }
    }

    public class DecimalNumber
    {
        public static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = string.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            return reverse;
        }
    }
}
