using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Grid : Selectable
{
    public GameObject num_text;
    private int num_ = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayText()
    {
        if(num_ <= 0)
        {
            num_text.GetComponent<TextMeshProUGUI>().text = " ";
            
        }
        else
        {
            num_text.GetComponent<TextMeshProUGUI>().text = num_.ToString();
        }
        
    }
    public void SetNum(int number)
    {
        num_ = number;
        DisplayText();
    }
}
