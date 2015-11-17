using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeoViewer.Utils
{
    public static class ImageUtils
    {
        //Print current picture form
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        /// <summary>
        /// Return Capture Screen (Bitmap file) of a Form Control
        /// </summary>
        /// <param name="ctr"></param>
        /// <returns></returns>
        public static Bitmap CaptureScreen(this Control ctr, int maxWidth = 700)
        {
            //int w = ctr.Size.Width;
            //int h = ctr.Size.Height;

            //if (maxWidth > 0 && w > maxWidth)
            //{
            //    h = h * maxWidth / w;
            //    w = maxWidth;
            //}

            Graphics mygraphics = ctr.CreateGraphics();
            Size s = ctr.Size;
            Bitmap memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();

            
            BitBlt(dc2, 0, 0, ctr.Size.Width, ctr.Size.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            return memoryImage;
        }

    }
}
