using System;
using System.Security.Cryptography;
using System.Text;

namespace Deterministic_guids
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter input to create a deterministic guid");
                var input = Console.ReadLine();

                using (var md5Hash = MD5.Create())
                {
                    var hash = GetHash(md5Hash, input);

                    //MD5 gives us a 32 character hex string, which is the same as a guid!
                    var guid = new Guid(hash);
                    Console.WriteLine($"Detrministic guid is {guid}\n");
                }

            }
        }

        private static string GetHash(HashAlgorithm algo, string input)
        {
            var data = algo.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}