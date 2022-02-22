using JintDPlugin;
using System;

namespace DPlugin1
{
    public class MD5 : IDplugin
    {

        public int Version
        {
            get { return 2022222; }
        }

        public string Name
        {
            get { return "MD5 Library"; }
        }

      

        public string CallResult(string input)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            var s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }
    }

}