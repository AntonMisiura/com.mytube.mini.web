
namespace System
{
    public static class StringEx
    {
        /// <summary>
        ///
        /// </summary>
        public static string CreateHash(this string str)
        {
            return PasswordHash.PasswordHash.CreateHash(str);
        }
    }
}
