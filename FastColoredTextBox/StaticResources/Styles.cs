using System.Drawing;

namespace FastColoredTextBoxNS
{
    public static class Styles
    {
        public static Style BlueBoldStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        public static Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        public static Style BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        public static Style BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        public static Style GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        public static Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        public static Style MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        public static Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        public static Style RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        public static Style BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
    }
}
