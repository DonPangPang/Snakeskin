using System.Security.Cryptography;
using System.Text;

namespace Snakeskin.Extensions;

internal static class EncryptExtensions
{
    public static string MD5Encrypt(this string str)
    {
        using MD5 md5 = MD5.Create();

        byte[] inputBytes = Encoding.UTF8.GetBytes(str);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            builder.Append(hashBytes[i].ToString("x2"));
        }

        return builder.ToString();
    }
}