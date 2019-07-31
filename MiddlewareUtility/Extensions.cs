namespace MiddlewareUtility
{
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> Dictionary, TKey Key, TValue DeafultValue)
        {
            return Dictionary.ContainsKey(Key) ? Dictionary[Key] : DeafultValue;
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == '.' || c == '_' || c == '/' || c == '%')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}