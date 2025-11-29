using System;
using System.Text;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;

public static class SecurePlayerPrefs
{
    // Chave de criptografia (em um projeto real, evite hardcode ou use ofuscação)
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("6543210987654321");  // 16 bytes

    public static void SetInt(string key, int value)
    {
        SetString(key, value.ToString());
    }

    public static int GetInt(string key, int defaultValue = 0)
    {
        string value = GetString(key);
        if (string.IsNullOrEmpty(value)) return defaultValue;

        if (int.TryParse(value, out int result))
            return result;
        
        return defaultValue;
    }

    public static void SetString(string key, string value)
    {
        string encryptedValue = Encrypt(value);
        PlayerPrefs.SetString(key, encryptedValue);
    }

    public static string GetString(string key, string defaultValue = "")
    {
        if (!PlayerPrefs.HasKey(key)) return defaultValue;

        string encryptedValue = PlayerPrefs.GetString(key);
        try
        {
            return Decrypt(encryptedValue);
        }
        catch
        {
            // Se falhar (ex: save corrompido ou editado), retorna default
            return defaultValue;
        }
    }

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }

    private static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    private static string Decrypt(string cipherText)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
