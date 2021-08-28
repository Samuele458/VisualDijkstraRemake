using System;
using System.Security.Cryptography;

namespace WebApp.Utils
{

    /// <summary>
    ///  Static methods for handling strings
    /// </summary>
    public class StringUtils
    {

        /// <summary>
        ///  Generates a random base64 string
        /// </summary>
        /// <param name="bytes">Bytes length</param>
        /// <returns>Random base64 string</returns>
        public static string RandomBase64String(int bytes)
        {
            //Generating random bytes
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[bytes];
            rng.GetBytes(buff);

            //Returns base64 string
            return Convert.ToBase64String(buff);
        }
    }
}
