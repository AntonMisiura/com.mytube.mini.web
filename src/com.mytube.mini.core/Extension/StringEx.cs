
namespace System
{
    public static class StringEx
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CreateHash(this string str)
        {
            return PasswordHash.PasswordHash.CreateHash(str);
        }
    }
}
