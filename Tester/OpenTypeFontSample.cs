using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class OpenTypeFontSample : Form
    {
        public OpenTypeFontSample()
        {
            InitializeComponent();
        }

        
        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFont.SelectedItem == null)
                return;

            var item = (ENUMLOGFONTEX)cbFont.SelectedItem;
            if (cbSize.SelectedItem != null)
            {
                item.elfLogFont.lfHeight = int.Parse(cbSize.SelectedItem.ToString());
                item.elfLogFont.lfWidth = item.elfLogFont.lfHeight / 2;
            }
            fctb.DefaultStyle = new OpenTypeFontStyle(fctb, item.elfLogFont);
            fctb.Invalidate();
        }

        #region Build OpenType font list

        List<ENUMLOGFONTEX> fontList = new List<ENUMLOGFONTEX>();

        protected override void OnLoad(EventArgs e)
        {
            //build list of OpenType fonts
            LOGFONT lf = new LOGFONT();

            IntPtr plogFont = Marshal.AllocHGlobal(Marshal.SizeOf(lf));
            Marshal.StructureToPtr(lf, plogFont, true);

            try
            {
                fontList.Clear();
                using (Graphics G = CreateGraphics())
                {
                    IntPtr P = G.GetHdc();
                    EnumFontFamiliesEx(P, plogFont, Callback, IntPtr.Zero, 0);
                    G.ReleaseHdc(P);
                }
            }
            finally
            {
                Marshal.DestroyStructure(plogFont, typeof(LOGFONT));
            }

            //sort fonts
            fontList.Sort((f1, f2)=>f1.elfFullName.CompareTo(f2.elfFullName));
            //build combobox
            cbFont.Items.Clear();
            foreach(var item in fontList)
                cbFont.Items.Add(item);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        static extern int EnumFontFamiliesEx(IntPtr hdc, [In] IntPtr pLogfont, EnumFontExDelegate lpEnumFontFamExProc, IntPtr lParam, uint dwFlags);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct NEWTEXTMETRIC
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public char tmFirstChar;
            public char tmLastChar;
            public char tmDefaultChar;
            public char tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
            int ntmFlags;
            int ntmSizeEM;
            int ntmCellHeight;
            int ntmAvgWidth;
        }

        public struct FONTSIGNATURE
        {
            [MarshalAs(UnmanagedType.ByValArray)]
            int[] fsUsb;
            [MarshalAs(UnmanagedType.ByValArray)]
            int[] fsCsb;
        }
        public struct NEWTEXTMETRICEX
        {
            NEWTEXTMETRIC ntmTm;
            FONTSIGNATURE ntmFontSig;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ENUMLOGFONTEX
        {
            public LOGFONT elfLogFont;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string elfFullName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string elfStyle;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string elfScript;


            public override string ToString()
            {
                return elfFullName;
            }
        }

        const int RASTER_FONTTYPE = 1;
        const int DEVICE_FONTTYPE = 2;
        const int TRUETYPE_FONTTYPE = 4;

        delegate int EnumFontExDelegate(ref ENUMLOGFONTEX lpelfe, ref NEWTEXTMETRICEX lpntme, int fontType, int lParam);
        int cnt;

        public int Callback(ref ENUMLOGFONTEX lpelfe, ref NEWTEXTMETRICEX lpntme, int fontType, int lParam)
        {
            try
            {
                cnt++;
                if (fontType != TRUETYPE_FONTTYPE)
                    fontList.Add(lpelfe);
            }
            catch{}
            return cnt;
        }

        #endregion

    }

    /// <summary>
    /// Text renderer for OpenType fonts (uses GDI rendering)
    /// </summary>
    public class OpenTypeFontStyle : TextStyle
    {
        readonly LOGFONT font;

        public OpenTypeFontStyle(FastColoredTextBox fctb, LOGFONT font): base(null, null, FontStyle.Regular)
        {
            this.font = font;
            //measure font
            using (var gr = fctb.CreateGraphics())
            {
                var HDC = gr.GetHdc();

                var fontHandle = CreateFontIndirect(font);
                var f = SelectObject(HDC, fontHandle);

                var measureSize = new Size(0, 0);

                try
                {
                    GetTextExtentPoint(HDC, "M", 1, ref measureSize);
                }
                finally
                {
                    DeleteObject(SelectObject(HDC, f));
                    gr.ReleaseHdc(HDC);
                }

                fctb.CharWidth = measureSize.Width;
                fctb.CharHeight = measureSize.Height + fctb.LineInterval;
                fctb.NeedRecalc(true, true);
            }
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFontIndirect([In, MarshalAs(UnmanagedType.LPStruct)] LOGFONT lplf);
        [DllImport("gdi32.dll")]
        static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);
        [DllImport("gdi32.dll")]
        static extern bool GetTextExtentPoint(IntPtr hdc, string lpString, int cbString, ref Size lpSize);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr objectHandle);
        [DllImport("gdi32.dll")]
        public static extern int SetBkColor(IntPtr hDC, int crColor);
        [DllImport("gdi32.dll")]
        static extern uint SetTextColor(IntPtr hdc, int crColor);


        public override void Draw(Graphics gr, Point position, Range range)
        {
            //create font
            IntPtr HDC = gr.GetHdc();
            var fontHandle = CreateFontIndirect(font);
            var f = SelectObject(HDC, fontHandle);
            //set foreground and background colors
            SetTextColor(HDC, ColorTranslator.ToWin32(range.tb.ForeColor));
            SetBkColor(HDC, ColorTranslator.ToWin32(range.tb.BackColor));

            
            //draw background
            if (BackgroundBrush != null)
                gr.FillRectangle(BackgroundBrush, position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);

            //coordinates
            var y = position.Y + range.tb.LineInterval / 2;
            var x = position.X;
            int dx = range.tb.CharWidth;

            //draw chars
            try
            {
                var s = range.Text;
                foreach (var c in s)
                {
                    TextOut(HDC, x, y, c.ToString(), 1);
                    x += dx;
                }
            }
            finally
            {
                DeleteObject(SelectObject(HDC, f));
                gr.ReleaseHdc(HDC);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class LOGFONT
    {
        public const int LF_FACESIZE = 32;
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
        public string lfFaceName;
    }
}
