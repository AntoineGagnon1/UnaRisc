using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnaRisc.Source.UI
{
    public partial class RegisterUI : UserControl
    {
        private readonly Register register;
        private int defaultValue = 0;

        public RegisterUI(Register _register, int index)
        {
            register = _register;
            InitializeComponent();

            RegisterName.Text = $"r{index}";

            UpdateUI();

            register.ValueChanged += UpdateUI;

            UnaInput.TextChanged += (_, _) => {
                register.Value = UnaInput.Text.Length;
            };
            UnaInput.Validated += (_, _) => { // Set the default value when the user is the one doing the input
                defaultValue = UnaInput.Text.Length;
                UpdateUI();
            };
            UnaInput.LostFocus += (_, _) => {
                UpdateUI();
            };

            DecimalInput.TextChanged += (_, _) => {
                if (int.TryParse(DecimalInput.Text, out int val))
                    register.Value = Math.Max(val, 0);
            };
            DecimalInput.Validated += (_, _) => { // Set the default value when the user is the one doing the input
                if (int.TryParse(DecimalInput.Text, out int val))
                {
                    defaultValue = Math.Max(val, 0);
                    UpdateUI();
                }

            };
            DecimalInput.LostFocus += (_, _) => {
                UpdateUI();
            };
        }

        public void Reset()
        {
            register.Value = defaultValue;
        }

        private void UpdateUI()
        {
            UnaInput.Text = new string('1', register.Value);
            DecimalInput.Text = register.Value.ToString();

            DecimalInput.Font = new Font(DecimalInput.Font, (defaultValue != 0 && register.Value == defaultValue ? FontStyle.Bold : FontStyle.Regular));
            UnaInput.Font = DecimalInput.Font;
        }
    }
}
