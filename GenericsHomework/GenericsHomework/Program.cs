using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class Matrix<T> where T: struct //type argument e value type (a class Matrix to hold a matrix of numbers (e.g. integers, floats, decimals)
    {
        // fac o variabila(matrice) read only, pe care o voi structura in constructor... nu putem folosi const pentru ca nu pot modifica const in constructor, cum o declar asa ramane;
        private readonly T[,] matrix = null;
        private uint rows;
        private uint columns;
        //proprieati
        public uint Rows
        {
            get { return this.rows; }
        }
        public uint Columns
        {
            get { return this.columns; }
        }

        //Constructor 
        public Matrix(uint Rows, uint Columns)
        {
            this.matrix = new T[Rows, Columns];
            this.rows = Rows;
            this.columns = Columns;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                    result.AppendFormat("{0,4}", this.matrix[i, j]);
                result.AppendLine();
            }

            return result.ToString();
        }

        public void AddElementsManuallyToMatrix()
        {
            Console.WriteLine($"Please insert manually the elements from keyboard.\nRows:{this.rows}\nColumns:{this.columns}");
            for (var i=0;i<this.rows;i++)
            {
                for (var j=0;j<this.columns;j++)
                {
                    var x = Console.ReadLine();
                    
                }
            }
        }

        // Matrix indexer Implement an indexer this[row, col] to access the inner matrix cells.
        public T this[uint row, uint col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }
        /*Matrix operations Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
         * Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).*/
        private static bool BooleanOperator(Matrix<T> matrix, bool op)
        {
            foreach (T element in matrix.matrix)
                if (!element.Equals(default(T)))
                    return op;

            return !op;
        }
        public static bool operator true(Matrix<T> matrix)
        {
            return BooleanOperator(matrix, true);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return BooleanOperator(matrix, false);
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new InvalidOperationException("Invalid operation! We need 2 matrices with the same number of rows and columns");
            }

            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Columns);
            for (uint i = 0; i < result.Rows; i++)
            {
                for (uint j = 0; j < result.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new InvalidOperationException("Invalid operation! We need 2 matrices with the same number of rows and columns");
            }

            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix1.Columns);
            for (uint i = 0; i < result.Rows; i++)
            {
                for (uint j = 0; j < result.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Matrix<T> result = new Matrix<T>(matrix1.Rows, matrix2.Columns);

            for (uint row = 0; row < result.Rows; row++)
                for (uint col = 0; col < result.Columns; col++)
                    for (uint k = 0; k < matrix1.Columns; k++) // or i < matrix2.Rows
                        result[row, col] += matrix1[row, k] * matrix2[k, col];

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> genericList = new GenericList<string>(10);
            genericList.InsertElement("aa", 8);
            Console.WriteLine(genericList.ToString());
        }
    }
}
