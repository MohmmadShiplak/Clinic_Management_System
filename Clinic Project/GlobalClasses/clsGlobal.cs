using Clinic_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public static class clsGlobal
    {

        public static clsUsers CurrentUser;


        public static string ComputeHash(string Input)
        {


            // Compute the hash value from the UTF-8 encoded input string
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Input));



                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }

        }
        public static string Encrypt(string plainText, string key = "02D2E9-830F-4B31-89C6-237F4131BC")
        {
            if (plainText == null)
            {
                return null;
            }

            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Clinic Project";

            string UsernameName = "Username";
            string UsernameData = Username;

            string PasswordName = "Password";
            string PasswordData = Password;

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, UsernameName, UsernameData, RegistryValueKind.String);
                Registry.SetValue(keyPath, PasswordName, PasswordData, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                //  clsLog loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                // loggerToEventViewer.LogError("General Exception", ex);
                return false;
            }

        }
        public static string Decrypt(string cipherText, string key = "02D2E9-830F-4B31-89C6-237F4131BC")
        {
            if (cipherText == null)
            {
                return null;
            }

            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }






            //public static bool GetStoredCredential(ref string Username, ref string Password)
            //{
            //    //this will get the stored username and password and will return true if found and false if not found.
            //    try
            //    {
            //        //gets the current project's directory
            //        string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //        // Path for the file that contains the credential.
            //        string filePath = currentDirectory + "\\data.txt";

            //        // Check if the file exists before attempting to read it
            //        if (File.Exists(filePath))
            //        {
            //            // Create a StreamReader to read from the file
            //            using (StreamReader reader = new StreamReader(filePath))
            //            {
            //                // Read data line by line until the end of the file
            //                string line;
            //                while ((line = reader.ReadLine()) != null)
            //                {
            //                    Console.WriteLine(line); // Output each line of data to the console
            //                    string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

            //                    Username = result[0];
            //                    Password = result[1];
            //                }
            //                return true;
            //            }
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"An error occurred: {ex.Message}");
            //        return false;
            //    }

            //}








        }
    }
}