using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace Utility
{
	public class CryptographyManager
	{


		public CryptographyManager()
		{ }

		/// <summary>
		/// Encrypt a byte array
		/// </summary>
		/// <param name="clearData"></param>
		/// <param name="key"></param>
		/// <param name="iv"></param>
		/// <returns></returns>
		private static byte[] Encrypt(byte[] clearData, byte[] key, byte[] iv)
		{
			MemoryStream ms = new MemoryStream();
			//Rijndael alg = Rijndael.Create(); //Key Size: 32 IV Size: 16
			TripleDES alg = TripleDES.Create();   //Key Size: 16 IV Size: 8
			alg.Key = key;
			alg.IV = iv;

			CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
			cs.Write(clearData, 0, clearData.Length);
			cs.Close();

			byte[] encryptedData = ms.ToArray();
			return encryptedData;
		}

		public static string Encrypt(string clearText, string Password)
		{
			byte[] clearBytes =
				Encoding.Unicode.GetBytes(clearText);

			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

			byte[] encryptedData = Encrypt(clearBytes,
				pdb.GetBytes(16), pdb.GetBytes(8));

			return Convert.ToBase64String(encryptedData);
		}

        
		/// <summary>
		/// Encrypt a file into another file using a password 
		/// </summary>
		/// <param name="fileIn"></param>
		/// <param name="fileOut"></param>
		/// <param name="password"></param>
		public static void Encrypt(string fileIn, string fileOut, string password)
		{

			// First we are going to open the file streIMS 
			FileStream fsIn = new FileStream(fileIn,
				FileMode.Open, FileAccess.Read);
			FileStream fsOut = new FileStream(fileOut,
				FileMode.OpenOrCreate, FileAccess.Write);

			// Then we are going to derive a Key and an IV from the
			// Password and create an algorithm 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
				new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
							   0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

			Rijndael alg = Rijndael.Create();
			alg.Key = pdb.GetBytes(32);
			alg.IV = pdb.GetBytes(16);

			// Now create a crypto stream through which we are going
			// to be pumping data. 
			// Our fileOut is going to be receiving the encrypted bytes. 
			CryptoStream cs = new CryptoStream(fsOut,
				alg.CreateEncryptor(), CryptoStreamMode.Write);

			// Now will will initialize a buffer and will be processing
			// the input file in chunks. 
			// This is done to avoid reading the whole file (which can
			// be huge) into memory. 
			int bufferLen = 4096;
			byte[] buffer = new byte[bufferLen];
			int bytesRead;

			do
			{
				// read a chunk of data from the input file 
				bytesRead = fsIn.Read(buffer, 0, bufferLen);

				// encrypt it 
				cs.Write(buffer, 0, bytesRead);
			} while (bytesRead != 0);

			// close everything 

			// this will also close the unrelying fsOut stream
			cs.Close();
			fsIn.Close();
		}

        public static string Encrypt1(string pstrText)
        {
            string pstrEncrKey = "haji abul hossain";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(pstrText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

	}
}
