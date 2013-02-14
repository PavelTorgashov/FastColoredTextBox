using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Timers;

namespace Tester
{
    public partial class GifImageDrawingSample : Form
    {
        GifImageStyle style;
        static string RegexSpecSymbolsPattern = @"[\^\$\[\]\(\)\.\\\*\+\|\?\{\}]";

        public GifImageDrawingSample()
        {
            InitializeComponent();

            style = new GifImageStyle(fctb);
            style.ImagesByText.Add(@":bb", Properties.Resources.bye);
            style.ImagesByText.Add(@":D", Properties.Resources.lol);
            style.ImagesByText.Add(@"8)", Properties.Resources.rolleyes);
            style.ImagesByText.Add(@":@", Properties.Resources.unsure);
            style.ImagesByText.Add(@":)", Properties.Resources.smile_16x16);
            style.ImagesByText.Add(@":(", Properties.Resources.sad_16x16);

            style.StartAnimation();

            fctb.OnTextChanged();
        }

        private void fctb_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (style == null) return;
            e.ChangedRange.ClearStyle(StyleIndex.All);
            foreach (var key in style.ImagesByText.Keys)
            {
                string pattern = Regex.Replace(key, RegexSpecSymbolsPattern, "\\$0");
                e.ChangedRange.SetStyle(style, pattern);
            }
        }
    }

    /// <summary>
    /// This class is used as text renderer for smiles
    /// </summary>
    class GifImageStyle : TextStyle
    {
        public Dictionary<string, Image> ImagesByText { get; private set; }
        FastColoredTextBox parent;
        System.Windows.Forms.Timer timer;

        public GifImageStyle(FastColoredTextBox parent)
            : base(null, null, FontStyle.Regular)
        {
            ImagesByText = new Dictionary<string, Image>();
            this.parent = parent;

            //create timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (EventHandler)delegate
            {
                ImageAnimator.UpdateFrames();
                parent.Invalidate();
            };
            timer.Start();
        }

        public void StartAnimation()
        {
            foreach (var image in ImagesByText.Values)
                if (ImageAnimator.CanAnimate(image))
                    ImageAnimator.Animate(image, new EventHandler(OnFrameChanged));
        }

        void OnFrameChanged(object sender, EventArgs args)
        {
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            string text = range.Text;
            int iChar = range.Start.iChar;

            while (text != "")
            {
                bool replaced = false;
                foreach (var pair in ImagesByText)
                {
                    if (text.StartsWith(pair.Key))
                    {
                        float k = (float)(pair.Key.Length * range.tb.CharWidth) / pair.Value.Width;
                        if (k > 1) 
                            k = 1f;
                        //
                        text = text.Substring(pair.Key.Length);
                        RectangleF rect = new RectangleF(position.X + range.tb.CharWidth * pair.Key.Length / 2 - pair.Value.Width * k/2, position.Y, pair.Value.Width * k, pair.Value.Height * k);
                        gr.DrawImage(pair.Value, rect);
                        position.Offset(range.tb.CharWidth * pair.Key.Length, 0);
                        replaced = true;
                        iChar+=pair.Key.Length;
                        break;
                    }
                }
                if (!replaced && text.Length>0)
                {
                    Range r = new Range(range.tb, iChar, range.Start.iLine, iChar+1, range.Start.iLine);
                    base.Draw(gr, position, r);
                    position.Offset(range.tb.CharWidth, 0);
                    text = text.Substring(1);
                }
            }
        }
    }
}
