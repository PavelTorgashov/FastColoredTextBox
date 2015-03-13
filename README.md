FastColoredTextBox
==================

Fast Colored TextBox is text editor component for .NET.
Allows you to create custom text editor with syntax highlighting.
It works well with small, medium, large and very-very large files.

It has such settings as foreground color, font style, background color which can be adjusted for arbitrarily selected text symbols. One can easily gain access to a text with the use of regular expressions. WordWrap, Find/Replace, Code folding and multilevel Undo/Redo are supported as well. 

![Fast Colored TextBox](http://www.codeproject.com/KB/edit/FastColoredTextBox_/fastcoloredtextbox2.png)

More details http://www.codeproject.com/Articles/161871/Fast-Colored-TextBox-for-syntax-highlighting

Nuget package https://www.nuget.org/packages/FCTB/

Changes by Firda
================
* `LinkedTextBox` - create group of editors sharing text source (no master, all are equal and you can remove any of them any time without breaking the remaining).
* `SupportTabs` - this feature is currently in separate branch because I am still not satisfied (e.g. mouse clicks need more work), but seems to work quite well for now (moving around by arrows feels good, natural).
  - Beware to use `SaveToFile` and/or `Line.GetCleanText()` because `FCTB.Text` will still return internal representation (spaces before tabs).
  - Painting and syntax highlighting works fine if you use e.g. `\s+` in your regular expressions (which is normal).
* Minor changes and bugfixes:
  - `InitTextSource` had a bug that was causing strange effects after `SourceTextBox = null` and futher manipulation with the box that was slave before.
  - `BackColor = SystemColors.Window` instead of `Colors.White` because of themes (sometimes I use dark/black or light gray in system colors when my eyes hurt). 
