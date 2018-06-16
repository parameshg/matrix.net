using Matrix.Security.Cryptography;

namespace Matrix.Extension
{
    public static class SecurityExtension
    {
        public static string MD5(this string data) => Hash.MD5(data);

        public static string MD5(this byte[] data) => Hash.MD5(data);

        public static string SHA1(this string data) => Hash.SHA1(data);

        public static string SHA1(this byte[] data) => Hash.SHA1(data);

        public static string SHA256(this string data) => Hash.SHA256(data);

        public static string SHA256(this byte[] data) => Hash.SHA256(data);

        public static string SHA384(this string data) => Hash.SHA384(data);

        public static string SHA384(this byte[] data) => Hash.SHA384(data);

        public static string SHA512(this string data) => Hash.SHA512(data);

        public static string SHA512(this byte[] data) => Hash.SHA512(data);
    }
}