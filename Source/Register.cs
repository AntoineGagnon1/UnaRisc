using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnaRisc
{
    public class Register
    {
        private int _Value;
        public int Value
        {
            get => _Value;
            set
            {
                _Value = Math.Max(value, 0); // min 0
                UpdateUI();
            }
        }


        private int defaultValue = 0;
        private TextBox unaryOut;
        private TextBox decimalOut;

        public void Reset()
        {
            Value = defaultValue;
        }

        public Register(TextBox _unaryOut, TextBox _decimalOut)
        {
            unaryOut = _unaryOut;
            decimalOut = _decimalOut;

            Value = 0;
            unaryOut.Text = "";
            decimalOut.Text = "0";

            unaryOut.TextChanged += (_, _) => {
                Value = unaryOut.Text.Length;
            };
            unaryOut.Validated += (_, _) => { // Set the default value when the user is the one doing the input
                defaultValue = unaryOut.Text.Length;
                UpdateUI();
            };

            unaryOut.LostFocus += (_, _) => {
                UpdateUI();
            };

            decimalOut.TextChanged += (_, _) => {
                if (int.TryParse(decimalOut.Text, out int val))
                    Value = Math.Max(val, 0);
            };
            decimalOut.Validated += (_, _) => { // Set the default value when the user is the one doing the input
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
            unaryOut.Text = new string('1', _Value);
            decimalOut.Text = _Value.ToString();

            decimalOut.Font = new Font(decimalOut.Font, (defaultValue != 0 && Value == defaultValue ? FontStyle.Bold : FontStyle.Regular));
            unaryOut.Font = decimalOut.Font;
        }
    }
}
