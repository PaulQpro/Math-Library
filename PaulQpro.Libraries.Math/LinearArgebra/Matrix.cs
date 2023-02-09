using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulQpro.Math.Linear
{
public class BaseMatrix
    {
        public virtual int[] Dimensions { get; }
        public bool IsZero { get; protected set; } = false;
        public double[,] MatrixValue { get; set; }
        public override string ToString()
        {
            if (IsZero)
            {
                SetZero();
            }
            string returnValue;
            if (Dimensions[0] == 1)
            {
                returnValue = "[";
            }
            else
            {
                returnValue = "┌";
            }
            if (Dimensions[0] == 1)
            {
                foreach (var value in MatrixValue)
                {
                    returnValue += value.ToString() + ", ";
                }
                returnValue = returnValue.TrimEnd(new char[] { ',', ' ' }) + "]";
            }
            else
            {
                for(int i = 0; i < Dimensions[0]; i++)
                {
                    for(int j = 0; j < Dimensions[1]; j++)
                    {
                        returnValue += MatrixValue[i,j] + ", ";
                    }
                    if (i == 0)
                    {
                        returnValue = returnValue.TrimEnd(new char[] { ',', ' ' }) + "┐\n";
                    }
                    else if (i == Dimensions[0] - 1)
                    {
                        returnValue = returnValue.TrimEnd(new char[] { ',', ' ' }) + "┘";
                    }
                    else
                    {
                        returnValue = returnValue.TrimEnd(new char[] { ',', ' ' }) + $"│\n";
                    }
                    if (i == Dimensions[0] - 2)
                    {
                        returnValue += "└";
                    }
                    else if (i != Dimensions[0] - 1)
                    {
                        returnValue += "│";
                    }
                }
            }
                
            return returnValue;
        }
        public virtual void SetZero()
        {
            for (int i = 0; i < Dimensions[0]; i++)
            {
                for (int j = 0; j < Dimensions[1]; j++)
                {
                    MatrixValue[i, j] = 0;
                }
            }
            IsZero = true;
        }
        protected BaseMatrix()
        {
            MatrixValue = new double[0,0];
            Dimensions = Array.Empty<int>();
        }
        public BaseMatrix(int[] dimensions, double[,] matrixValue)
        {
            Dimensions = dimensions;
            if (Dimensions.Length < 2)
            {
                Dimensions = new int[2] { 1, 1 };
            }
            MatrixValue = new double[Dimensions[0], Dimensions[1]];
            for (int i = 0; i < Dimensions[0]; i++)
            {
                for (int j = 0; j < Dimensions[1]; j++)
                {
                    try
                    {
                        MatrixValue[i, j] = matrixValue[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MatrixValue[i, j] = 0;
                    }
                }
            }
            double sum = 0;
            for (int i = 0; i < Dimensions[0]; i++)
            {
                for (int j = 0; j < Dimensions[1]; j++)
                {
                    sum += MatrixValue[i, j];
                }
            }
            if (MatrixValue.Length == 0 || sum == 0)
            {
                IsZero = true;
                SetZero();
            }
        }
    }
    public class Matrix2x2 : BaseMatrix
    {
        public override int[] Dimensions { get; } = new int[2] { 2, 2 };
        public Matrix2x2(double[,] matrixValue)
        {
            Dimensions = new int[2] { 2, 2 };
            MatrixValue = new double[2, 2];
            for (int i = 0; i < Dimensions[0]; i++)
            {
                for (int j = 0; j < Dimensions[1]; j++)
                {
                    try
                    {
                        MatrixValue[i, j] = matrixValue[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MatrixValue[i, j] = 0;
                    }
                }
            }
            double sum = 0;
            for (int i = 0; i < Dimensions[0]; i++)
            {
                for (int j = 0; j < Dimensions[1]; j++)
                {
                    sum += MatrixValue[i, j];
                }
            }
            if (MatrixValue.Length == 0 || sum == 0)
            {
                IsZero = true;
                SetZero();
            }
        }
    }
}
