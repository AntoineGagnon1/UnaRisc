using System.Windows.Forms;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace UnaRisc
{
    public partial class Form1 : Form
    {
        static List<TextBox> registerInputs = new List<TextBox>();
        static List<TextBox> registerValues = new List<TextBox>();

        static List<Register> registers = new();

        static Dictionary<string, Func<List<string>, (string?, bool)>> Actions = new() 
        { { "push", Push }, { "pop", Pop }, { "concat", Concat }, { "ret", Ret }, { "goto", Goto }, { "empty", Empty}};

        static int StackPos;

        static Dictionary<string, int> labels = new();

        public Form1()
        {
            // Remove static
            // Syntax colors

            InitializeComponent();

            registerInputs.Add(r1Input);
            registerInputs.Add(r2Input);
            registerInputs.Add(r3Input);
            registerInputs.Add(r4Input);
            registerInputs.Add(r5Input);

            registerValues.Add(r1Decimal);
            registerValues.Add(r2Decimal);
            registerValues.Add(r3Decimal);
            registerValues.Add(r4Decimal);
            registerValues.Add(r5Decimal);

            for (int i = 0; i < 5; i++)
                registers.Add(new Register(registerInputs[i], registerValues[i]));
        }

        private void runCodeButton_Click(object sender, EventArgs e)
        {
            string[] lines = TextInput.Text.Split(new[] { '\r', '\n' });

            // Reset
            StackPos = 0;

            foreach (var reg in registers)
                reg.Reset();

            resultBox.Text = "";

            labels.Clear();

            // Parse the labels
            for (int i = 0; i < lines.Count(); i++)
            {
                int pos = lines[i].IndexOf(':');
                if (pos != -1)
                {
                    // Store the label
                    string label = lines[i].Substring(0, pos);
                    labels.Add(label, i);

                    // Remove the label from the line
                    lines[i] = lines[i].Substring(pos + 1); 
                }
            }

            // Run the code
            while (true)
            {
                if(StackPos >= lines.Count())
                {
                    DisplayResult("Ran out of code to run ! (Forgot a ret ?)", StackPos - 1);
                    break;
                }

                var line = lines[StackPos].Trim();
                StackPos++;

                if (string.IsNullOrWhiteSpace(line))
                    continue; // skip this line

                var keywords = line.Split(' ');

                if (keywords.Length <= 0 || !Actions.ContainsKey(keywords[0]))
                {
                    DisplayResult($"Invalid keyword : {(keywords.Length > 0 ? keywords[0] : "")}", StackPos - 1);
                    break;
                }

                (string? result, bool isError) = Actions[keywords[0]].Invoke(line.Substring(keywords[0].Length).Replace(" ", "").Split(',').ToList());

                if(result != null)
                {
                    DisplayResult(result, StackPos - 1, isError);
                    break;
                }
            }
        }


        private void DisplayResult(string result, int line, bool isError = true)
        {
            resultBox.Text = result;

            // Get the position of the line
            var lines = TextInput.Text.Split(new[] { '\r', '\n' });
            line = Math.Min(line, lines.Count());

            int start = 0;
            for(int i = 0; i < line; i++)
                start += lines[i].Length + 1; // + 1 for \n

            TextInput.SelectionStart = start;
            TextInput.SelectionLength = lines[Math.Min(line, lines.Count() - 1)].Length;
            TextInput.SelectionBackColor = isError ? Color.Red : Color.DarkGreen;
        }

        private static bool TryGetRegister(string? argument, out int index)
        {
            index = -1;
            if (argument == null || argument.Length == 0 || argument[0] != 'r')
                return false;

            if (int.TryParse(argument.Substring(1), out int val))
            {
                if (val <= 0 || val > 5)
                    return false;
                
                index = val;
                return true;
            }
            
            return false;
        }

        private static (string?, bool) Push(List<string> param)
        {
            if (param.Count < 1 || !TryGetRegister(param[0], out int reg))
                return ("Invalid argument in push !", true);

            registers[reg - 1].Value++;
            return (null, false);
        }

        private static (string?, bool) Pop(List<string> param)
        {
            if (param.Count < 1 || !TryGetRegister(param[0], out int reg))
                return ("Invalid argument in pop !", true);

            registers[reg - 1].Value--;
            return (null, false);
        }

        private static (string?, bool) Concat(List<string> param)
        {
            if (param.Count < 2 
                || !TryGetRegister(param[0], out int reg1) 
                || !TryGetRegister(param[1], out int reg2))
                return ("Invalid argument in concat !", true);

            registers[reg1 - 1].Value += registers[reg2 - 1].Value;
            return (null, false);
        }

        private static (string?, bool) Ret(List<string> param)
        {
            if (param.Count < 1 || !TryGetRegister(param[0], out int reg))
                return ("Invalid argument in ret !", true);

            return ($"r{reg} = ({registers[reg - 1].Value}){{{new String('1', registers[reg - 1].Value)}}}", false);
        }

        private static (string?, bool) Goto(List<string> param)
        {
            if (param.Count < 1 || !labels.ContainsKey(param[0]))
                return ($"Invalid argument in goto !", true);

            StackPos = labels[param[0]];

            return (null, false);
        }
        
        private static (string?, bool) Empty(List<string> param)
        {
            if (param.Count < 2 || !TryGetRegister(param[0], out int reg) || !labels.ContainsKey(param[1]))
                return ($"Invalid argument in empty !", true);

            if (registers[reg - 1].Value == 0)
                StackPos = labels[param[1]]; // Jump only if the register is empty

            return (null, false);
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            foreach (var reg in registers)
                reg.Reset();
        }
    }

    public class Register
    {
        private int _Value;
        public int Value { 
            get => _Value;
            set {
                _Value = Math.Max(value, 0); // min 0
                UpdateUI();
            }
        }


        private int defaultValue = 0;
        private TextBox unaOut;
        private TextBox decimalOut;

        public void Reset()
        {
            Value = defaultValue;
        }

        public Register(TextBox _unaOut, TextBox _decimalOut)
        {
            unaOut = _unaOut;
            decimalOut = _decimalOut;

            Value = 0;
            unaOut.Text = "";
            decimalOut.Text = "0";

            unaOut.TextChanged += (_, _) => {
                Value = unaOut.Text.Length;
            };
            unaOut.Validated += (_, _) => {
                defaultValue = unaOut.Text.Length;
                UpdateUI();
            };

            unaOut.LostFocus += (_, _) => {
                UpdateUI();
            };

            decimalOut.TextChanged += (_, _) => {
                if(int.TryParse(decimalOut.Text, out int val))
                    Value = Math.Max(val, 0);
            };
            decimalOut.Validated += (_, _) => {
                if (int.TryParse(decimalOut.Text, out int val))
                {
                    defaultValue = Math.Max(val, 0);
                    UpdateUI();
                }

            };

            decimalOut.LostFocus += (_, _) => {
                UpdateUI();
            };
        }

        private void UpdateUI()
        {
            unaOut.Text = new string('1', _Value);
            decimalOut.Text = _Value.ToString();

            if (defaultValue != 0 && Value == defaultValue)
                decimalOut.Font = new Font(decimalOut.Font, FontStyle.Bold);
            else
                decimalOut.Font = new Font(decimalOut.Font, FontStyle.Regular);

            unaOut.Font = decimalOut.Font;
        }
    }
}