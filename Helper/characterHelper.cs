using System;
namespace OrigamiEdu.Helper
{
    public static class characterHelper
    {
        public static string randomizeCharacterGUID(int val)
        {
            Random random = new Random();
            var charSet = "0123456789abcdef";
            var result = "";
            for (int i = 0; i < val; i++)
            {
                result += charSet[random.Next(charSet.Length)];
            }
            return result;
        }
        public static string randomizeCharacterAZNumeric(int val)
        {
            Random random = new Random();
            var charSet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = "";
            for (int i = 0; i < val; i++)
            {
                result += charSet[random.Next(charSet.Length)];
            }
            return result;
        }
    }
}