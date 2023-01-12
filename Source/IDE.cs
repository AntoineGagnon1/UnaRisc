using System.Windows.Forms;
using System;
using System.Text;

namespace UnaRisc
{
    public partial class IDE : Form
    {
        private readonly Register[] registers;
        private readonly Interpreter interpreter;

        public IDE()
        {
            InitializeComponent();

            registers = new []{ 
                new Register(r1Input, r1Decimal),
                new Register(r2Input, r2Decimal),
                new Register(r3Input, r3Decimal),
                new Register(r4Input, r4Decimal),
                new Register(r5Input, r5Decimal),
            };

            interpreter = new Interpreter(registers);

            TextInput.SelectionTabs = new int[] { 10, 20, 30, 40 };

            // Try to load from the last file
            string lastFilePath = Properties.Settings.Default.LastFileOpen;
            if(File.Exists(lastFilePath))
            {
                TextInput.Text = File.ReadAllText(lastFilePath);
            }
        }

        private void runCodeButton_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
            RemoveBackColors();
            DisplayResult(interpreter.ExecuteCode(TextInput.Text));
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            foreach (var reg in registers)
                reg.Reset();

            RemoveBackColors();
        }

        private void DisplayResult(Interpreter.ExecutionResult result)
        {
            resultBox.Text = result.Message;

            // Get the position of the line
            var lines = TextInput.Text.Split(new[] { '\r', '\n' });
            var line = Math.Min(result.Line, lines.Length);

            int start = 0;
            for(int i = 0; i < line; i++)
                start += lines[i].Length + 1; // + 1 for \n

            var selectionStart = TextInput.SelectionStart;
            var selectionLength = TextInput.SelectionLength;

            TextInput.SelectionStart = start;
            TextInput.SelectionLength = lines[Math.Min(line, lines.Length - 1)].Length;
            TextInput.SelectionBackColor = result.IsError ? Color.Red : Color.DarkGreen;

            TextInput.SelectionStart = selectionStart;
            TextInput.SelectionLength = selectionLength;
        }

        // Remove all colors in the code input
        private void RemoveBackColors()
        {
            TextInput.SelectionStart = 0;
            TextInput.SelectionLength = TextInput.Text.Length;
            TextInput.SelectionBackColor = Color.White;
        }

        private void TextInput_TextChanged(object sender, EventArgs e)
        {
            int line = TextInput.Text.Substring(0, TextInput.TextLength).Count(c => c == '\n' || c == '\r');
            SyntaxHighlighter.HighlightSyntax(TextInput);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Unarisc|*.unarisc";
                saveFileDialog.Title = "Save";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    Properties.Settings.Default.LastFileOpen = saveFileDialog.FileName;
                    Properties.Settings.Default.Save();

                    var fs = saveFileDialog.OpenFile();
                    byte[] byteArray = Encoding.ASCII.GetBytes(TextInput.Text);
                    fs.Write(byteArray);
                    fs.Close();
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Unarisc|*.unarisc";
                openFileDialog.Title = "Open";
                openFileDialog.ShowDialog();

                if (openFileDialog.FileName != "")
                {
                    Properties.Settings.Default.LastFileOpen = openFileDialog.FileName;
                    Properties.Settings.Default.Save();

                    var fs = openFileDialog.OpenFile();
                    byte[] byteArray = new byte[fs.Length];
                    fs.Read(byteArray, 0, byteArray.Length);
                    TextInput.Text = Encoding.ASCII.GetString(byteArray);
                    fs.Close();
                }
            }
        }
    }
}