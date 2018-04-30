using System;
using System.Diagnostics;

namespace EncryptionTesting.App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Test 1:");
            TestOne();
            
            Console.WriteLine("Starting Test 2:");
            TestTwo();
            
            Console.WriteLine("Starting Test 3:");
            TestThree();
            
            Console.WriteLine("Starting Test 4:");
            TestFour();
        }

        public static void TestOne()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var encryptedString = AesEncryptor.Encrypt("password", "012345678901234567890123");
            var plainString = AesEncryptor.Decrypt(encryptedString, "012345678901234567890123");
            
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"took: {elapsed}ms resultEncrypted: {encryptedString} resultDecrypted: {plainString}");
        }

        public static void TestTwo()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var encryptedString = DesEncryptor.Encrypt("password", "012345678901234567890123");
            var plainString = DesEncryptor.Decrypt(encryptedString, "012345678901234567890123");
            
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"took: {elapsed}ms resultEncrypted: {encryptedString} resultDecrypted: {plainString}");
        }

        public static void TestThree()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (var i = 0; i < 100; i++)
            {
                var encryptedString = AesEncryptor.Encrypt("password", "012345678901234567890123");
                var plainString = AesEncryptor.Decrypt(encryptedString, "012345678901234567890123");
            }
            stopwatch.Stop();

            var elapsed = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"took: {elapsed}ms");
        }

        public static void TestFour()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (var i = 0; i < 100; i++)
            {
                var encryptedString = DesEncryptor.Encrypt("password", "012345678901234567890123");
                var plainString = DesEncryptor.Decrypt(encryptedString, "012345678901234567890123");
            }
            stopwatch.Stop();

            var elapsed = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"took: {elapsed}ms");
        }
    }
}