using System;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace Tester
{
    public partial class BookmarksSample : Form
    {
        public BookmarksSample()
        {
            InitializeComponent();
        }

        private void btAddBookmark_Click(object sender, EventArgs e)
        {
            fctb.Bookmarks.Add(fctb.Selection.Start.iLine);
        }

        private void btRemoveBookmark_Click(object sender, EventArgs e)
        {
            fctb.Bookmarks.Remove(fctb.Selection.Start.iLine);
        }

        private void btGo_DropDownOpening(object sender, EventArgs e)
        {
            btGo.DropDownItems.Clear();
            foreach (var bookmark in fctb.Bookmarks)
            {
                var item = btGo.DropDownItems.Add(bookmark.Name);
                item.Tag = bookmark;
                item.Click += (o, a) => ((Bookmark)(o as ToolStripItem).Tag).DoVisible();
            }
        }
    }
}
