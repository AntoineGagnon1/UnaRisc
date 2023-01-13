using System.Windows.Forms;
using System;
using System.Text;
using UnaRisc.Source.UI;
using Microsoft.Win32;

namespace UnaRisc
{
    public partial class IDE : Form
    {
        private readonly List<RegisterUI> registers = new();
        private readonly Interpreter interpreter;
        private readonly SyntaxHighlighter syntaxHighlighter;

        public IDE()
        {
            InitializeComponent();

            interpreter = new Interpreter(5);

            for(int i = 0; i < 5; i++)
            {
                var register = new RegisterUI(interpreter.GetRegister(i), i + 1);
                registers.Add(register);
                registersFlow.Controls.Add(register);
            }

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

            foreach (var rui in registers)
                rui.Reset();

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