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
            int distanceX = middleClickScrollingOriginPoint.X - currentMouseLocation.X;
            int distanceY = middleClickScrollingOriginPoint.Y - currentMouseLocation.Y;

            if (!VerticalScroll.Visible) distanceY = 0;
            if (!HorizontalScroll.Visible) distanceX = 0;

            var absDistanceX = Math.Abs(distanceX);
            var absDistanceY = Math.Abs(distanceY);

            if (absDistanceX + absDistanceY > 15)
            {
                if (absDistanceX > absDistanceY)
                    middleClickScollDirection = distanceX > 0 ? ScrollDirection.Left : ScrollDirection.Right;
                else
                    middleClickScollDirection = distanceY > 0 ? ScrollDirection.Up : ScrollDirection.Down;
            }
            else
                middleClickScollDirection = ScrollDirection.None;

            switch (middleClickScollDirection)
            {
                case ScrollDirection.Down: base.Cursor = Cursors.PanSouth; break;
                case ScrollDirection.Up: base.Cursor = Cursors.PanNorth; break;
                case ScrollDirection.Right: base.Cursor = Cursors.PanEast; break;
                case ScrollDirection.Left: base.Cursor = Cursors.PanWest; break;
                default: base.Cursor = defaultCursor; return;
            }

            var xScrollOffset = (int)(-distanceX / 5.0);
            var yScrollOffset = (int)(-distanceY / 40.0);

            var xea = new ScrollEventArgs(xScrollOffset < 0 ? ScrollEventType.SmallIncrement : ScrollEventType.SmallDecrement,
                HorizontalScroll.Value,
                HorizontalScroll.Value + xScrollOffset,
                ScrollOrientation.HorizontalScroll);

            switch (middleClickScollDirection)
            {
                case ScrollDirection.Down:
                case ScrollDirection.Up:
                    DoScrollVertical(1 + Math.Abs(yScrollOffset), Math.Sign(distanceY)); break;
                case ScrollDirection.Right:
                case ScrollDirection.Left: 
                    OnScroll(xea); break;
            }

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
