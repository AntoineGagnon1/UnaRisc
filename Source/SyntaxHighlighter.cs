using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace UnaRisc
{
    public class SyntaxHighlighter
    {
        private static readonly Color InstructionColor = Color.FromArgb(0x1da314);
        private static readonly Color LabelColor = Color.FromArgb(0x1da0b8);
        private static readonly Color CommentsColor = Color.FromArgb(0x056316);

        private RichTextBox textbox;

        public SyntaxHighlighter(RichTextBox _textbox)
        {
            textbox = _textbox;

            textbox.TextChanged += (_, _) => { HighlightSyntax(); };
        }

        // Set the back color of a line
        public void ChangeLineColor(int lineIndex, Color color)
        {
            var lines = textbox.Text.Split(new[] { '\r', '\n' });
            var line = Math.Min(lineIndex, lines.Length);

            int start = 0;
            for (int i = 0; i < line; i++)
                start += lines[i].Length + 1; // + 1 for \n

            var selectionStart = textbox.SelectionStart;

            textbox.SelectionStart = start;
            textbox.SelectionLength = lines[Math.Min(line, lines.Length - 1)].Length;
            textbox.SelectionBackColor = color;

            textbox.SelectionStart = selectionStart;
            textbox.SelectionLength = 0;
        }

        public void ClearBackColors()
        {
            var selectionStart = textbox.SelectionStart;

            textbox.SelectionStart = 0;
            textbox.SelectionLength = textbox.Text.Length;
            textbox.SelectionBackColor = Color.White;

            textbox.SelectionLength = 0;
            textbox.SelectionStart = selectionStart;

            // Revert the text colors
            HighlightSyntax();
        }

        public void HighlightSyntax()
        {
            textbox.SuspendLayout();

            var selectionStart = textbox.SelectionStart;
            textbox.SelectionColor = Color.Black;

            string[] lines = textbox.Text.Split(new[] { '\r', '\n' });
            var labels = GetAllLabels(lines);

            var startPos = 0;

            foreach (var line in lines)
            {
                // Check for instructions
                foreach (string name in Instructions.InstructionNames.Keys)
                {
                    var pos = line.IndexOf(name);
                    if (pos != -1)
                    {
                        textbox.SelectionStart = startPos + pos;
                        textbox.SelectionLength = name.Length;
                        textbox.SelectionColor = InstructionColor;
                    }
                }

                // Check for label declarations
                var labelEnd = line.IndexOf(':');
                if (labelEnd != -1)
                {
                    textbox.SelectionStart = startPos;
                    textbox.SelectionLength = labelEnd + 1;
                    textbox.SelectionColor = LabelColor;
                }

                // Check for labels as arguments
                foreach (var label in labels)
                {
                    var pos = line.IndexOf(label);
                    if (pos != -1)
                    {
                        textbox.SelectionStart = startPos + pos;
                        textbox.SelectionLength = label.Length;
                        textbox.SelectionColor = LabelColor;
                    }
                }

                // Check for comments
                var commentStart = line.IndexOf("//");
                if(commentStart != -1)
                {
                    textbox.SelectionStart = startPos + commentStart;
                    textbox.SelectionLength = line.Length - commentStart;
                    textbox.SelectionColor = CommentsColor;
                }

                startPos += line.Length + 1;
            }

            textbox.SelectionStart = selectionStart;
            textbox.SelectionLength = 0;
            textbox.SelectionColor = Color.Black;
            textbox.ResumeLayout();
        }

        private static string[] GetAllLabels(string[] lines)
        {
            List<string> labels = new();

            for (int i = 0; i < lines.Length; i++)
            {
                int pos = lines[i].IndexOf(':');
                if (pos != -1)
                {
                    string label = lines[i].Substring(0, pos).Trim();
                    labels.Add(label);
                }
            }

            return labels.ToArray();
        }
    }
}
