using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SudokuMap_1:MonoBehaviour
{
    public static List<SudokuData.SudokuBoard> getData()
    {
        List<SudokuData.SudokuBoard> data = new List<SudokuData.SudokuBoard> ();

        data.Add(new SudokuData.SudokuBoard(
            new int[81] {0,0,1,0,2,0,3,0,4,
                        0,0,4,0,0,0,0,5,0,
                        0,6,0,7,0,0,8,9,0,
                        9,0,4,0,2,0,0,0,3,
                        7,0,0,1,0,0,4,2,0,
                        0,0,0,6,0,8,0,3,0,
                        8,0,9,0,0,3,0,6,0,
                        0,2,0,0,0,0,1,0,0,
                        5,7,0,6,0,4,0,0,0,},

            new int[81] {9,8,1,5,2,7,3,6,4,
                        3,2,4,8,9,6,7,5,1,
                        4,6,5,7,3,1,8,9,2,
                        9,5,4,2,2,8,6,1,3,
                        7,3,8,1,6,5,4,2,9,
                        2,1,6,6,4,8,5,3,7,
                        8,4,9,3,5,3,2,6,5,
                        6,2,7,4,8,9,1,7,8,
                        5,7,2,6,1,4,9,8,3,}
            ));
        return data;
    }
}

public class SudokuData:MonoBehaviour
{
    public static SudokuData instance;

    public struct SudokuBoard
    {
        public int[] unsolved;
        public int[] solved;

        public SudokuBoard(int[] unsolved, int[] solved) : this()
        {
            this.unsolved = unsolved;
            this.solved = solved;
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
