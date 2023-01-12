using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnaRisc
{
    public class Interpreter
    {
        public readonly record struct ExecutionResult(string Message, bool IsError, int Line);

        private readonly Register[] registers;
        private readonly Dictionary<string, int> labels = new();

        private int stackPos;

        public Interpreter(Register[] _registers)
        {
            registers = _registers;
            stackPos = 0;
        }

        public ExecutionResult ExecuteCode(string code)
        {
            // Reset
            stackPos = 0;

            foreach (var reg in registers)
                reg.Reset();

            labels.Clear();

            string[] lines = code.Split(new[] { '\r', '\n' });

            // Parse the labels
            for (int i = 0; i < lines.Length; i++)
            {
                int pos = lines[i].IndexOf(':');
                if (pos != -1)
                {
                    // Store the label
                    string label = lines[i].Substring(0, pos).Trim();
                    labels.Add(label, i);

                    // Remove the label from the line
                    lines[i] = lines[i].Substring(pos + 1);
                }
            }

            // Run the code
            while (true)
            {
                if (stackPos >= lines.Length)
                    return new("Ran out of code to run ! (Forgot a ret ?)", true, stackPos - 1);

                var line = lines[stackPos].Trim();
                stackPos++;

                if (string.IsNullOrWhiteSpace(line))
                    continue; // skip this line


                var keywords = line.Split(' ');

                if (keywords.Length <= 0 || !Instructions.InstructionNames.ContainsKey(keywords[0]))
                    return new ($"Invalid keyword : {(keywords.Length > 0 ? keywords[0] : "")}", true, stackPos - 1);

                var arguments = line.Substring(keywords[0].Length).Replace(" ", "").Split(',');
                var result = Instructions.InstructionNames[keywords[0]].Invoke(arguments, this);

                if (result.Message != null)
                    return new (result.Message, result.IsError, stackPos - 1);
            }
        }



        public bool TryGetRegister(string? argument, out Register register)
        {
            register = registers.First();
            if (argument == null || argument.Length == 0 || argument[0] != 'r')
                return false;

            if (int.TryParse(argument.AsSpan(1), out int val))
            {
                if (val <= 0 || val > 5)
                    return false;

                register = registers[val - 1];
                return true;
            }

            return false;
        }

        public bool TryGetLabel(string? label, out int jumpTo)
        {
            jumpTo = -1;
            if (label == null || label.Length == 0 || !labels.TryGetValue(label, out int val))
                return false;

            jumpTo = val;
            return true;

        }

        public void JumpTo(int line)
        {
            stackPos = line;
        }
    }
}
