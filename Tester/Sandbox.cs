using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Linq;

namespace Tester
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();

            new MultiSelectFCTB(){Parent = this, Dock = DockStyle.Fill};
        }
    }

    public class MultiSelectFCTB : FastColoredTextBox
    {
        /// <summary>
        /// Additional carets (coordinates are given relative to main caret)
        /// </summary>
        public readonly List<Place> AddCarets = new List<Place>();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (ModifierKeys != Keys.Alt)
            {
                AddCarets.Clear();//clear list of additional carets
                base.OnMouseDown(e);
            }
            else
            {
                //add new caret
                var p = PointToPlace(e.Location);
                //calc relative place
                var relativePlace = new Place(p.iChar - Selection.Start.iChar, p.iLine - Selection.Start.iLine);
                AddCarets.Add(relativePlace);
                //redraw
                Invalidate();
            }
        }

        protected override void CheckAndChangeSelectionType()
        {
            //disable column selection mode
            Selection.ColumnSelectionMode = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //draw FCTB
            base.OnPaint(e);

            //draw additional carets
            foreach(var caret in AddCarets)
            {
                var range = GetAddCaretRange(caret);
                if(!range.IsEmpty)
                    SelectionStyle.Draw(e.Graphics, PlaceToPoint(range.Start), range);
                else
                    e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(PlaceToPoint(range.Start), new Size(1, CharHeight)));
            }
        }

        /// <summary>
        /// Returns Range for additional caret
        /// </summary>
        public Range GetAddCaretRange(Place addCaret)
        {
            var range = new Range(this, Selection.Start + addCaret, Selection.End + addCaret);
            return Range.GetIntersectionWith(range);
        }

        /// <summary>
        /// Here we assign own CommandManager
        /// </summary>
        protected override TextSource CreateTextSource()
        {
            var ts = base.CreateTextSource();
            //assign custom command manager
            ts.Manager = new MultiSelectCommandManager(ts);
            return ts;
        }
    }

    /// <summary>
    /// Custom CommandManager.
    /// This class creates wrapper for commands when additional carets are presented.
    /// </summary>
    public class MultiSelectCommandManager: CommandManager
    {
        public MultiSelectCommandManager(TextSource ts):base(ts)
        {
        }

        public override void ExecuteCommand(Command cmd)
        {
            if (disabledCommands > 0)
                return;

            var fctb = TextSource.CurrentTB as MultiSelectFCTB;
            if(fctb.AddCarets.Count != 0)
            {
                //multirange ?
                if (cmd.ts.CurrentTB.Selection.ColumnSelectionMode)
                    return;//we do not suppport column selection mode with multiselect mode

                //make wrapper
                if (cmd is UndoableCommand)
                    cmd = new MultiSelectionCommand((UndoableCommand)cmd);
            }

            base.ExecuteCommand(cmd);
        }
    }

    /// <summary>
    /// Wrapper for commands when MultiSelection mode enabled.
    /// This class is very like to MultiRangeCommand, but it is intended for MultiSelection mode.
    /// </summary>
    public class MultiSelectionCommand : UndoableCommand
    {
        private UndoableCommand cmd;
        private List<Range> ranges = new List<Range>();
        private List<UndoableCommand> commandsByRanges = new List<UndoableCommand>();

        public MultiSelectionCommand(UndoableCommand command)
            : base(command.ts)
        {
            this.cmd = command;
            var fctb = ts.CurrentTB as MultiSelectFCTB;
            //remember ranges for all carets
            foreach (var caret in fctb.AddCarets)
                ranges.Add(fctb.GetAddCaretRange(caret));

            ranges.Add(ts.CurrentTB.Selection.Clone());
        }

        public override void Execute()
        {
            commandsByRanges.Clear();
            var iChar = -1;
            ts.CurrentTB.Selection.ColumnSelectionMode = false;
            ts.CurrentTB.Selection.BeginUpdate();
            ts.CurrentTB.BeginUpdate();
            ts.CurrentTB.AllowInsertRemoveLines = false;
            try
            {
                if (cmd is InsertTextCommand)
                    ExecuteInsertTextCommand(ref iChar, (cmd as InsertTextCommand).InsertedText);
                else
                if (cmd is InsertCharCommand && (cmd as InsertCharCommand).c != '\x0' && (cmd as InsertCharCommand).c != '\b')//if not DEL or BACKSPACE
                    ExecuteInsertTextCommand(ref iChar, (cmd as InsertCharCommand).c.ToString());
                else
                    ExecuteCommand(ref iChar);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            finally
            {
                ts.CurrentTB.AllowInsertRemoveLines = true;
                ts.CurrentTB.EndUpdate();
                ts.CurrentTB.Selection.EndUpdate();
            }
        }

        public Range MainRange
        {
            get { return ranges[ranges.Count - 1]; }
        }

        private void ExecuteInsertTextCommand(ref int iChar, string text)
        {
            var lines = text.Split('\n');
            foreach (var r in ranges)
            {
                var line = ts.CurrentTB[r.Start.iLine];
                var lineIsEmpty = r.End < r.Start && line.StartSpacesCount == line.Count;
                if (!lineIsEmpty)
                {
                    var insertedText = lines[0];
                    if (r.End < r.Start && insertedText != "")
                    {
                        //add forwarding spaces
                        insertedText = new string(' ', r.Start.iChar - r.End.iChar) + insertedText;
                        r.Start = r.End;
                    }
                    ts.CurrentTB.Selection = r;
                    var c = new InsertTextCommand(ts, insertedText);
                    c.Execute();
                    if (ts.CurrentTB.Selection.End.iChar > iChar)
                        iChar = ts.CurrentTB.Selection.End.iChar;
                    commandsByRanges.Add(c);
                }
            }
        }

        private void ExecuteCommand(ref int iChar)
        {
            foreach (var r in ranges)
            {
                ts.CurrentTB.Selection = r;
                var c = cmd.Clone();
                c.Execute();
                if (ts.CurrentTB.Selection.End.iChar > iChar)
                    iChar = ts.CurrentTB.Selection.End.iChar;
                commandsByRanges.Add(c);
            }
        }

        public override void Undo()
        {
            ts.CurrentTB.BeginUpdate();
            ts.CurrentTB.Selection.BeginUpdate();
            try
            {
                for (int i = commandsByRanges.Count - 1; i >= 0; i--)
                    commandsByRanges[i].Undo();
            }
            finally
            {
                ts.CurrentTB.Selection.EndUpdate();
                ts.CurrentTB.EndUpdate();
            }
            ts.CurrentTB.Selection = MainRange.Clone();
            foreach(var r in ranges)
                ts.CurrentTB.OnTextChanged(r);
            ts.CurrentTB.OnSelectionChanged();
            ts.CurrentTB.Selection.ColumnSelectionMode = false;
        }

        public override UndoableCommand Clone()
        {
            throw new NotImplementedException();
        }
    }
}