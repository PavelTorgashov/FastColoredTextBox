//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pavel_torgashov@ukr.net.
//
//  Copyright (C) Pavel Torgashov, 2011-2014. 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    public class PaintLineEventArgs : PaintEventArgs
    {
        public PaintLineEventArgs(int iLine, Rectangle rect, Graphics gr, Rectangle clipRect)
            : base(gr, clipRect)
        {
            LineIndex = iLine;
            LineRect = rect;
        }

        public int LineIndex { get; private set; }
        public Rectangle LineRect { get; private set; }
    }

    public class LineInsertedEventArgs : EventArgs
    {
        public LineInsertedEventArgs(int index, int count)
        {
            Index = index;
            Count = count;
        }

        /// <summary>
        /// Inserted line index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Count of inserted lines
        /// </summary>
        public int Count { get; private set; }
    }

    public class LineRemovedEventArgs : EventArgs
    {
        public LineRemovedEventArgs(int index, int count, List<int> removedLineIds)
        {
            Index = index;
            Count = count;
            RemovedLineUniqueIds = removedLineIds;
        }

        /// <summary>
        /// Removed line index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Count of removed lines
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// UniqueIds of removed lines
        /// </summary>
        public List<int> RemovedLineUniqueIds { get; private set; }
    }



    /// <summary>
    /// TextChanged event argument
    /// </summary>
    public class TextChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TextChangedEventArgs(Range changedRange)
        {
            ChangedRange = changedRange;
        }

        /// <summary>
        /// This range contains changed area of text
        /// </summary>
        public Range ChangedRange { get; set; }
    }

    public class TextChangingEventArgs : EventArgs
    {
        public string InsertingText { get; set; }

        /// <summary>
        /// Set to true if you want to cancel text inserting
        /// </summary>
        public bool Cancel { get; set; }
    }

    public class WordWrapNeededEventArgs : EventArgs
    {
        public List<int> CutOffPositions { get; private set; }
        public bool ImeAllowed { get; private set; }
        public Line Line { get; private set; }

        public WordWrapNeededEventArgs(List<int> cutOffPositions, bool imeAllowed, Line line)
        {
            this.CutOffPositions = cutOffPositions;
            this.ImeAllowed = imeAllowed;
            this.Line = line;
        }
    }


    public class AutoIndentEventArgs : EventArgs
    {
        public AutoIndentEventArgs(int iLine, string lineText, string prevLineText, int tabLength, int currentIndentation)
        {
            this.iLine = iLine;
            LineText = lineText;
            PrevLineText = prevLineText;
            TabLength = tabLength;
            AbsoluteIndentation = currentIndentation;
        }

        public int iLine { get; internal set; }
        public int TabLength { get; internal set; }
        public string LineText { get; internal set; }
        public string PrevLineText { get; internal set; }

        /// <summary>
        /// Additional spaces count for this line, relative to previous line
        /// </summary>
        public int Shift { get; set; }

        /// <summary>
        /// Additional spaces count for next line, relative to previous line
        /// </summary>
        public int ShiftNextLines { get; set; }

        /// <summary>
        /// Absolute indentation of current line. You can change this property if you want to set absolute indentation.
        /// </summary>
        public int AbsoluteIndentation { get; set; }
    }

    /// <summary>
    /// ToolTipNeeded event args
    /// </summary>
    public class ToolTipNeededEventArgs : EventArgs
    {
        public ToolTipNeededEventArgs(Place place, string hoveredWord)
        {
            HoveredWord = hoveredWord;
            Place = place;
        }

        public Place Place { get; private set; }
        public string HoveredWord { get; private set; }
        public string ToolTipTitle { get; set; }
        public string ToolTipText { get; set; }
        public ToolTipIcon ToolTipIcon { get; set; }
    }

    /// <summary>
    /// HintClick event args
    /// </summary>
    public class HintClickEventArgs : EventArgs
    {
        public HintClickEventArgs(Hint hint)
        {
            Hint = hint;
        }

        public Hint Hint { get; private set; }
    }

    /// <summary>
    /// CustomAction event args
    /// </summary>
    public class CustomActionEventArgs : EventArgs
    {
        public FCTBAction Action { get; private set; }

        public CustomActionEventArgs(FCTBAction action)
        {
            Action = action;
        }
    }
}
