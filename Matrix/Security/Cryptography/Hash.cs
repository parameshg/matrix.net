using System.Security.Cryptography;
using System.Text;

namespace Matrix.Security.Cryptography
{
    public static class Hash
    {
        public static string MD5(string data)
        {
            return MD5(Encoding.Default.GetBytes(data));
        }

        public static string MD5(byte[] data)
        {
            var result = string.Empty;

            var buffer = new MD5CryptoServiceProvider().ComputeHash(data);

            result = Hex(buffer);

            return result;
        }

        public static string SHA1(string data)
        {
            return SHA1(Encoding.Default.GetBytes(data));
        }

        public static string SHA1(byte[] data)
        {
            var result = string.Empty;

            var buffer = new SHA1Managed().ComputeHash(data);

            result = Hex(buffer);

            return result;
        }

        public static string SHA256(string data)
        {
            return SHA256(Encoding.Default.GetBytes(data));
        }

        public static string SHA256(byte[] data)
        {
            var result = string.Empty;

            var buffer = new SHA256Managed().ComputeHash(data);

            result = Hex(buffer);

            return result;
        }

        public static string SHA384(string data)
        {
            return SHA384(Encoding.Default.GetBytes(data));
        }

        public static string SHA384(byte[] data)
        {
            var result = string.Empty;

            var buffer = new SHA384Managed().ComputeHash(data);

            result = Hex(buffer);

            return result;
        }

        public static string SHA512(string data)
        {
            return SHA512(Encoding.Default.GetBytes(data));
        }

        public static string SHA512(byte[] data)
        {
            var result = string.Empty;

            var buffer = new SHA512Managed().ComputeHash(data);

            result = Hex(buffer);

            return result;
        }

        private static string Hex(byte[] data)
        {
            var result = string.Empty;

            if (data != null)
            {
                int i;

                var sb = new StringBuilder(data.Length);

                for (i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("X2"));

                result = sb.ToString();
            }

            return result;
        }
    }
}