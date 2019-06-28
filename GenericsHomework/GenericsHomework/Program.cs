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
