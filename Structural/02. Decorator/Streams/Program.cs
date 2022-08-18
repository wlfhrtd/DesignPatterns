﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text to be encrypted to a file and then decrypted:");
            string text = Console.ReadLine();

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Wrong input.");
                return;
            }

            string filename = Path.GetTempFileName();

            using (Rijndael rijndael = Rijndael.Create())
            {
                // For simplicity these get generated each time.
                // To use your own key/IV, use Encoding.UTF8.GetBytes(yourKey/yourIV);
                byte[] cryptoKey = rijndael.Key;
                byte[] cryptoIV = rijndael.IV;

                using (FileStream fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write))
                {
                    ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                    using (Stream stream = new CryptoStream(new BufferedStream(fileStream), encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(text);
                        }
                    }
                }

                Console.WriteLine("This is the encrypted data");
                string encryptedData = Convert.ToBase64String(File.ReadAllBytes(filename));
                Console.WriteLine(encryptedData);
                Console.WriteLine();

                using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                    using (Stream stream = new CryptoStream(new BufferedStream(fileStream), decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string decrypedData = reader.ReadToEnd();
                            Console.WriteLine("This is the decrypted data");
                            Console.WriteLine(decrypedData);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
