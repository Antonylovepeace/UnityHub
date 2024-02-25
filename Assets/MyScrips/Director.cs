using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    
    public bool Xturn = true;
    public int TurnCount = 0;
    public string[] charO = new string[] { "O\u2081" , "O\u2082" , "O\u2083" , "O\u2084" , "O\u2085" ,
                                                            "O\u2086" ,"O\u2087","O\u2088","O\u2089"};
    public string[] charX = new string[] { "X\u2081" , "X\u2082" , "X\u2083" , "X\u2084" , "X\u2085" ,
                                                            "X\u2086" ,"X\u2087","X\u2088","X\u2089"};
    GameObject Cells;

    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetCharacter()
    {
        
        if (Xturn == true)
        {
            
            return charX[Round.charX_num];
            
        }
        else
        {
            
            return charO[Round.charO_num]; 
        }

    }

    public void SwitchPlayer()
    {
        TurnCount++;
        if (TurnCount == 2)
        {
            if (Xturn)
            {
                Round.charX_num++;
            }
            else
            {
                Round.charO_num++;
            }
            Xturn = ! Xturn;
            TurnCount = 0;
        }        
        
    }
    public void ButtonReset()
    {

        for(int i = 0;i<=8; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            if (CheckEmpty(cell))
            {
                cell.GetComponent<Button>().interactable = true;
            }
        }
    }
    private bool CheckEmpty(Cell cell)
    {
        int i;
        for (i = 0; i <= 8; i++)
        {

            GameObject Grid = cell.transform.GetChild(0).gameObject;
            GameObject text = Grid.transform.GetChild(i).gameObject;
            string content = text.GetComponent<Text>().text;
            if (content == "")
            {
                return true;
            }
        }
        return false;
    }

    


}


