using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Base.Interfaces;
using AdventOfCode.Helpers;

namespace AdventOfCode2022.Solutions;

public class Day8 : ISolution
{
	public async Task<string> Task1(IEnumerable<string> input, CancellationToken ctx)
	{
		int[,] forrest = input.ToMatrix<int>();

		bool[,] visibleTrees = new bool[forrest.GetLength(0), forrest.GetLength(1)];

		for (int i = 0; i < forrest.GetLength(0); i++)
		{
			for(int j = 0; j<forrest.GetLength(1); j++)
			{
				// Check if a tree is visible from any direction. It is visible if between the tree and the edge op the map no taller trees are available.

				bool isVisible = false;
				
				int[] column = forrest.GetColumn(i);
				int[] row = forrest.GetRow(j);

				int[] front = row[..j];
				int[] rear = row[j..];

				int[] top = column[..i];
				int[] bottom = column[i..];

				if (front.Length == 0 || rear.Length == 0 || top.Length == 0 || bottom.Length == 0)
				{
					isVisible = true;
				}
				else
				{
					
				}

				visibleTrees[i, j] = isVisible;
			}
		}
		
		throw new System.NotImplementedException();
	}

	public async Task<string> Task2(IEnumerable<string> input, CancellationToken ctx)
	{
		throw new System.NotImplementedException();
	}
}