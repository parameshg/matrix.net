using Matrix.Serialization;

namespace Matrix.Extension
{
    public static class SerializationExtension
    {
        public static string Serialize<T>(this T o) => new Serializer<T>().Serialize(o);

        public static T Deserialize<T>(this string o) => new Serializer<T>().Deserialize(o);
    }
}