using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_no15
{
    public static class Extensions
    {
	    public static int[][] ParseJaggedMatrix(this string input)
	    {
		    var strings = input.Split(Environment.NewLine);
		    var matrix = new int[strings.Length][];
		    for(var i = 0; i < matrix.Length; i++)
			    matrix[i] = strings[i].Split().Select(int.Parse).ToArray();

		    return matrix;
	    }

	    public static IEnumerable<double> AvgInEachRow(this int[][] jaggedMatrix)
	    {
		    for(var i = 0; i < jaggedMatrix.Length; i++)
		    {
				var sum = 0;
				for (var j = 0; j < jaggedMatrix[i].Length; j++)
			    {
				    sum += jaggedMatrix[i][j];
			    }

				yield return (double) sum / jaggedMatrix[i].Length;
		    }
	    }

		public static IEnumerable<int> MinInEachRow(this int[][] jaggedMatrix)
		{
			for (var i = 0; i < jaggedMatrix.Length; i++)
			{
				int min = jaggedMatrix[i][0];
				for (var j = 1; j < jaggedMatrix[i].Length; j++)
				{
					if(min > jaggedMatrix[i][j])
						min = jaggedMatrix[i][j];
				}

				yield return min;
			}
		}

		public static IEnumerable<int> MaxInEachRow(this int[][] jaggedMatrix)
		{
			for (var i = 0; i < jaggedMatrix.Length; i++)
			{
				int max = jaggedMatrix[i][0];
				for (var j = 1; j < jaggedMatrix[i].Length; j++)
				{
					if (max < jaggedMatrix[i][j])
						max = jaggedMatrix[i][j];
				}

				yield return max;
			}
		}

		public static IEnumerable<string> SortByPunctuationAndSpaces(this IEnumerable<string> collection)
		{
			string[] punctuationSigns = {",", ":", ";", "-", "'", ".."};
			return collection.
			       OrderBy(x => x.
				               Count(_ => punctuationSigns.
					                     Contains(_.ToString())))
			       .ThenBy(x => x.Count(_ => _ == ' '));
		}
    }
}
