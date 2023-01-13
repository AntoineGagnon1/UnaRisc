using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnaRisc
{
    public class Register
    {
        public delegate void OnValueChanged();

        private int _Value;
        public int Value
        {
            get => _Value;
            set
            {
                var lastVal = _Value;
                _Value = Math.Max(value, 0); // min 0

                if(_Value != lastVal)
                    ValueChanged.Invoke();
            }
        }

        public event OnValueChanged ValueChanged = delegate { };

        public Register()
        {
            Value = 0;
        }
    }
}
