using System.Text;
using System.Security.Cryptography;

namespace Application.Helpers
{
    public static class Md5
    {
        public static string Hash(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arr = Encoding.UTF8.GetBytes(str);
            arr = md5.ComputeHash(arr);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in arr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
