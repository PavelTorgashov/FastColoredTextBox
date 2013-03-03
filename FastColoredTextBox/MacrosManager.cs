using System.Collections.Generic;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    /// <summary>
    /// This class records, stores and executes the macros.
    /// </summary>
    public class MacrosManager
    {
        private readonly List<object> macro = new List<object>();

        internal MacrosManager(FastColoredTextBox ctrl)
        {
            UnderlayingControl = ctrl;
            AllowMacroRecordingByUser = true;
        }

        /// <summary>
        /// Allows to user to record macros
        /// </summary>
        public bool AllowMacroRecordingByUser { get;set; }

        private bool isRecording;

        /// <summary>
        /// Returns current recording state. Set to True/False to start/stop recording programmatically.
        /// </summary>
        public bool IsRecording
        {
            get { return isRecording; }
            set { isRecording = value; UnderlayingControl.Invalidate(); }
        }

        /// <summary>
        /// FCTB
        /// </summary>
        public FastColoredTextBox UnderlayingControl { get; private set; }

        /// <summary>
        /// Executes recorded macro
        /// </summary>
        /// <returns></returns>
        public bool ExecuteMacros()
        {
            IsRecording = false;
            UnderlayingControl.BeginUpdate();
            UnderlayingControl.Selection.BeginUpdate();
            UnderlayingControl.BeginAutoUndo();
            foreach (var item in macro)
            {
                if (item is Keys)
                {
                    UnderlayingControl.ProcessKey((Keys)item);
                }
                if (item is KeyValuePair<char, Keys>)
                {
                    var p = (KeyValuePair<char, Keys>)item;
                    UnderlayingControl.ProcessKey(p.Key, p.Value);
                }
                
            }
            UnderlayingControl.EndAutoUndo();
            UnderlayingControl.Selection.EndUpdate();
            UnderlayingControl.EndUpdate();

            return false;
        }

        /// <summary>
        /// Adds the char to current macro
        /// </summary>
        public void AddCharToMacros(char c, Keys modifiers)
        {
            macro.Add(new KeyValuePair<char, Keys>(c, modifiers));
        }

        /// <summary>
        /// Adds keyboard key to current macro
        /// </summary>
        public void AddKeyToMacros(Keys keyData)
        {
            macro.Add(keyData);
        }

        /// <summary>
        /// Clears last recorded macro
        /// </summary>
        public void ClearMacros()
        {
            macro.Clear();
        }


        internal void ProcessKey(Keys keyData)
        {
            if (IsRecording)
                AddKeyToMacros(keyData);
        }

        internal void ProcessKey(char c, Keys modifiers)
        {
            if (IsRecording)
                AddCharToMacros(c, modifiers);
        }

        /// <summary>
        /// Returns True if last macro is empty
        /// </summary>
        public bool MacroIsEmpty { get { return macro.Count == 0; }}
    }
}