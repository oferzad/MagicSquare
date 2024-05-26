using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare
{
    class MagicSquare
    {
        private int[,] matrix;

        public MagicSquare(int rows, int start, int hefresh)
        {
            this.matrix = new int[rows, rows];
            FillMat(start, hefresh);
        }

        public MagicSquare(int rows)
        {
            Random r = new Random();
            int start = r.Next(1, 20);
            int hefresh = r.Next(1, 10);
            this.matrix = new int[rows, rows];
            FillMat(start, hefresh);
        }

        public bool IsMagicSquare()
        {
            int rows = this.matrix.GetLength(0); // Get the size of the matrix

            if (rows != this.matrix.GetLength(1))
            {
                return false;
            }
            // Calculate the sum of the first row (assuming it's the magic constant)
            int magicSum = RowSum(0); ;

            // Check rows and columns sums
            for (int i = 0; i < rows; i++)
            {
                int rowSum = RowSum(i);
                int colSum = ColSum(i);
                if (rowSum != magicSum || colSum != magicSum)
                {
                    return false; // If any row or column sum is not equal to magicSum, it's not a magic square
                }
            }

            // Check main diagonal sum
            int primary = PrimaryDiagonalSum();
            if (primary != magicSum)
            {
                return false; // If the main diagonal sum is not equal to magicSum, it's not a magic square
            }

            // Check secondary diagonal sum
            int secondary = SecondaryDiagonalSum();
            if (secondary != magicSum)
            {
                return false; // If the secondary diagonal sum is not equal to magicSum, it's not a magic square
            }

            // If all checks passed, it's a magic square
            return true;
        }
        private int RowSum(int row)
        {
            int sum = 0;
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                sum += this.matrix[row, j];
            }
            return sum;
        }

        private int ColSum(int col)
        {
            int sum = 0;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                sum += this.matrix[i, col];
            }
            return sum;
        }

        private int PrimaryDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                sum += this.matrix[i, i];
            }
            return sum;
        }

        private int SecondaryDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                sum += this.matrix[i, this.matrix.GetLength(1) - 1 - i];
            }
            return sum;
        }

        //rows must be odd
        private void FillMat(int start, int hefresh)
        {
            
            for (int i = 0; i < this.matrix.GetLength(0); i++)
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                    this.matrix[i, j] = 0;

            int currentRow = 0, currentCol = this.matrix.GetLength(0) / 2;
            for (int i = 0; i < this.matrix.GetLength(0) * this.matrix.GetLength(0); i++)
            {
                this.matrix[currentRow, currentCol] = start;
                start += hefresh;
                int r = RowUp(currentRow);
                int c = ColRight(currentCol);
                if (this.matrix[r, c] != 0)
                {
                    r = RowDown(currentRow);
                    c = currentCol;
                }
                currentRow = r;
                currentCol = c;
            }
        }

        private int RowUp(int row)
        {
            if (row == 0)
                return this.matrix.GetLength(0) - 1;
            else
                return row - 1;
        }

        private int RowDown(int row)
        {
            if (row == this.matrix.GetLength(0) - 1)
                return 0;
            else
                return row + 1;
        }

        private int ColRight(int col)
        {
            if (col == this.matrix.GetLength(1) - 1)
                return 0;
            else
                return col + 1;
        }

        public override string ToString()
        {
            string str = $"Magic Square of {this.RowSum(0)}:\n";
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    str+=$"{this.matrix[i, j].ToString().PadRight(5)}";
                }
                str += "\n";
            }
            return str;
        }

    }
}
