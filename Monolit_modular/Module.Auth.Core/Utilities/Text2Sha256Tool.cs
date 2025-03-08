using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Module.Auth.Core.Utilities
{
    public class Text2Sha256Tool
    {
        public static string Fn_ComputeSha256Hash(string input)
        {
            // Crear una instancia del algoritmo SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir el texto de entrada en un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Construir el string de hash en formato hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));  // Convertir cada byte en su representación hexadecimal
                }

                // Retornar el hash como string
                return builder.ToString();
            }
        }

        public static bool Fn_CompareSha256Hashes(string hash1, string hash2)
        {
            // Compara si los dos hashes son iguales (mayúsculas y minúsculas son importantes)
            return string.Equals(hash1, hash2, StringComparison.OrdinalIgnoreCase);
        }
    }
    //end class
}
//end namespaces
