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
    GameObject CheckLoop;

    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        this.CheckLoop = GameObject.Find("CheckLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string[] GetBoardData()
    {
        string[] Data = new string[] {};
        var lstO = charO.ToList();
        var lstX = charX.ToList();
        var lst = Data.ToList();
        lst.Clear();
        for (int i = 0; i < 9; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            string Text = cell.transform.GetChild(1).GetComponent<Text>().text;
            if (lstO.Contains(Text))
            {
                lst.Add("O");
            }
            else if(lstX.Contains(Text))
            {
                lst.Add("X");
            }
            else if(Text == "")
            {
                lst.Add("");
            }
        }
        charO = lstO.ToArray();
        charX = lstX.ToArray();
        Data = lst.ToArray();
        foreach (string s in Data)
        {
            print("Data = " + s);
        }
        return Data;
    }
    public bool checkWinning()
    {
        string[] Data = GetBoardData();
        //vertical
        for (int i = 0; i < 3; i++)                     
        {
            if (Data[i] == Data[i+3] && Data[i] == Data[i+6] && Data[i] != "")
            {
                print(Data[i]+" is winner !");
                return true;
            }
        }
        //horizon
        for (int i = 0; i < 7; i=+3)
        {
            if (Data[i] == Data[i + 1] && Data[i] == Data[i + 2] && Data[i] != "")
            {
                print(Data[i] + " is winner !");
                return true;
            }
        }
        //Diagonal
        if (Data[0] == Data[4] && Data[0] == Data[8] && Data[0] != "")
        {
            print(Data[0] + " is winner !");
            return true;
        }
        if (Data[2] == Data[4] && Data[2] == Data[6] && Data[0] != "")
        {
            print(Data[0] + " is winner !");
            return true;
        }
        return false;
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
            if (CheckEmpty(cell) == true && this.CheckLoop.GetComponent<CheckLoop>().checkInteractable(i) == false)
            {            
                cell.GetComponent<Button>().interactable = true;
            }
            else
            {
                cell.GetComponent<Button>().interactable = false;
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


