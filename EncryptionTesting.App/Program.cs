using System;
using System.Diagnostics;

namespace EncryptionTesting.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var encryptedString = AesEncryptor.Decrypt("fAyB4i3YMhfu4gSP8etTWg==", "012345678901234567890123");

            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"took: {elapsed}ms result: {encryptedString}");
        }
    }
}