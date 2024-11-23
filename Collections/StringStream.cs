using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class StringStream
    {
        private static Aes aes = Aes.Create();
        public static void StringStreamWriter(Stream stream, string text, bool compressed = false, bool encrypted = false)
        {
            Stream writingStream = stream;
            if (compressed)
            {
                writingStream = new GZipStream(writingStream, CompressionMode.Compress);
            }

            if (encrypted)
            {
                writingStream = new CryptoStream(writingStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);
            }

            var sw = new StreamWriter(writingStream);
            sw.Write(text);
            sw.Flush();
            if (writingStream is CryptoStream cs)
            {
                cs.FlushFinalBlock();
            }
        }

        public static string StringStreamReader(Stream stream, bool compressed = false, bool encrypted = false)
        {
            stream.Position = 0;

            if (compressed)
            {
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            if (encrypted)
            {
                stream = new CryptoStream(stream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read);
            }

            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }
}
