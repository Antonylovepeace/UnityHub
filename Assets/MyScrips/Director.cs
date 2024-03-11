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
    public string[] charO = new string[] { "H<sub>2</sub>" ,"H<sub>2</sub>" ,"H<sub>2</sub>" , "O\u2084" , "O\u2085" ,
                                                            "O\u2086" ,"O\u2087","O\u2088","O\u2089"};
    public string[] charX = new string[] { "Z<sub>2</sub>" , "H<sub>2</sub>" , "H<sub>2</sub>" , "X\u2084" , "X\u2085" ,
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
    

    private void DrawLine(int a, int b, int c)
    {
        int[] ints = new int[] {};
        var lst = ints.ToList();
        lst.Add(a);
        lst.Add(b);
        lst.Add(c);
        ints = lst.ToArray();
        foreach( int i in ints )
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];                  //Button Color
            ColorBlock cb = cell.GetComponent<Button>().colors;
            cb.disabledColor = Color.cyan;
            cell.GetComponent<Button>().colors = cb;
        }
        
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


