using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
public class Grid : Selectable, IPointerClickHandler
{
    public GameObject num_text; //text hiển thị số
    [HideInInspector] public int num_ = 0; // giá trị số của ô (hiển thị trong Inspector)
    public bool is_selected = false; //kiểm tra trạng thái chọn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // hiển thị số trên mỗi obj
    public void DisplayText()
    {
        if(num_ <= 0) // bằng 0 thì xóa
        {
            num_text.GetComponent<TextMeshProUGUI>().text = " ";
            
        }
        else
        {
            num_text.GetComponent<TextMeshProUGUI>().text = num_.ToString();
        }
        
    }
    // gán giá trị số cho obj và hiển thị
    public void SetNum(int number)
    {
        num_ = number;
        DisplayText();
    }

    // xử lý khi nhấp vào ô
    public void OnPointerClick(PointerEventData eventData)
    {
        // bật trạng thái "được chọn"
        is_selected = true;
        Debug.Log($"square is selected: {num_}"); //hiển thị thông tin debug (ô được chọn + giá trị tương ứng)

        // hiển thị số của ô đã chọn trong Inspector
        FindObjectOfType<SudokuGrid>().DisplaySelectedValue(num_);

        // đổi màu nền của ô để hiển thị rằng nó đã được chọn
        GetComponent<Image>().color = Color.yellow;
    }
}
