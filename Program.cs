using System;
using System.Runtime.InteropServices;

namespace TesteCryptoFile
{
    /// <summary>
    /// Based on: https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp
    /// </summary>    
    class Program
    {
        static string password = "ThePasswordToDecryptAndEncryptTheFile";

        static void Main(string[] args)
        {
            //Cripto();
            Decripto();
        }

        static void Cripto()
        {
            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Encrypt the file
            FileCrypto.FileEncrypt(@"C:\Users\felipe.junges\Documents\filezilla.log", password);

            // To increase the security of the encryption, delete the given password from the memory !
            FileCrypto.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            gch.Free();

            // You can verify it by displaying its value later on the console (the password won't appear)
            Console.WriteLine("The given password is surely nothing: " + password);
        }

        static void Decripto()
        {
            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Decrypt the file
            FileCrypto.FileDecrypt(@"C:\Users\felipe.junges\Documents\filezilla.log", password);

            // To increase the security of the decryption, delete the used password from the memory !
            FileCrypto.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            gch.Free();

            // You can verify it by displaying its value later on the console (the password won't appear)
            Console.WriteLine("The given password is surely nothing: " + password);
        }
    }
}
