using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest.Commands
{
    public class FieldClickCommand : CommandBase
    {
        int rowInt;
        int fieldInt;
        Level level;
        OperatorRow row;
        OperatorField field;

        public FieldClickCommand(Level level, int rowNumber, int fieldNumber)
        {
            this.level = level;
            rowInt = rowNumber;
            fieldInt = fieldNumber;

            row = level.operatorRows[rowNumber];
            field = row.fields[fieldNumber];
        }
        public override void Execute(object? parameter)
        {
            if (row.Used == true)
                return;

            if(rowInt == 0)
            {
                ExecutionCode();
            }

            else
            {
                if (level.operatorRows[rowInt - 1].Used == false)
                    return;

                ExecutionCode();

                if (rowInt == level.operatorRows.Count - 1)
                {
                    if (level.currentNumber == level.finalNumber)
                    {
                        Debug.Write("Victory!!");
                    }
                    else
                        Debug.Write("Damn Son");
                }
            }
        }

        void ExecutionCode()
        {
            level.currentNumber = field.Calc(level.currentNumber);
            row.DisplayField = level.currentNumber.ToString();
            row.Used = true;
        }
    }
}
