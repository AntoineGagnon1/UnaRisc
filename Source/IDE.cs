using System.Windows.Forms;
using System;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnaRisc
{
    public partial class IDE : Form
    {
        private readonly Register[] registers;
        private readonly Interpreter interpreter;
        private readonly SyntaxHighlighter syntaxHighlighter;

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
            syntaxHighlighter = new SyntaxHighlighter(TextInput);

            TextInput.SelectionTabs = new int[] { 10, 20, 30, 40 };

            // Try to load from the last file
            string lastFilePath = Properties.Settings.Default.LastFileOpen;
            if(File.Exists(lastFilePath))
                TextInput.Text = File.ReadAllText(lastFilePath);
        }

        private void runCodeButton_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
            syntaxHighlighter.ClearBackColors();

            var result = interpreter.ExecuteCode(TextInput.Text);
            resultBox.Text = result.Message;
            syntaxHighlighter.ChangeLineColor(result.Line, result.IsError ? Color.Red : Color.DarkGreen);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            foreach (var reg in registers)
                reg.Reset();

            syntaxHighlighter.ClearBackColors();
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