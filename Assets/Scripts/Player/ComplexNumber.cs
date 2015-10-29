using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public class ComplexNumber
    {
        private float _value;
        private List<Manipulation> _manipulations;

        public ComplexNumber(float value)
        {
            _manipulations = new List<Manipulation>();
            Value = value;
        }
        public float Value
        {
            get
            {
                return this.GetRealValue();
            }
            set { this._value = value; }
        }

        private float GetRealValue()
        {
            float value = this._value;
            foreach (var manipulation in _manipulations)
            {
                switch (manipulation.Type)
                {
                    case ManipulationType.ADD:
                        value += manipulation.Value;
                        break;
                    case ManipulationType.DIV:
                        value -= manipulation.Value;
                        break;
                    case ManipulationType.MUL:
                        value *= manipulation.Value;
                        break;
                    case ManipulationType.SUB:
                        value /= manipulation.Value;
                        break;
                }
            }

            return value;
        }

        public void AddManipulation(Manipulation manipulation)
        {
            this._manipulations.Add(manipulation);
        }

        public void RemoveManipulation(Manipulation manipulation)
        {
            this._manipulations.Remove(manipulation);
        }
    }

    public class Manipulation
    {
        public float Value { get; set; }
        public ManipulationType Type { get; set; }
    }

    public enum ManipulationType
    {
        ADD,
        SUB,
        MUL,
        DIV
    }
}
