using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SudokuGrid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float square_offset = 0;
    public GameObject grid_square;
    public Vector2 start_position = new Vector2(0, 0);
    public float square_scale = 1;

    private List<GameObject> grid_squares_ = new List<GameObject>();
    private int selected_grid_data = -1;
    public int selectedValue = 0; // Biến lưu giá trị của ô được chọn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (grid_square.GetComponent<Grid>() == null)
            Debug.LogError("Grid script has not attached");

        CreateGrid();
        SetGridNum("Map 1");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateGrid()
    {
        SpawnGrid();
        SetGridPosition();
    }
    private void SpawnGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                grid_squares_.Add(Instantiate(grid_square) as GameObject);
                grid_squares_[grid_squares_.Count - 1].transform.parent = this.transform;
                grid_squares_[grid_squares_.Count - 1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);

            }
        }
    }
    private void SetGridPosition()
    {
        var square_rect = grid_squares_[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + square_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + square_offset;

        int col_num = 0;
        int row_num = 0;

        foreach (GameObject i in grid_squares_)
        {
            if (col_num + 1 > columns)
            {
                row_num++;
                col_num = 0;
            }

            var pos_x_offset = offset.x * col_num;
            var pos_y_offset = offset.y * row_num;
            i.GetComponent<RectTransform>().localPosition = new Vector2(start_position.x + pos_x_offset, start_position.y - pos_y_offset);
            col_num++;
        }
    }

    //chọn ngẫu nhiên một bản đồ Sudoku từ danh sách được lưu trữ trong SudokuData
    private void SetGridNum(string map)
    {
        selected_grid_data = Random.Range(0, SudokuData.instance.sudoku_game[map].Count);
        var data = SudokuData.instance.sudoku_game[map][selected_grid_data];

        SetGridData(data);
    }

    // xóa vị trí ngẫu nhiên trên matrix từ SudokuData rồi mới truyền xuống obj
    private List<List<int>> RemoveRandomItems(List<List<int>> matrix, int gridRemove)
    {
        List<(int, int)> positions = new List<(int, int)>();

        // thu thập tất cả các vị trí trong ma trận
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                positions.Add((i, j));
            }
        }

        System.Random random = new System.Random();

        // tóa ngẫu nhiên `gridRemove` vị trí
        for (int i = 0; i < gridRemove && positions.Count > 0; i++)
        {
            int indexToRemove = random.Next(positions.Count);
            var (row, col) = positions[indexToRemove];
            matrix[row][col] = 0; // Gán giá trị tại vị trí đó là 0
            positions.RemoveAt(indexToRemove); // Loại bỏ vị trí đã xóa khỏi danh sách
        }

        return matrix;
    }

    
    private void SetGridData(SudokuData.SudokuBoard data)
    {
        int gridRemove = 30; // Số ô cần xóa
        List<List<int>> modifiedMatrix = RemoveRandomItems(data.matrix, gridRemove);
        
        //gán giá trị lấy từ SudokuData vào từng obj
        int k = 0;
        for (int i = 0; i < 9; i += 1)
        {
            for (int j = 0; j < 9; j += 1)
            {
                grid_squares_[k].GetComponent<Grid>().SetNum(modifiedMatrix[i][j]);//Gán lần lượt từng giá trị vào từng ô tương ứng trong grid_squares_
                k += 1;
            }
        }
    }

    // hiển thị giá trị của ô đã chọn
    public void DisplaySelectedValue(int value)
    {
        selectedValue = value;
    }

}