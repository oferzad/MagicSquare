
namespace MagicSquare
{
    

    internal class Program
    {
        // Method to check if a square matrix is a magic square
        static bool IsMagicSquare(int[,] matrix)
        {
            int rows = matrix.GetLength(0); // Get the size of the matrix

            if (rows != matrix.GetLength(1))
            {
                return false;
            }
            // Calculate the sum of the first row (assuming it's the magic constant)
            int magicSum = RowSum(matrix, 0); ;
            
            // Check rows and columns sums
            for (int i = 0; i < rows; i++)
            {
                int rowSum = RowSum(matrix, i);
                int colSum = ColSum(matrix,i);
                if (rowSum != magicSum || colSum != magicSum)
                {
                    return false; // If any row or column sum is not equal to magicSum, it's not a magic square
                }
            }

            // Check main diagonal sum
            int primary = PrimaryDiagonalSum(matrix);
            if (primary != magicSum)
            {
                return false; // If the main diagonal sum is not equal to magicSum, it's not a magic square
            }

            // Check secondary diagonal sum
            int secondary = SecondaryDiagonalSum(matrix);
            if (secondary != magicSum)
            {
                return false; // If the secondary diagonal sum is not equal to magicSum, it's not a magic square
            }

            // If all checks passed, it's a magic square
            return true;
        }
        static int RowSum(int[,] mat, int row)
        {
            int sum = 0;
            for(int j=0; j<mat.GetLength(1); j++)
            {
                sum += mat[row, j];
            }
            return sum;
        }

        static int ColSum(int[,] mat, int col)
        {
            int sum = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                sum += mat[i, col];
            }
            return sum;
        }

        static int PrimaryDiagonalSum(int[,] mat)
        {
            int sum = 0;
            for(int i=0; i<mat.GetLength(0);i++)
            {
                sum += mat[i, i];
            }
            return sum;
        }

        static int SecondaryDiagonalSum(int[,] mat)
        {
            int sum = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                sum += mat[i, mat.GetLength(1) - 1 - i];
            }
            return sum;
        }

        //rows must be odd
        static int[,] CreateMagicSquare(int rows, int start, int hefresh)
        {
            int[,] mat = new int[rows, rows];
            for(int i = 0; i < rows; i++)
                for(int j=0; j < rows; j++)
                    mat[i, j] = 0;

            int currentRow = 0, currentCol = rows / 2;
            for(int i = 0; i < rows*rows; i++)
            {
                mat[currentRow, currentCol] = start;
                start += hefresh;
                int r = RowUp(currentRow, mat);
                int c = ColRight(currentCol, mat);
                if (mat[r,c] != 0)
                {
                    r = RowDown(currentRow, mat);
                    c = currentCol;
                }
                currentRow = r;
                currentCol = c;
            }

            return mat;
        }

        static int RowUp(int row, int[,] mat)
        {
            if (row == 0)
                return mat.GetLength(0) - 1;
            else
                return row - 1;
        }

        static int RowDown(int row, int[,] mat)
        {
            if (row == mat.GetLength(0) - 1)
                return 0;
            else
                return row + 1;
        }

        static int ColRight(int col, int[,] mat)
        {
            if (col == mat.GetLength(1) - 1)
                return 0;
            else
                return col + 1;
        }

        static void PrintMat(int[,] mat)
        {
            for(int i = 0;i < mat.GetLength(0);i++)
            {
                for(int j=0;j<mat.GetLength(1);j++)
                {
                    Console.Write($"{mat[i,j].ToString().PadRight(4)}");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {


            // Example usage
            bool cont = true;
            while (cont)
            {
                MagicSquare magic = new MagicSquare(5);

                Console.WriteLine(magic);

                if (magic.IsMagicSquare())
                {
                    Console.WriteLine("It's a magic square!");
                }
                else
                {
                    Console.WriteLine("It's not a magic square.");
                }

                Console.WriteLine("Press s to stop or other key to continue...");
                char c = Console.ReadKey(false).KeyChar;
                cont = c != 's';
            }
            
        }
    }
}