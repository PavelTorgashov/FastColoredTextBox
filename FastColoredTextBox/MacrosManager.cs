using System.Collections.Generic;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    /// <summary>
    /// This class records, stores and executes the macros.
    /// </summary>
    public class MacrosManager
    {
        private readonly List<KeyValuePair<object, Keys>> macro = new List<KeyValuePair<object, Keys>>();

        internal MacrosManager(FastColoredTextBox ctrl)
        {
            ActivateRecordingKey = Keys.M | Keys.Control;
            ExecutingKey = Keys.E | Keys.Control;

            UnderlayingControl = ctrl;
            AllowMacroRecordingByUser = true;
        }

        /// <summary>
        /// Keys combination for record activate/deactivate
        /// </summary>
        public Keys ActivateRecordingKey { get; set; }
        /// <summary>
        /// Keys combination for executing of the macros
        /// </summary>
        public Keys ExecutingKey { get; set; }

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
            UnderlayingControl.BeginAutoUndo();
            foreach (var item in macro)
            {
                if (item.Key is Keys)
                    UnderlayingControl.ProcessKey((Keys) item.Key, item.Value);
                if (item.Key is char)
                    UnderlayingControl.ProcessKey((char) item.Key, item.Value);
            }
            UnderlayingControl.EndAutoUndo();

            return false;
        }

        private void Add(object key, Keys modifiers)
        {
            macro.Add(new KeyValuePair<object, Keys>(key, modifiers));
        }

        /// <summary>
        /// Adds the char to current macro
        /// </summary>
        public void AddCharToMacros(char c, Keys modifiers)
        {
            Add(c, modifiers);
        }

        /// <summary>
        /// Adds keyboard key to current macro
        /// </summary>
        public void AddKeyToMacros(Keys key, Keys modifiers)
        {
            Add(key, modifiers);
        }

        /// <summary>
        /// Clears last recorded macro
        /// </summary>
        public void ClearMacros()
        {
            macro.Clear();
        }


        internal bool ProcessKey(Keys keyCode, Keys modifiers)
        {
            if ((keyCode | modifiers) == ActivateRecordingKey && AllowMacroRecordingByUser)
            {
                IsRecording = !IsRecording;
                if (IsRecording)
                    ClearMacros();
                return true;
            }

            if (keyCode == Keys.Escape)
            {
                IsRecording = false;
                return false;
            }

            if ((keyCode | modifiers) == ExecutingKey && AllowMacroRecordingByUser)
            {
                IsRecording = false;
                ExecuteMacros();
                return true;
            }
            if (IsRecording)
            {
                AddKeyToMacros(keyCode, modifiers);
                return false;
            }

            return false;
        }

        internal bool ProcessKey(char c, Keys modifiers)
        {
            if (IsRecording)
            {
                AddCharToMacros(c, modifiers);
                return false;
            }

            return false;
        }

        /// <summary>
        /// Returns True if last macro is empty
        /// </summary>
        public bool MacroIsEmpty { get { return macro.Count == 0; }}
    }
}