using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnaRisc
{
    // if message != null the program will halt
    public readonly record struct InstructionResult(string? message, bool isError);

    public static class Instructions
    {
        public static Dictionary<string, Func<string[], Interpreter, InstructionResult>> InstructionNames = new()
        { { "push", Push }, { "pop", Pop }, { "concat", Concat }, { "ret", Ret }, { "goto", Goto }, { "empty", Empty}};

        private static InstructionResult Push(string[] param, Interpreter interpreter)
        {
            if (param.Length < 1 || !interpreter.TryGetRegister(param[0], out var reg))
                return new ("Invalid argument in push !", true);

            reg.Value++;
            return new (null, false);
        }

        private static InstructionResult Pop(string[] param, Interpreter interpreter)
        {
            if (param.Length < 1 || !interpreter.TryGetRegister(param[0], out var reg))
                return new ("Invalid argument in pop !", true);

            reg.Value--;
            return new (null, false);
        }

        private static InstructionResult Concat(string[] param, Interpreter interpreter)
        {
            if (param.Length < 2
                || !interpreter.TryGetRegister(param[0], out var reg1)
                || !interpreter.TryGetRegister(param[1], out var reg2))
                return new ("Invalid argument in concat !", true);

            reg1.Value += reg2.Value;
            return new (null, false);
        }

        private static InstructionResult Ret(string[] param, Interpreter interpreter)
        {
            if (param.Length < 1 || !interpreter.TryGetRegister(param[0], out var reg))
                return new ("Invalid argument in ret !", true);

            return new($"{param[0]} = ({reg.Value}){{{new string('1', reg.Value)}}}", false);
        }

        private static InstructionResult Goto(string[] param, Interpreter interpreter)
        {
            if (param.Length < 1 || !interpreter.TryGetLabel(param[0], out var jumpTo))
                return new ($"Invalid argument in goto !", true);

            interpreter.JumpTo(jumpTo);
            return new (null, false);
        }

        private static InstructionResult Empty(string[] param, Interpreter interpreter)
        {
            if (param.Length < 2 || !interpreter.TryGetRegister(param[0], out var reg) || !interpreter.TryGetLabel(param[1], out var jumpTo))
                return new ($"Invalid argument in empty !", true);

            if (reg.Value == 0)
                interpreter.JumpTo(jumpTo); // Jump only if the register is empty

            return new (null, false);
        }


    }
}
