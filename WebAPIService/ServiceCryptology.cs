using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace WebAPIService
{
    /// <summary>
    /// ServiceCryptology
    /// Implements Password-Based Key Derivation Function PBKD
    /// for password management
    /// ...............
    /// Description
    /// PBKD is a key derivation function with a sliding computational 
    /// cost, used to reduce vulnerabilities to brute force attacks.
    /// PBKDF2 applies a pseudorandom function, such as hash-based message 
    /// authentication code (HMAC), to the input password or passphrase 
    /// along with a salt value and repeats the process many times to produce 
    /// a derived key, which can then be used as a cryptographic key in 
    /// subsequent operations. The added computational work makes password 
    /// cracking much more difficult, and is known as key stretching.
    /// ...............
    /// References
    /// https://www.mking.net/blog/password-security-best-practices-with-examples-in-csharp
    /// https://en.wikipedia.org/wiki/PBKDF2
    /// </summary>
    public static class ServiceCryptology
    {
        /// <summary>
        /// GenerateSalt
        /// Generates a desired cryptographic salt
        /// .................
        /// Description
        /// In cryptography, a salt is random data that is used as an 
        /// additional input to a one-way function that hashes data, 
        /// a password or passphrase. Salts are used to safeguard passwords 
        /// in storage. A new salt is randomly generated for each password. 
        /// In a typical setting, the salt and the password (or its 
        /// version after key stretching) are concatenated and processed with 
        /// a cryptographic hash function, and the resulting output 
        /// (but not the original password) is stored with the salt in a 
        /// database. Hashing allows for later authentication without keeping 
        /// and therefore risking exposure of the plaintext password in the event 
        /// that the authentication data store is compromised. Salts defend 
        /// against a pre-computed hash attack. Since salts do not have to 
        /// be memorized by humans they can make the size of the hash table 
        /// required for a successful attack prohibitively large without placing 
        /// a burden on the users. Since salts are different in each case, 
        /// they also protect commonly used passwords, or those users who use the 
        /// same password on several sites, by making all salted hash instances 
        /// for the same password different from each other.
        /// .................
        /// </summary>
        /// <param name="length">Length of the desired cryptographic salt</param>
        /// <returns>(byte[]) salt is a sequence of bits, known as a cryptographic salt</returns>
        public static byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;

        } // end of method

        /// <summary>
        /// GenerateHash
        /// Returns the generated derived password key
        /// </summary>
        /// <param name="password">(byte[]) Unicode encoded password</param>
        /// <param name="salt">(byte[]) salt is a sequence of bits, known as a cryptographic salt</param>
        /// <param name="iterations">(int) number of iterations</param>
        /// <param name="length">(int) the desired bit-length of the derived key</param>
        /// <returns>(byte[]) generated derived key</returns>
        public static byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return deriveBytes.GetBytes(length);
            }
        } // end of method

    } // end of class

} // end of namespace