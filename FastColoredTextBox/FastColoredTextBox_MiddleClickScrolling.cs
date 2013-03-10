using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    partial class FastColoredTextBox
    {
        private bool middleClickScrollingActivated;
        private Point middleClickScrollingOriginPoint;
        private Point middleClickScrollingOriginScroll;
        private readonly Timer middleClickScrollingTimer = new Timer();
        private ScrollDirection middleClickScollDirection = ScrollDirection.None;

        /// <summary>
        /// Activates the scrolling mode (middle click button).
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        private void ActivateMiddleClickScrollingMode(MouseEventArgs e)
        {
            if (!middleClickScrollingActivated)
            {
                if ((!HorizontalScroll.Visible) && (!VerticalScroll.Visible))
                    return;
                middleClickScrollingActivated = true;
                middleClickScrollingOriginPoint = e.Location;
                middleClickScrollingOriginScroll = new Point(HorizontalScroll.Value, VerticalScroll.Value);
                middleClickScrollingTimer.Interval = 50;
                middleClickScrollingTimer.Enabled = true;
                Capture = true;
                // Refresh the control 
                Refresh();
                // Disable drawing
                SendMessage(Handle, WM_SETREDRAW, 0, 0);
            }
        }

        /// <summary>
        /// Deactivates the scrolling mode (middle click button).
        /// </summary>
        private void DeactivateMiddleClickScrollingMode()
        {
            if (middleClickScrollingActivated)
            {
                middleClickScrollingActivated = false;
                middleClickScrollingTimer.Enabled = false;
                Capture = false;
                base.Cursor = defaultCursor;
                // Enable drawing
                SendMessage(Handle, WM_SETREDRAW, 1, 0);
                Invalidate();
            }
        }

        /// <summary>
        /// Restore scrolls
        /// </summary>
        private void RestoreScrollsAfterMiddleClickScrollingMode()
        {
            var xea = new ScrollEventArgs(ScrollEventType.ThumbPosition,
                HorizontalScroll.Value,
                middleClickScrollingOriginScroll.X,
                ScrollOrientation.HorizontalScroll);
            OnScroll(xea);

            var yea = new ScrollEventArgs(ScrollEventType.ThumbPosition,
                VerticalScroll.Value,
                middleClickScrollingOriginScroll.Y,
                ScrollOrientation.VerticalScroll);
            OnScroll(yea);
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SETREDRAW = 0xB;    

        void middleClickScrollingTimer_Tick(object sender, EventArgs e)
        {
            if (IsDisposed)
                return;

            if (!middleClickScrollingActivated)
                return;

            Point currentMouseLocation = PointToClient(Cursor.Position);

            Capture = true;

            // Calculate angle and distance between current position point and origin point
            int distanceX = this.middleClickScrollingOriginPoint.X - currentMouseLocation.X;
            int distanceY = this.middleClickScrollingOriginPoint.Y - currentMouseLocation.Y;

            if (!VerticalScroll.Visible) distanceY = 0;
            if (!HorizontalScroll.Visible) distanceX = 0;

            double angleInDegree = 180 - Math.Atan2(distanceY, distanceX) * 180 / Math.PI;
            double distance = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

            // determine scrolling direction depending on the angle
            if (distance > 10)
            {
                if (angleInDegree >= 325 || angleInDegree <= 35)
                    this.middleClickScollDirection = ScrollDirection.Right;
                else if (angleInDegree <= 55)
                    this.middleClickScollDirection = ScrollDirection.Right | ScrollDirection.Up;
                else if (angleInDegree <= 125)
                    this.middleClickScollDirection = ScrollDirection.Up;
                else if (angleInDegree <= 145)
                    this.middleClickScollDirection = ScrollDirection.Up | ScrollDirection.Left;
                else if (angleInDegree <= 215)
                    this.middleClickScollDirection = ScrollDirection.Left;
                else if (angleInDegree <= 235)
                    this.middleClickScollDirection = ScrollDirection.Left | ScrollDirection.Down;
                else if (angleInDegree <= 305)
                    this.middleClickScollDirection = ScrollDirection.Down;
                else
                    this.middleClickScollDirection = ScrollDirection.Down | ScrollDirection.Right;
            }
            else
            {
                this.middleClickScollDirection = ScrollDirection.None;
            }

            // Set mouse cursor
            switch (this.middleClickScollDirection)
            {
                case ScrollDirection.Right: base.Cursor = Cursors.PanEast; break;
                case ScrollDirection.Right | ScrollDirection.Up: base.Cursor = Cursors.PanNE; break;
                case ScrollDirection.Up: base.Cursor = Cursors.PanNorth; break;
                case ScrollDirection.Up | ScrollDirection.Left: base.Cursor = Cursors.PanNW; break;
                case ScrollDirection.Left: base.Cursor = Cursors.PanWest; break;
                case ScrollDirection.Left | ScrollDirection.Down: base.Cursor = Cursors.PanSW; break;
                case ScrollDirection.Down: base.Cursor = Cursors.PanSouth; break;
                case ScrollDirection.Down | ScrollDirection.Right: base.Cursor = Cursors.PanSE; break;
                default: base.Cursor = defaultCursor; return;
            }

            var xScrollOffset = (int)(-distanceX / 5.0);
            var yScrollOffset = (int)(-distanceY / 5.0);

            var xea = new ScrollEventArgs(xScrollOffset < 0 ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement,
                HorizontalScroll.Value,
                HorizontalScroll.Value + xScrollOffset,
                ScrollOrientation.HorizontalScroll);

            var yea = new ScrollEventArgs(yScrollOffset < 0 ? ScrollEventType.SmallDecrement: ScrollEventType.SmallIncrement,
                VerticalScroll.Value,
                VerticalScroll.Value + yScrollOffset,
                ScrollOrientation.VerticalScroll);

            if((middleClickScollDirection & (ScrollDirection.Down | ScrollDirection.Up)) > 0)
                    //DoScrollVertical(1 + Math.Abs(yScrollOffset), Math.Sign(distanceY));
                    OnScroll(yea, false);

            if((middleClickScollDirection & (ScrollDirection.Right | ScrollDirection.Left)) > 0)
                    OnScroll(xea);

            // Enable drawing
            SendMessage(Handle, WM_SETREDRAW, 1, 0);
            // Refresh the control 
            Refresh();
            // Disable drawing
            SendMessage(Handle, WM_SETREDRAW, 0, 0);
        }

        private void DrawMiddleClickScrolling(Graphics gr)
        {
            // If mouse scrolling mode activated draw the scrolling cursor image
            bool ableToScrollVertically = this.VerticalScroll.Visible;
            bool ableToScrollHorizontally = this.HorizontalScroll.Visible;

            // Calculate inverse color
            Color inverseColor = Color.FromArgb(100, (byte)~this.BackColor.R, (byte)~this.BackColor.G, (byte)~this.BackColor.B);
            using (SolidBrush inverseColorBrush = new SolidBrush(inverseColor))
            {
                var p = middleClickScrollingOriginPoint;

                var state = gr.Save();

                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.TranslateTransform(p.X, p.Y);
                gr.FillEllipse(inverseColorBrush, -2, -2, 4, 4);

                if (ableToScrollVertically) DrawTriangle(gr, inverseColorBrush);
                gr.RotateTransform(90);
                if (ableToScrollHorizontally) DrawTriangle(gr, inverseColorBrush);
                gr.RotateTransform(90);
                if (ableToScrollVertically) DrawTriangle(gr, inverseColorBrush);
                gr.RotateTransform(90);
                if (ableToScrollHorizontally) DrawTriangle(gr, inverseColorBrush);

                gr.Restore(state);
            }
        }

        private void DrawTriangle(Graphics g, Brush brush)
        {
            const int size = 5;
            var points = new Point[] { new Point(size, 2 * size), new Point(0, 3 * size), new Point(-size, 2 * size) };
            g.FillPolygon(brush, points);
        }
    }

    /// <summary>
    /// Defined direction.
    /// </summary>
    [Flags]
    public enum ScrollDirection : ushort
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 4,
        Down = 8
    }
}
