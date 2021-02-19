#region Using derectives

using System.Collections.Generic;

#endregion

namespace lab_no6.TableMatrixModels
{
	internal class Column
	{
		public Column(double[] input)
		{
			CellsList = new List<Cell>();
			Count = input.Length;
			FillCells(input);
		}

		public List<Cell> CellsList { get; }

		public int Count { get; }

		private void FillCells(double[] input)
		{
			var j = 0;

			for (var i = 0; i < Count; i++)
			{
				CellsList.Add(new Cell(i + j, input[i]));
				j++;
			}
		}

		public override string ToString()
		{
			var str = "";

			for (var i = 0; i < Count; i++)
			{
				str += CellsList[i].ToString();
				str += "\n";
			}

			return "----------\n" + str + "\n----------";
		}
	}
}