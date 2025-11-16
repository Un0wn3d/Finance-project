using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BudgetPlanningApp.AppCode {
  class EncryptData {
    // Ключ і вектор ініціалізації (IV) – мають бути 16 байтів (128 біт)
    // Для стабільності прикладу використовується фіксоване значення, 
    // але у реальному ПЗ краще генерувати їх динамічно або зберігати безпечно.
    private static readonly byte[] key = Encoding.UTF8.GetBytes("FixedWWWFixedWWW");
    private static readonly byte[] iv = Encoding.UTF8.GetBytes("InitVector123456");

    public string Encrypt(string originalString) {
      if (string.IsNullOrEmpty(originalString)) {
        throw new ArgumentNullException("The string to encrypt cannot be null or empty.");
      }

      using (Aes aes = Aes.Create()) {
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using (MemoryStream ms = new MemoryStream()) {
          using (ICryptoTransform encryptor = aes.CreateEncryptor()) {
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
              using (StreamWriter writer = new StreamWriter(cs, Encoding.UTF8)) {
                writer.Write(originalString);
              }
            }
          }
          return Convert.ToBase64String(ms.ToArray());
        }
      }
    }

    public string Decrypt(string cryptedString) {
      if (string.IsNullOrEmpty(cryptedString)) {
        throw new ArgumentNullException("The string to decrypt cannot be null or empty.");
      }

      using (Aes aes = Aes.Create()) {
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        byte[] buffer = Convert.FromBase64String(cryptedString);

        using (MemoryStream ms = new MemoryStream(buffer)) {
          using (ICryptoTransform decryptor = aes.CreateDecryptor()) {
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
              using (StreamReader reader = new StreamReader(cs, Encoding.UTF8)) {
                return reader.ReadToEnd();
              }
            }
          }
        }
      }
    }
  }
}
