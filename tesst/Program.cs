using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace create_matrix
{
    internal class Program
    {

        // -----------------------------tạo ma trận-----------------------------------------

        // đổi chỗ 2 hàng
        static void changeRow(List<List<int>> matrix, int x, int y)
        {
            int[] row1 = matrix[x].ToArray();
            int[] row2 = matrix[y].ToArray();
            for (int i = 0; i < 9; i += 1)
            {
                matrix[x][i] = row2[i];
                matrix[y][i] = row1[i];
            }

        }

        // đổi chỗ 2 cột
        static void changeCol(List<List<int>> matrix, int x, int y)
        {
            for (int i = 0; i < 9; i += 1)
            {
                int a = matrix[i][x], b = matrix[i][y];
                matrix[i][x] = b;
                matrix[i][y] = a;
            }
        }

        // đổi chỗ 2 hệ cột 3x3
        static void changeCol3x3(List<List<int>> matrix, int x, int y)
        {
            for (int i = 0; i < 3; i += 1) changeCol(matrix, 3 * x + i, 3 * y + i);
        }

        // đổi chỗ 2 hệ hàng 3x3
        static void changeRow3x3(List<List<int>> matrix, int x, int y)
        {
            for (int i = 0; i < 3; i += 1) changeRow(matrix, 3 * x + i, 3 * y + i);
        }
        // tạo matrix
        static void changeMatrix(List<List<int>> matrix)
        {
            Random r = new Random();
            for (int i = 0; i < 20; i += 1)
            {
                for (int j = 0; j < 3; j += 1)
                {
                    changeCol(matrix, 3 * j + r.Next(0, 3), 3 * j + r.Next(0, 3));
                    changeRow(matrix, 3 * j + r.Next(0, 3), 3 * j + r.Next(0, 3));
                    changeCol3x3(matrix, r.Next(0, 3), r.Next(0, 3));
                    changeRow3x3(matrix, r.Next(0, 3), r.Next(0, 3));

                }
            }
        }

        //------------------------------------------------------------------------------------


        //-------------------------xóa ptu----------------------------------------------------

        static bool check_sudoku_rule(List<List<int>> matrix, int row, int col, int num)
        {
            for(int i = 0; i < 9; i += 1)
            {
                if (matrix[row][i] == num && i != col) return false;
                if (matrix[i][col] == num && i != row) return false;
            }
            for (int i = row / 3 * 3; i < row / 3 * 3 + 3; i += 1)
            {
                for (int j = col / 3 * 3; j < col / 3 * 3+ 3; j += 1)
                {
                    if (matrix[i][j] == num && i != row && j != col) return false;
                }
            }
            return true;
        }
        
        
        //backtracking
        static void checking(List<List<int>> matrix, ref int sum)
        {
            for(int i = 0;i < 9;i += 1)
            {
                for(int j = 0; j < 9; j += 1)
                {
                    if (matrix[i][j] == 0)
                    {
                        for(int num = 1; num <10; num += 1)
                        {
                            if(check_sudoku_rule(matrix, i, j, num))
                            {
                                matrix[i][j] = num;
                                checking(matrix,ref sum);
                                matrix[i][j] = 0;

                            }
                        }
                        return;
                    }
                }
            }
            sum += 1;
        }
        
        //check xem khi xóa ptu đấy thì ma trận còn chỉ có 1 đáp án duy nhất hay không
        static bool checkMatrix(List<List<int>> matrix)
        {
            int sum = 0;
            checking(matrix, ref sum);
            if (sum == 1) return false;
            return true;
        }

        
        //xóa ptu
        static void removeItem(List<List<int>> matrix, int x, int y)
        {
            int tmp = matrix[x][y];
            matrix[x][y] = 0;
            if(checkMatrix(matrix)) matrix[x][y] = tmp;

        }


        //hành chính
        static void removeMatrix(List<List<int>> matrix)
        {
            Random r = new Random();
            for (int i = 0; i < 80; i += 1) 
            {
                removeItem(matrix,r.Next(0,9),r.Next(0,9));
            }
        }
        // in ra ma trận
        static void printlist(List<List<int>> matrix)
        {
            Console.WriteLine("-------------------------------");
            foreach (List<int> r in matrix)
            {
                foreach (int i in r)
                {
                    if (i == 0) Console.Write(" ");
                    else Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------");
        }
        static void Main(string[] args)
        {

            //int[]-> list<list<int>>

            List<List<int>> matrix = new List<List<int>>(9)
            {
                new List<int> {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new List<int> {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new List<int> {1, 9, 8, 3, 4, 2, 5, 6, 7},
                new List<int> {8, 5, 9, 7, 6, 1, 4, 2, 3},
                new List<int> {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new List<int> {7, 1, 3, 9, 2, 4, 8, 5, 6},
                new List<int> {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new List<int> {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new List<int> {3, 4, 5, 2, 8, 6, 1, 7, 9}
            };
            changeMatrix(matrix);
            printlist(matrix);

            removeMatrix(matrix);

            printlist(matrix);


        }
    }
}
