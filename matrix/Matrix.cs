using System.Numerics;
using System.Collections.Generic;
using System;
namespace penobotwithMongo.matrix
{
    internal class Matrix
    {
        public List<List<int>> Fildmatrix = null;
        public Matrix(List<int> first, List<int> second)
        {
            List<List<int>> numbers = new List<List<int>>
            {
                first,
                 second
            };
            Fildmatrix = numbers;
        }
        public void Write()
        {
            Fildmatrix.ForEach(i =>
            {
                i.ForEach(j =>
                {
                    Console.Write(j+" ");
                });
                Console.WriteLine();
            });
        }

        /// <summary>
        /// 스칼라 연산
        /// </summary>
        /// <param name="value"></param>
        public List<List<int>> Scalar(int value)
        {
            List<List<int>> numbers = new List<List<int>>();
            Fildmatrix.ForEach(i =>
            {
                numbers.Add(i.ConvertAll((j)=>j*value));
            });
            Fildmatrix = numbers;
            return numbers;
        }
        /// <summary>
        /// 행렬 합 연산
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public List<List<int>> MatrixAdd(Matrix matrix)
        {
            var tempmatrix = matrix.Fildmatrix;
            for (int i = 0; i < tempmatrix.Count; i++)
            {
                for (int j = 0; j < tempmatrix[i].Count;j++)
                {
                    Fildmatrix[i][j] = Fildmatrix[i][j] + tempmatrix[i][j];
                }
            }

            return this.Fildmatrix;
        }
        public Matrix Deepcopy()
        {
            var tempMat = Fildmatrix;
            return new Matrix(tempMat[0], tempMat[1]);
        }
            
    }
}
