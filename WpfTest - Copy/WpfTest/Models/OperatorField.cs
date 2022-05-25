using System;

namespace WpfTest
{
    public class OperatorField
    {
        static Random random = new Random();
        public enum OperatorType { Add, Subtract, Multiply, Divide };
        public OperatorType operatorType;
        public int value;
        public OperatorField(OperatorType type, int number)
        {
            operatorType = type;
            do
            {
                value = FindNumber();
            } while (Calc(number) <= 1);
        }

        public override string ToString()
        {
            string operatorString;
            switch (operatorType)
            {
                case OperatorType.Add:
                    operatorString = "+";
                    break;
                case OperatorType.Subtract:
                    operatorString = "-";
                    break;
                case OperatorType.Multiply:
                    operatorString = "*";
                    break;
                case OperatorType.Divide:
                    operatorString = "/";
                    break;
                default:
                    operatorString = " ";
                    break;
            }

            return operatorString + " " + value.ToString();
        }

        int FindNumber()
        {
            switch (operatorType)
            {
                case OperatorType.Add:
                case OperatorType.Subtract: return random.Next(1, 99);
                case OperatorType.Multiply: return random.Next(2, 10);
                case OperatorType.Divide: return random.Next(2, 5);
                default: return 0;
            }
        }

        public int Calc(int number)
        {
            int numberToReturn;
            switch (operatorType)
            {
                case OperatorType.Add:
                    numberToReturn = number + value;
                    break;
                case OperatorType.Subtract:
                    numberToReturn = number - value;
                    break;
                case OperatorType.Multiply:
                    numberToReturn = number * value;
                    break;
                case OperatorType.Divide:
                    numberToReturn = number / value;
                    break;
                default: numberToReturn = number;
                    break;
            }
            return numberToReturn;
        }
    }
}
