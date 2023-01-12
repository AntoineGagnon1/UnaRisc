using System.Windows.Forms;
using System;

namespace UnaRisc
{
    public partial class IDE : Form
    {
        private Register[] registers;
        private Interpreter interpreter;

        public IDE()
        {
            // Remove static
            // Syntax colors

            InitializeComponent();

            registers = new []{ 
                new Register(r1Input, r1Decimal),
                new Register(r2Input, r2Decimal),
                new Register(r3Input, r3Decimal),
                new Register(r4Input, r4Decimal),
                new Register(r5Input, r5Decimal),
            };

            interpreter = new Interpreter(registers);

            TextInput.SelectionTabs = new int[] { 10 };
        }

        private void runCodeButton_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
            DisplayResult(interpreter.ExecuteCode(TextInput.Text));
        }


        private void DisplayResult(Interpreter.ExecutionResult result)
        {
            resultBox.Text = result.message;

            // Get the position of the line
            var lines = TextInput.Text.Split(new[] { '\r', '\n' });
            var line = Math.Min(result.line, lines.Count());

            int start = 0;
            for(int i = 0; i < line; i++)
                start += lines[i].Length + 1; // + 1 for \n

            TextInput.SelectionStart = start;
            TextInput.SelectionLength = lines[Math.Min(line, lines.Count() - 1)].Length;
            TextInput.SelectionBackColor = result.isError ? Color.Red : Color.DarkGreen;
        }

        
        private void resetButton_Click(object sender, EventArgs e)
        {
            foreach (var reg in registers)
                reg.Reset();
        }
    }
}