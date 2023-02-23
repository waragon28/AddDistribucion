using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;



namespace Forxap.Framework.Utils
{
    internal static class Compression
    {
        internal static byte[] Uncompress(byte[] p)
        {
            MemoryStream output = new MemoryStream();
            MemoryStream ms = new MemoryStream(p);
            using (ZipInputStream zis = new ZipInputStream(ms))
            {
                int size = 2048;
                byte[] data = new byte[size];

                if (zis.GetNextEntry() != null)
                {
                    while (true)
                    {
                        size = zis.Read(data, 0, size);
                        if (size > 0)
                        {
                            output.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return output.ToArray();
        }

        internal static byte[] Compress(byte[] asmBytes)
        {
            MemoryStream ms = new MemoryStream();
            using (ZipOutputStream zos = new ZipOutputStream(ms))
            {
                ZipEntry ze = new ZipEntry("file");
                ze.Size = asmBytes.Length;
                zos.PutNextEntry(ze);
                zos.Write(asmBytes, 0, asmBytes.Length);
                zos.CloseEntry();
            }

            return ms.ToArray();
        }
    }
}
