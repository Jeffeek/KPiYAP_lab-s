using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6.TableMatrixModels
{
    class Column
    {
        public List<Cell> CellsList { get; }
        public int Count { get; }
        public Column(double[] input)
        {
            CellsList = new List<Cell>();
            Count = input.Length;
            FillCells(input);
        }

        private void FillCells(double[] input)
        {
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                CellsList.Add(new Cell(i + j, input[i]));
                j++;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Count; i++)
            {
                str += CellsList[i].ToString();
                str += "\n";
            }

            return "----------\n" + str + "\n----------";
        }
    }
}
