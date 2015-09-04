using System;
using System.IO;
using Pfim;
using System.Runtime.InteropServices;

namespace SageCS.Core.Loaders
{
    struct ImageData
    {
        public int width;
        public int height;
        public byte[] data;
        public OpenTK.Graphics.OpenGL4.PixelFormat format;
    }

    class ImageLoader
    {
        private static ImageData FromPfimImg(IImage image)
        {
            ImageData img = new ImageData();
            img.data = image.Data;
            img.width = image.Width;
            img.height = image.Height;
            img.format = FromPfimFormat(image.Format);
            return img;
        }

        private static OpenTK.Graphics.OpenGL4.PixelFormat FromPfimFormat(ImageFormat f)
        {
            if (f == ImageFormat.Rgb24)
                return OpenTK.Graphics.OpenGL4.PixelFormat.Bgr;
            else if (f == ImageFormat.Rgba32)
                return OpenTK.Graphics.OpenGL4.PixelFormat.Bgra;

            throw new Exception("Unknown Image format");
        }

        private static ImageData FromBitmap(System.Drawing.Bitmap image)
        {
            ImageData img = new ImageData();
            img.data = BitmapToByteArray(image);
            img.width = image.Width;
            img.height = image.Height;
            img.format = FromPixelformat(image.PixelFormat);

            return img;
        }

        private static OpenTK.Graphics.OpenGL4.PixelFormat FromPixelformat(System.Drawing.Imaging.PixelFormat pf)
        {
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                return OpenTK.Graphics.OpenGL4.PixelFormat.Bgra;
            else if (pf == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                return OpenTK.Graphics.OpenGL4.PixelFormat.Bgr;

            throw new Exception("Unknown Image format");
        }

        private static byte[] BitmapToByteArray(System.Drawing.Bitmap bitmap)
        {

            System.Drawing.Imaging.BitmapData bmpdata = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            int numbytes = bmpdata.Stride * bitmap.Height;
            byte[] bytedata = new byte[numbytes];
            IntPtr ptr = bmpdata.Scan0;

            Marshal.Copy(ptr, bytedata, 0, numbytes);

            bitmap.UnlockBits(bmpdata);

            return bytedata;
        }

        public static ImageData Load(Stream s)
        {
            ImageData img;
            BinaryReader br = new BinaryReader(s);
            var magic = br.ReadUInt32();
            s.Position = 0;
            if (magic== 0xE0FFD8FF)
            {             
                System.Drawing.Bitmap image = new System.Drawing.Bitmap(s);
                img = FromBitmap(image);
            }
            else if(magic == 0x20534444)
            {
                IImage image = Dds.Create(s);
                img = FromPfimImg(image);
            }
            //tga image
            else
            {
                IImage image = Targa.Create(s);
                img = FromPfimImg(image);
            }
            return img;
        }
    }
}
