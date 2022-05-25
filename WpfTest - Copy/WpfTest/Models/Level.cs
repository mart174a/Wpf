using System;
using System.Collections.Generic;

namespace WpfTest
{
    public class Level 
    {
        Random random = new Random();
        public List<OperatorRow> operatorRows = new List<OperatorRow>();

        public int Rows { get; private set; }
        public int Collums { get; private set; }

        public int startNumber;
        public int currentNumber;
        public int finalNumber;


        public Level(int rows, int collums)
        {
            Collums = collums;
            Rows = rows;
            CreateLevel();
        }

        public void Reset()
        {
            currentNumber = startNumber;
            foreach (OperatorRow row in operatorRows)
                row.Reset();
        }

        void CreateLevel()
        {

            startNumber = random.Next(2, 20);
            currentNumber = startNumber;
            finalNumber = startNumber;
            for (int i = 0; i < Rows; i++)
            {
                CreateRow();
            }
        }

        void CreateRow()
        {
            OperatorRow row = new OperatorRow();

            for (int i = 0; i < Collums; i++)
            {
                OperatorField field = new OperatorField(FindAOperatorType(finalNumber), finalNumber);
                row.fields.Add(field);
            }

            finalNumber = row.fields[random.Next(0, Collums)].Calc(finalNumber);
            operatorRows.Add(row);
        }

        public OperatorField.OperatorType RandomOperatorType()
        {
            int i = random.Next(0, 4);
            switch (i)
            {
                case 0:
                    return OperatorField.OperatorType.Add;
                case 1:
                    return OperatorField.OperatorType.Subtract;
                case 2:
                    return OperatorField.OperatorType.Multiply;
                case 3:
                    return OperatorField.OperatorType.Divide;
                default:
                    return OperatorField.OperatorType.Add;
            }
        }

        public OperatorField.OperatorType FindAOperatorType(int number)
        {
            bool add = true;
            bool sub = true;
            bool mul = true;
            bool div = true;

            if (number < 5)
                sub = false;
            if (number > 1000)
                mul = false;
            if (number < 6)
                div = false;

            List<OperatorField.OperatorType> l = new List<OperatorField.OperatorType>();

            if (add)
                l.Add(OperatorField.OperatorType.Add);
            if (sub)
                l.Add(OperatorField.OperatorType.Subtract);
            if (mul)
                l.Add(OperatorField.OperatorType.Multiply);
            if (div)
                l.Add(OperatorField.OperatorType.Divide);

            return l[random.Next(0, l.Count)];
        }
    }
}
