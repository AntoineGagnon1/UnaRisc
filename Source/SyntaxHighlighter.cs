using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnaRisc
{
    public static class SyntaxHighlighter
    {
        private static readonly Color InstructionColor = Color.FromArgb(0x1da314);
        private static readonly Color LabelColor = Color.FromArgb(0x1da0b8);

        public static void HighlightSyntax(RichTextBox textbox)
        {
            textbox.SuspendLayout();

            var selectionStart = textbox.SelectionStart;
            var selectionLength = textbox.SelectionLength;
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

                startPos += line.Length + 1;
            }

            textbox.SelectionStart = selectionStart;
            textbox.SelectionLength = selectionLength;
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
