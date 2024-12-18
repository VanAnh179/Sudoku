using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SudokuMap_1 : MonoBehaviour
{
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
        for (int i = 0; i < 20; i += 1)
        {
            for (int j = 0; j < 3; j += 1)
            {
                changeCol(matrix, 3 * j + Random.Range(0, 3), 3 * j + Random.Range(0, 3));
                changeRow(matrix, 3 * j + Random.Range(0, 3), 3 * j + Random.Range(0, 3));
                changeCol3x3(matrix, Random.Range(0, 3), Random.Range(0, 3));
                changeRow3x3(matrix, Random.Range(0, 3), Random.Range(0, 3));

            }
        }
    }
    public static List<SudokuData.SudokuBoard> getData()
    {
        List<SudokuData.SudokuBoard> data = new List<SudokuData.SudokuBoard>();

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

        data.Add(new SudokuData.SudokuBoard(
            matrix
            ));
        return data;
    }
}

public class SudokuData : MonoBehaviour
{
    public static SudokuData instance;

    public struct SudokuBoard
    {

        public List<List<int>> matrix;

        public SudokuBoard(List<List<int>> matrix) : this()
        {
            this.matrix = matrix;
        }
    };

    public Dictionary<string, List<SudokuBoard>> sudoku_game = new Dictionary<string, List<SudokuBoard>>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        sudoku_game.Add("Map 1", SudokuMap_1.getData());
    }
}