using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalBlog.Core.Tools
{
    public static class PasswordHelper
    {

        public static string HashPassword(this string Password)
        {

            using ( SHA256 sha256 = SHA256.Create())
            {

                byte[] PassBytes = Encoding.UTF8.GetBytes(Password);
                byte[] HashBytes = sha256.ComputeHash(PassBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i<HashBytes.Length;i++)
                {
                    sb.Append(HashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}
