using System;
using System.Windows.Forms;
using stdole;
using System.Drawing;
using System.Runtime.InteropServices;

namespace UpgradeHelpers.Resources
{
    /// <summary>
    /// The Images helper class provides several functions to handle pictures, icons and images.
    /// </summary>
    public class Images
    {
        internal static class ImageNativeMethods
        {
            /// <summary>
            /// CreateIconIndirect function from user32.dll.
            /// </summary>
            [DllImport("user32.dll")]
            internal static extern IntPtr CreateIconIndirect(ref IconInfo icon);

            /// <summary>
            /// GetIconInfo function from user32.dll.
            /// </summary>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        }
       

        /// <summary>
        /// Structure to use to get info for a Icon.
        /// </summary>
        public struct IconInfo
        {
            /// <summary>
            /// use Icon
            /// </summary>
            private bool fIcon;
            /// <summary>
            /// x position
            /// </summary>
            private int xHotspot;
            /// <summary>
            /// y position
            /// </summary>
            private int yHotspot;
            /// <summary>
            /// Pointer to Mask
            /// </summary>
            internal IntPtr HbmMask;
            /// <summary>
            /// Pointer to Palette
            /// </summary>
            internal IntPtr HbmColor;

            /// <summary>
            /// use Icon
            /// </summary>
            public bool FIcon
            {
                get
                {
                    return fIcon;
                }

                set
                {
                    fIcon = value;
                }
            }

            /// <summary>
            /// Position X
            /// </summary>
            public int XHotspot
            {
                get
                {
                    return xHotspot;
                }

                set
                {
                    xHotspot = value;
                }
            }

            /// <summary>
            /// Position Y
            /// </summary>
            public int YHotspot
            {
                get
                {
                    return yHotspot;
                }

                set
                {
                    yHotspot = value;
                }
            }
        }


        /// <summary>
        /// Converts a IPictureDisp to Icon.
        /// </summary>
        /// <param name="iPictureDisp">The picture to be converted.</param>
        /// <returns>The source picture as an Icon.</returns>
        public static Icon IPictureDispToIcon(IPictureDisp iPictureDisp)
        {
            return Icon.FromHandle(new IntPtr(iPictureDisp.Handle));
        }

        /// <summary>
        /// Converts an image into a cursor.
        /// </summary>
        /// <param name="source">The Image to be converted.</param>
        /// <returns>The source image as a Cursor.</returns>
        public static Cursor CreateCursor(Image source)
        {
            Bitmap bmpSource = source as Bitmap ?? new Bitmap(source);

            IconInfo iInfo = new IconInfo();
            ImageNativeMethods.GetIconInfo(bmpSource.GetHicon(), ref iInfo);
            iInfo.XHotspot = 3;
            iInfo.YHotspot = 3;
            iInfo.FIcon = false;

            return new Cursor(ImageNativeMethods.CreateIconIndirect(ref iInfo));
        }

        /// <summary>
        /// Converts a IPictureDisp into a cursor.
        /// </summary>
        /// <param name="source">The source IPicture to be converted.</param>
        /// <returns>The source IPicture as a Cursor.</returns>
        public static Cursor CreateCursor(IPictureDisp source)
        {
            Image sourceImg = null;
            Icon vb6Icon = null;
            try
            {
                sourceImg = UpgradeHelpers.SupportHelper.Support.IPictureToImage(source);
            }
            catch
            {
                try
                {
                    //In the case that the image is an Icon, this will convert it into a Bitmap
                    vb6Icon = IPictureDispToIcon(source);
                    sourceImg = vb6Icon.ToBitmap();
                }
                catch
                {
                    //Empty on purpose to avoid a runtime error
                }
            }

            Cursor res = CreateCursor(sourceImg);

            return res;
        }
    }
}
