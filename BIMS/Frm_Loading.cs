using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Tools ;

namespace BIMS
{
    public partial class Frm_Loading : Form
    {
        private Point mousepoint;
        public Frm_Loading()
        {
            InitializeComponent();
        }

        private void Frm_Loading_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(ImageTools.getImage(@"\新版界面\小弹窗窗体背景阴影加大\littleM (4).png"));
            //Graphics  g = Graphics .FromImage (bitmap );
            //g.DrawImage(ImageTools.getImage(@"\新版界面\小弹窗窗体背景阴影加大\littleM (4).png"), 0, 0);
　　　　　　 SetBits(bitmap);

        }
        #region 调用UpdateLayeredWindow函数

        protected override CreateParams CreateParams
        {//重载窗体的CreateParams方法
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义   
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作
                cp.ExStyle |= 0x00080000; // WS_EX_LAYERED
                return cp;
            }
        }

        public void SetBits(Bitmap bitmap)//调用UpdateLayeredWindow（）方法。this.BackgroundImage为你事先准备的带透明图片。
        {
            //if (!haveHandle) return;

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;
                blendFunc.SourceConstantAlpha = 255;
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 0;

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }

        #endregion

        #region Win32 API声明
        class Win32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Size
            {
                public Int32 cx;
                public Int32 cy;

                public Size(Int32 x, Int32 y)
                {
                    cx = x;
                    cy = y;
                }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Point
            {
                public Int32 x;
                public Int32 y;

                public Point(Int32 x, Int32 y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            public const byte AC_SRC_OVER = 0;
            public const Int32 ULW_ALPHA = 2;
            public const byte AC_SRC_ALPHA = 1;

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

            [DllImport("user32.dll", ExactSpelling = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteDC(IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteObject(IntPtr hObj);

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);
        }
        #endregion

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //mousepoint = e.Location;
            //Console.WriteLine(e.Location);
            //Console.WriteLine(Cursor .Position );
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && pictureBox1 .Region .IsVisible (e.Location ))
            //{
            //    this.Left += e.X - mousepoint.X;
            //    this.Top  += e.Y  - mousepoint.Y ;
            //    //this.Location = new Point(this.Location.X + mousepoint.X - e.Location.X, this.Location.X + mousepoint.Y - e.Location.Y);
            //    Console.WriteLine(e.Location);
            //    Console.WriteLine(this.Location);
            //}
        }



    }
}
