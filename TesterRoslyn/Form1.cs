using FastColoredTextBoxNS;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
using TesterRoslyn.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesterRoslyn
{
    public partial class Form1 : Form
    {
        // Roslyn stuff...
        // Roslyn maintains its own copy of the document text.
        // Note that Project, Document, SourceText and ImmutableArray are all immutable.
        public MSBuildWorkspace CurrentWorkspace;
        public Project CurrentProject;
        public Document CurrentDocument;
        public SourceText CurrentText;
        public ImmutableArray<Diagnostic> CurrentDiagnostics;

        // FastColoredTextBox stuff...
        // FastColoredTextBox also maintains its own copy of the document text, and we work to ensure
        // that the Roslyn version is an exact 1:1 copy of the FastColoredTextBox copy. To keep them in sync,
        // Roslyn needs to know for each text-change-notification what was the previous text-span, and what is
        // the replacement text that goes there. This gives rise to some challenges:
        // (1) The FastColoredTextBox events don't provide information about the previous span. The
        //     most efficient way for us to recover that information is to keep our own cached copy of all
        //     line lengths for the document. When we get a TextChanged event, we can use our cached copy
        //     to know what the old span was. This of course requires us to keep our cached copy in 1:1 sync
        //     with those of FastColoredTextBox.
        // (2) The exact 1:1 correspondence of Roslyn's text and of our line-lengths cannot be established
        //     immediately upon the FastColoredTextBox LineAdded/LineRemoved events. Instead, we have to trust
        //     that a TextChanged event will be fired in future, and we'll restore 1:1 sync at that time.
        // (3) I couldn't figure out the FastColoredTextBox model for whether or not the document has a trailing
        //     newline. Therefore, the 1:1 sync is only correct up to the presence or absence of that trailing newline.
        //     Fortunately this doesn't impact Roslyn's correctness.
        public List<int> PreviousLineLengths = new List<int>() { 0 };
        public Range PreviousColorizedRange;
        public Dictionary<string, StyleIndex> Styles = new Dictionary<string, StyleIndex>();

        // Async colorizing
        public CancellationTokenSource ColorizingCancel;
        public Task Colorizing;

        // Async completion (not yet implemented)
        //public CancellationTokenSource CompletingCancel;
        //public Task Completing;

        // Async building
        public CancellationTokenSource CurrentBuildCancel;
        public Task CurrentBuildTask;


        public Form1()
        {
            InitializeComponent();


            var blue = Range.ToStyleIndex(uxEditor.AddStyle(new TextStyle(Brushes.Blue, null, FontStyle.Regular))); // 0,0,255
            var green = Range.ToStyleIndex(uxEditor.AddStyle(new TextStyle(Brushes.Green, null, FontStyle.Regular))); // 0,128,0
            var gray = Range.ToStyleIndex(uxEditor.AddStyle(new TextStyle(Brushes.Gray, null, FontStyle.Regular))); // 128,128,128
            var black = Range.ToStyleIndex(uxEditor.AddStyle(new TextStyle(Brushes.Black, null, FontStyle.Regular))); // 0,0,0
            var red = Range.ToStyleIndex(uxEditor.AddStyle(new TextStyle(new SolidBrush(Color.FromArgb(163,21,21)), null, FontStyle.Regular))); // 163,21,21
            var cyan = Range.ToStyleIndex(uxEditor.AddStyle(new TextStyle(new SolidBrush(Color.FromArgb(43,145,175)), null, FontStyle.Regular))); // 43,145,175
            var error = Range.ToStyleIndex(uxEditor.AddStyle(new WavyLineStyle(255, Color.Red)));
            var warning = Range.ToStyleIndex(uxEditor.AddStyle(new WavyLineStyle(255, Color.Green)));

            Styles["classifications"] = blue | green | gray | black | red | cyan;
            Styles["diagnostics"] = error | warning;

            Styles["warning"] = warning;
            Styles["error"] = error;

            Styles[ClassificationTypeNames.Comment] = green;
            Styles[ClassificationTypeNames.ExcludedCode] = gray;
            Styles[ClassificationTypeNames.Identifier] = black;
            Styles[ClassificationTypeNames.Keyword] = blue;
            Styles[ClassificationTypeNames.NumericLiteral] = black;
            Styles[ClassificationTypeNames.Operator] = black;
            Styles[ClassificationTypeNames.PreprocessorKeyword] = gray;
            Styles[ClassificationTypeNames.StringLiteral] = red;
            Styles[ClassificationTypeNames.WhiteSpace] = StyleIndex.None;
            Styles[ClassificationTypeNames.Text] = black;
            Styles[ClassificationTypeNames.PreprocessorText] = black;
            Styles[ClassificationTypeNames.Punctuation] = black;
            Styles[ClassificationTypeNames.VerbatimStringLiteral] = red;
            Styles[ClassificationTypeNames.ClassName] = cyan;
            Styles[ClassificationTypeNames.DelegateName] = cyan;
            Styles[ClassificationTypeNames.EnumName] = cyan;
            Styles[ClassificationTypeNames.InterfaceName] = cyan;
            Styles[ClassificationTypeNames.ModuleName] = cyan;
            Styles[ClassificationTypeNames.StructName] = cyan;
            Styles[ClassificationTypeNames.TypeParameterName] = cyan;
            Styles[ClassificationTypeNames.XmlDocCommentAttributeName] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentAttributeQuotes] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentAttributeValue] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentCDataSection] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentComment] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentDelimiter] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentEntityReference] = green;
            Styles[ClassificationTypeNames.XmlDocCommentName] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentProcessingInstruction] = gray;
            Styles[ClassificationTypeNames.XmlDocCommentText] = green;
            Styles[ClassificationTypeNames.XmlLiteralAttributeName] = gray;
            Styles[ClassificationTypeNames.XmlLiteralAttributeQuotes] = gray;
            Styles[ClassificationTypeNames.XmlLiteralAttributeValue] = gray;
            Styles[ClassificationTypeNames.XmlLiteralCDataSection] = gray;
            Styles[ClassificationTypeNames.XmlLiteralComment] = gray;
            Styles[ClassificationTypeNames.XmlLiteralDelimiter] = gray;
            Styles[ClassificationTypeNames.XmlLiteralEmbeddedExpression] = black;
            Styles[ClassificationTypeNames.XmlLiteralEntityReference] = green;
            Styles[ClassificationTypeNames.XmlLiteralName] = gray;
            Styles[ClassificationTypeNames.XmlLiteralProcessingInstruction] = gray;
            Styles[ClassificationTypeNames.XmlLiteralText] = green;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Left >= 0 && Settings.Default.Top >= 0 && Settings.Default.Width != -1 && Settings.Default.Height != -1
                && Settings.Default.Left + Settings.Default.Width < SystemInformation.VirtualScreen.Width
                && Settings.Default.Top + Settings.Default.Height < SystemInformation.VirtualScreen.Height)
            {
                SetBounds(Settings.Default.Left, Settings.Default.Top, Settings.Default.Width, Settings.Default.Height);
            }

            CurrentWorkspace = MSBuildWorkspace.Create();
            await ProjectLoadAsync();
            var item = uxProject.Items.Cast<DocumentModel>().Where(d => d.Document.FilePath == Settings.Default.Document).FirstOrDefault();
            uxProject.SelectedItem = item;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState != FormWindowState.Normal) return;
            Settings.Default.Left = Left;
            Settings.Default.Top = Top;
            Settings.Default.Width = Width;
            Settings.Default.Height = Height;
            Settings.Default.Save();
        }

        private void Enable()
        {
            uxProject.Enabled = (CurrentProject != null);
            uxEditor.Enabled = (CurrentDocument != null);
        }

        public class DocumentModel
        {
            // Each time the Roslyn document changes (which it will do upon every keystroke since it's immutable)
            // we will mutate the corresponding DocumentModel object to reference that new version of the Document.
            public Document Document;
            public bool IsChanged;
            public override string ToString() => Document.Name + (IsChanged ? " *" : "");
        }

        private async Task ProjectLoadAsync()
        {
            try
            {
                CurrentProject = null; CurrentDocument = null; CurrentDiagnostics = default(ImmutableArray<Diagnostic>);  Enable();
                if (string.IsNullOrEmpty(Settings.Default.Project) || !File.Exists(Settings.Default.Project))
                {
                    Settings.Default.Project = null;
                    return;
                }

                if (Path.GetExtension(Settings.Default.Project).ToLower() == ".sln")
                {
                    var sln = await CurrentWorkspace.OpenSolutionAsync(Settings.Default.Project);
                    int nProjects = sln.Projects.Count();
                    if (nProjects != 1) throw new Exception("Can only open solutions with 1 project; not " + string.Join(",", sln.Projects.Select(p => p.Name)));
                    CurrentProject = sln.Projects.First();
                }
                else
                {
                    CurrentProject = await CurrentWorkspace.OpenProjectAsync(Settings.Default.Project);
                }
                uxProject.Items.Clear();
                foreach (var document in CurrentProject.Documents)
                {
                    if (Path.GetExtension(document.Name).ToLower() != ".cs") continue;
                    var model = new DocumentModel { Document = document };
                    uxProject.Items.Add(model);
                }
            }
            catch (Exception ex)
            {
                CurrentWorkspace = null;
                CurrentProject = null;
                CurrentDocument = null;
                CurrentDiagnostics = default(ImmutableArray<Diagnostic>);
                MessageBox.Show(ex.Message, "Open Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async Task DocumentLoadAsync()
        {
            try
            {
                CurrentDocument = null; Enable();
                CurrentDocument = CurrentProject.Documents.Where(d => d.FilePath == Settings.Default.Document).FirstOrDefault();
                if (CurrentDocument == null) { Settings.Default.Document = null; return; }

                StartRecolorize(false);
                var sourceText = await CurrentDocument.GetTextAsync();
                CurrentText = null;
                uxEditor.Text = sourceText.ToString();
                CurrentText = sourceText;
                PreviousColorizedRange = null;
                StartRecolorize(true);
                
            }
            catch (Exception ex)
            {
                CurrentDocument = null;
                MessageBox.Show(ex.Message, "Open Document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async void uxFileOpen_Click(object sender, EventArgs e)
        {
            var r = uxFileOpenDialog.ShowDialog();
            if (r != DialogResult.OK) return;
            Settings.Default.Project = uxFileOpenDialog.FileName;
            Settings.Default.Save();
            await ProjectLoadAsync();
        }

        private void uxFileSave_Click(object sender, EventArgs e)
        {
            var oldCurrent = CurrentDocument;
            foreach (var model in uxProject.Items.OfType<DocumentModel>())
            {
                if (!model.IsChanged) continue;
                SourceText text; Debug.Assert(model.Document.TryGetText(out text));
                File.WriteAllText(model.Document.FilePath, text.ToString());
                model.IsChanged = false;
            }
            // Following ugly hack is to get the ListBox to redraw all its items:
            uxProject.GetType().InvokeMember("RefreshItems", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, uxProject, new object[] { });
        }

        private async void uxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var model = uxProject.SelectedItem as DocumentModel;
            if (model == null) return;
            if (model.Document == CurrentDocument) return;
            Settings.Default.Document = model.Document.FilePath;
            Settings.Default.Save();
            await DocumentLoadAsync();
        }

        private void uxEditor_LineInserted(object sender, LineInsertedEventArgs e)
        {
            // This event is used to keep Roslyn text in 1:1 sync with FastColoredTextBox text. See comment at top of file.
            StartRecolorize(false);
            if (CurrentText != null)
            {
                var sb = new StringBuilder(); for (int i = 0; i < e.Count; i++) sb.AppendLine();
                int previousSpanStart = e.Index >= PreviousLineLengths.Count ? CurrentText.Length : LineToPosition(e.Index);
                UpdateCurrentText(previousSpanStart, 0, sb.ToString());
            }
            PreviousLineLengths.InsertRange(e.Index, Enumerable.Repeat(0, e.Count));
        }

        private void uxEditor_LineRemoved(object sender, LineRemovedEventArgs e)
        {
            // This event is used to keep Roslyn text in 1:1 sync with FastColoredTextBox text. See comment at top of file.
            StartRecolorize(false);
            if (CurrentText != null)
            {
                int previousSpanStart = LineToPosition(e.Index), previousSpanEnd = LineToPosition(e.Index + e.Count);
                var ts = new TextSpan(previousSpanStart, previousSpanEnd - previousSpanStart);
                if (previousSpanStart < CurrentText.Length) UpdateCurrentText(previousSpanStart, previousSpanEnd - previousSpanStart, "");
            }
            PreviousLineLengths.RemoveRange(e.Index, e.Count);
        }

        private void uxEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.Assert(e.ChangedRange.Start.iChar == 0 && e.ChangedRange.End.iChar == uxEditor.GetLineLength(e.ChangedRange.End.iLine), "expected TextChanged to be for entire lines");

            StartRecolorize(false);
            //TriggerCompletionAsync(-1);
            int previousSpanStart = LineToPosition(e.ChangedRange.Start.iLine), previousSpanEnd = LineToPosition(e.ChangedRange.End.iLine) + PreviousLineLengths[e.ChangedRange.End.iLine];
            for (int i = e.ChangedRange.Start.iLine; i <= e.ChangedRange.End.iLine; i++) PreviousLineLengths[i] = uxEditor.GetLineLength(i);

            if (CurrentText != null)
            {
                var ts = new TextSpan(previousSpanStart, previousSpanEnd - previousSpanStart);
                if (previousSpanEnd != previousSpanStart || e.ChangedRange.Text.Length != 0) UpdateCurrentText(previousSpanStart, previousSpanEnd - previousSpanStart, e.ChangedRange.Text);
            }

            PreviousColorizedRange = null;
            StartRecolorize(true);
            //TriggerCompletionAsync(uxEditor.PlaceToPosition(e.ChangedRange.End));
            StartBuild();
        }

        private void UpdateCurrentText(int spanStart, int spanLength, string newText)
        {
            var span = new TextSpan(spanStart, spanLength);
            var change = new TextChange(span, newText);
            CurrentText = CurrentText.WithChanges(change);
            CurrentDocument = CurrentDocument.WithText(CurrentText);
            CurrentProject = CurrentDocument.Project;

            var CurrentModel = uxProject.Items.OfType<DocumentModel>().FirstOrDefault(m => m.Document.FilePath == CurrentDocument.FilePath);
            CurrentModel.Document = CurrentDocument;
            CurrentModel.IsChanged = true;
            uxProject.Items[uxProject.SelectedIndex] = uxProject.SelectedItem;
        }

        private void uxEditor_VisibleRangeChanged(object sender, EventArgs e)
        {
            StartRecolorize(true);
        }

        private void StartRecolorize(bool colorize)
        {
            ColorizingCancel?.Cancel();
            if (!colorize || CurrentDocument == null) return;
            ColorizingCancel = new CancellationTokenSource();
            Colorizing = ColorizeInnerAsync(colorize ? CurrentDocument : null, Colorizing, ColorizingCancel.Token);
        }

        private async Task ColorizeInnerAsync(Document document, Task prevTask, CancellationToken cancel)
        {
            if (prevTask != null) try { await prevTask; } catch (OperationCanceledException) { }

            int newStart = uxEditor.VisibleRange.Start.iLine, newEnd = uxEditor.VisibleRange.End.iLine;
            if (PreviousColorizedRange != null)
            {
                int prevStart = PreviousColorizedRange.Start.iLine, prevEnd = PreviousColorizedRange.End.iLine;
                if (prevStart < newStart && prevEnd > newStart) newStart = prevEnd + 1;
                if (prevEnd > newEnd && prevStart < newEnd) newEnd = prevStart - 1;
                if (newEnd >= uxEditor.LinesCount) newEnd = uxEditor.LinesCount - 1;
                if (newStart < 0) newStart = 0;
                if (newEnd < newStart) return;
            }

            int spanStart = LineToPosition(newStart), spanEnd = LineToPosition(newEnd) + uxEditor.GetLineLength(newEnd);
            var classifieds = await Classifier.GetClassifiedSpansAsync(document, new TextSpan(spanStart, spanEnd - spanStart), ColorizingCancel.Token);
            foreach (var classified in classifieds)
            {
                var range = SpanToRange(classified.TextSpan, false);
                range.ClearStyle(Styles["classifications"]);
                var style = Styles[classified.ClassificationType];
                if (style != StyleIndex.None) range.SetStyle(style);
            }
            ColorizingCancel.Token.ThrowIfCancellationRequested();
            PreviousColorizedRange = new Range(uxEditor, new Place(0, newStart), new Place(uxEditor.GetLineLength(newEnd), newEnd));
        }


        private void StartBuild()
        {
            CurrentBuildCancel?.Cancel();
            if (CurrentProject == null) return;
            CurrentBuildCancel = new CancellationTokenSource();
            CurrentBuildTask = BuildInnerAsync(CurrentProject, CurrentBuildTask, CurrentBuildCancel.Token);
        }

        private async Task BuildInnerAsync(Project project, Task prevTask, CancellationToken cancel)
        {
            if (prevTask != null) try { await prevTask; } catch (OperationCanceledException) { }
            if (project == null) return;
            var compilation = await project.GetCompilationAsync(cancel);

            CurrentDiagnostics = compilation.GetDiagnostics(cancel);
            uxEditor.ClearStyle(Styles["diagnostics"]);
            foreach (var diagnostic in CurrentDiagnostics)
            {
                if (diagnostic.Severity == DiagnosticSeverity.Hidden || diagnostic.Severity == DiagnosticSeverity.Info) continue;
                if (!diagnostic.Location.IsInSource) continue;
                if (diagnostic.Location.SourceTree.FilePath != CurrentDocument.FilePath) continue;
                var style = (diagnostic.Severity == DiagnosticSeverity.Error ? Styles["error"] : Styles["warning"]);
                var range = SpanToRange(diagnostic.Location.SourceSpan, true);
                range.SetStyle(style);
            }
            uxEditor.Refresh();
        }


        private void uxEditor_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            e.ToolTipText = null;
            if (CurrentDiagnostics == default(ImmutableArray<Diagnostic>) || CurrentDocument == null) return;
            foreach (var diagnostic in CurrentDiagnostics)
            {
                if (!diagnostic.Location.IsInSource || diagnostic.Location.SourceTree.FilePath != CurrentDocument.FilePath) continue;
                var range = SpanToRange(diagnostic.Location.SourceSpan, true);
                if (!range.Contains(e.Place)) continue;
                e.ToolTipText = $"{diagnostic.Id}: {diagnostic.GetMessage()}";
            }
        }

        //private async void TriggerCompletionAsync(int pos)
        //{
        //    if (CompletingCancel != null) try { CompletingCancel.Cancel(); await Completing; } catch (OperationCanceledException) { }
        //    CompletingCancel = null; Completing = null;
        //    if (pos == -1 || CurrentDocument == null) return;
        //    CompletingCancel = new CancellationTokenSource();
        //    Completing = CompletionAsyncInner(pos);
        //}

        //private async Task CompletionAsyncInner(int pos)
        //{
        //    // The completion service (although checked into Roslyn) isn't yet in the public NuGet packages...
        //    var service = CompletionService.GetService(CurrentDocument);
        //    var completions = await service.GetCompletionsAsync(CurrentDocument, pos);
        //    if (completions == null) return;
        //    var items = completions.Items.Select(i => i.DisplayText);

        //    // In order for the above call to CompletionService.GetService to even work, you need to do
        //    // ugly initialization magic: https://github.com/dotnet/roslyn/issues/12218
        //    //var assemblies = new[] {"Microsoft.CodeAnalysis", "Microsoft.CodeAnalysis.CSharp", "Microsoft.CodeAnalysis.Features",
        //    //            "Microsoft.CodeAnalysis.CSharp.Features","Microsoft.CodeAnalysis.Workspaces.Desktop"}.Select(Assembly.Load);
        //    //var types = MefHostServices.DefaultAssemblies.Concat(assemblies).Distinct().SelectMany(x => x.GetTypes());
        //    //var context = new ContainerConfiguration().WithParts(types).WithDefaultConventions(new AttributeFilterProvider()).CreateContainer();
        //    //var host = MefHostServices.Create(context);
        //    //CurrentWorkspace = MSBuildWorkspace.Create(host);
        //    //
        //    //public class AttributeFilterProvider : AttributedModelProvider
        //    //{
        //    //    public override IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, MemberInfo member) => member.GetCustomAttributes().Where(x => !(x is ExtensionOrderAttribute));
        //    //    public override IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, ParameterInfo member) => member.GetCustomAttributes().Where(x => !(x is ExtensionOrderAttribute));
        //    //}


        //    // And even once we've got the list of completions... I'm not sure what to do with them now!
        //    // Not sure how FastColoredTextBox can use completions! I tried copying what was in AutoCompleteSample
        //    // but couldn't get it to work.
        //}


        private int LineToPosition(int iLine)
        {
            int r = 0;
            for (int i = 0; i < iLine; i++) r += PreviousLineLengths[i] + Environment.NewLine.Length;
            return r;
        }

        private Range SpanToRange(TextSpan span, bool adjust)
        {
            var rStart = uxEditor.PositionToPlace(span.Start);
            var rEnd = uxEditor.PositionToPlace(span.End);
            if (rEnd == rStart)
            {
                if (rEnd.iChar < uxEditor.GetLineLength(rEnd.iLine)) rEnd = new Place(rEnd.iChar + 1, rEnd.iLine);
                else if (rStart.iChar > 0) rStart = new Place(rStart.iChar - 1, rStart.iLine);
            }
            return new Range(uxEditor, rStart, rEnd);
        }

    }
}
