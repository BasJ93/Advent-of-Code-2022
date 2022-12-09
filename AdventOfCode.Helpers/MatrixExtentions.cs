using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Helpers
{
    public static class MatrixExtentions
    {
        public static T[,] ToMatrix<T>(this IEnumerable<string> input) where T : IConvertible
        {
            List<string> inputAsList = input.ToList();

            int dimension1 = inputAsList.Count();
            int dimension2 = inputAsList[0].Length;
            
            T[,] matrix = new T[dimension1, dimension2];
            
            for (int i = 0; i < dimension1; i++)
            {
                for (int j = 0; j < dimension2; j++)
                {
                    string current = inputAsList[i][j].ToString();
                    
                    switch (Type.GetTypeCode(typeof(T)))
                    {
                        case TypeCode.Int32:
                            matrix[i, j] = (T)Convert.ChangeType(Convert.ToInt32(current), typeof(T));
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            return matrix;
        }

        public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}