using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Strayacoin_Miner_v0._06a
{
    public static class Base58Check
    {
        private const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static bool DecodeBase58Check(string input, out byte[] output)
        {
            output = null;
            if (string.IsNullOrEmpty(input))
                return false;

            BigInteger intData = 0;
            foreach (char c in input)
            {
                int digit = Alphabet.IndexOf(c);
                if (digit < 0)
                    return false;

                intData = intData * 58 + digit;
            }

            byte[] bytes = intData.ToByteArray().Reverse().ToArray();
            int leadingZeros = input.TakeWhile(c => c == '1').Count();
            output = new byte[leadingZeros + bytes.Length];
            Array.Copy(bytes, 0, output, leadingZeros, bytes.Length);

            if (output.Length < 4)
                return false;

            byte[] data = output.Take(output.Length - 4).ToArray();
            byte[] checksum = output.Skip(output.Length - 4).ToArray();
            byte[] hash = SHA256.Create().ComputeHash(SHA256.Create().ComputeHash(data));

            return checksum.SequenceEqual(hash.Take(4));
        }
    }
}



