using System.IO;
using System.IO.Compression;

namespace Matrix.IO.Compression
{
    public class Compressor
    {
        public byte[] Execute(byte[] data, CompressionType type, CompressionAction action)
        {
            byte[] result = null;

            if (type == CompressionType.GZip)
            {
                if (action == CompressionAction.Compress)
                    result = GZipCompression(data);

                if (action == CompressionAction.Decompress)
                    result = GZipDecompression(data);
            }

            if (type == CompressionType.Deflate)
            {
                if (action == CompressionAction.Compress)
                    result = DeflateCompression(data);

                if (action == CompressionAction.Decompress)
                    result = DeflateDecompression(data);
            }

            return result;
        }

        private byte[] GZipCompression(byte[] data)
        {
            byte[] result = null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                using (MemoryStream ouput = new MemoryStream())
                {
                    using (GZipStream compressor = new GZipStream(ouput, CompressionMode.Compress))
                    {
                        stream.CopyTo(compressor);
                        compressor.Close();

                        result = ouput.ToArray();
                    }
                }
            }

            return result;
        }

        private byte[] GZipDecompression(byte[] data)
        {
            byte[] result = null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                using (MemoryStream ouput = new MemoryStream())
                {
                    using (GZipStream compressor = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        compressor.CopyTo(ouput);
                        compressor.Close();

                        result = ouput.ToArray();
                    }
                }
            }

            return result;
        }

        private byte[] DeflateCompression(byte[] data)
        {
            byte[] result = null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                using (MemoryStream ouput = new MemoryStream())
                {
                    using (DeflateStream compressor = new DeflateStream(ouput, CompressionMode.Compress))
                    {
                        stream.CopyTo(compressor);
                        compressor.Close();

                        result = ouput.ToArray();
                    }
                }
            }

            return result;
        }

        private byte[] DeflateDecompression(byte[] data)
        {
            byte[] result = null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                using (MemoryStream ouput = new MemoryStream())
                {
                    using (DeflateStream compressor = new DeflateStream(stream, CompressionMode.Decompress))
                    {
                        compressor.CopyTo(ouput);
                        compressor.Close();

                        result = ouput.ToArray();
                    }
                }
            }

            return result;
        }
    }
}