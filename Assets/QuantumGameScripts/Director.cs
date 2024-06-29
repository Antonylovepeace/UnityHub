using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    
    public bool Xturn = true;
    public bool NextTurn = true;
    public int TurnCount = 0;
    public GameObject Round_Board;
    GameObject Cells;
    GameObject CheckLoop;

    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        this.CheckLoop = GameObject.Find("CheckLoop");
        TextMeshProUGUI text = Round_Board.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.text = "X Turn";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string[] GetBoardData()
    {
        string[] charO = new string[] { "O<sub>1</sub>" , "O<sub>2</sub>" , "O<sub>3</sub>" ,"O<sub>4</sub>" ,"O<sub>5</sub>" ,
                                                            "O<sub>6</sub>" ,"O<sub>7</sub>","O<sub>8</sub>","O<sub>9</sub>"};
        string[] charX = new string[] { "X<sub>1</sub>" , "X<sub>2</sub>" , "X<sub>3</sub>" ,"X<sub>4</sub>" ,"X<sub>5</sub>" ,
                                                            "X<sub>6</sub>" ,"X<sub>7</sub>","X<sub>8</sub>","X<sub>9</sub>"};
        string[] Data = new string[] {};
        var lstO = charO.ToList();
        var lstX = charX.ToList();
        var lst = Data.ToList();
        lst.Clear();
        for (int i = 0; i < 9; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            TextMeshProUGUI text = cell.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            string Text = text.text;
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
    public void checkWinning()
    {
        TextMeshProUGUI text = Round_Board.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        string[] Data = GetBoardData();

        //vertical
        for (int i = 0; i < 3; i++)                     
        {
            if (Data[i] == Data[i+3] && Data[i] == Data[i+6] && Data[i] != "")
            {
                checkDoubleLine(i, i + 3, i + 6);
                text.text = Data[i] + " is winner !";
                DisableAllButtons();
                DrawLine(i, i + 3, i + 6);
                Round.Winner = Data[i] + " is winner !";
            }
        }
        //horizon
        for (int i = 0; i < 7; i+=3)
        {
            if (Data[i] == Data[i + 1] && Data[i] == Data[i + 2] && Data[i] != "")
            {
                checkDoubleLine(i, i + 1, i + 2);
                text.text = Data[i] + " is winner !";
                DisableAllButtons();
                DrawLine(i, i + 1, i + 2);
                Round.Winner = Data[i] + " is winner !";
            }
        }
        //Diagonal
        if (Data[0] == Data[4] && Data[0] == Data[8] && Data[0] != "")
        {
            checkDoubleLine(0, 4, 8);
            text.text = Data[0] + " is winner !";
            DisableAllButtons();
            DrawLine(0, 4, 8);
            Round.Winner = Data[0] + " is winner !";
        }
        else if (Data[2] == Data[4] && Data[2] == Data[6] && Data[2] != "")
        {
            checkDoubleLine(2, 4, 6);
            text.text = Data[2] + " is winner !";
            DisableAllButtons();
            DrawLine(2, 4, 6);
            Round.Winner = Data[2] + " is winner !";
        }
    }
    private int checkDoubleLine(int a, int b, int c)
    {
        int[] DoubleLineChecking = new int[] { };
        var lst = DoubleLineChecking.ToList();
        lst.Add(a);
        lst.Add(b);
        lst.Add(c);
        DoubleLineChecking = lst.ToArray();
        if(DoubleLineChecking.Length == 3)
        {
            return DoubleLineChecking[a];
        }
        else if(DoubleLineChecking.Length == 6)
        {
            return 0;
        }
        return 0;
    }
    private void DrawLine(int a, int b, int c)
    {
        int[] ints = new int[3];
        var lst = ints.ToList();
        lst.Clear();
        lst.Add(a);
        lst.Add(b);
        lst.Add(c);
        ints = lst.ToArray();
        foreach (int i in ints)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            ColorBlock cb = cell.GetComponent<Button>().colors;
            cb.disabledColor = Color.blue;
            cell.GetComponent<Button>().colors = cb;
        }
    }
    public string GetCharacter()
    {
        string[] charO = new string[] { "O<sub>1</sub>" , "O<sub>2</sub>" , "O<sub>3</sub>" ,"O<sub>4</sub>" ,"O<sub>5</sub>" ,
                                                            "O<sub>6</sub>" ,"O<sub>7</sub>","O<sub>8</sub>","O<sub>9</sub>"};
        string[] charX = new string[] { "X<sub>1</sub>" , "X<sub>2</sub>" , "X<sub>3</sub>" ,"X<sub>4</sub>" ,"X<sub>5</sub>" ,
                                                            "X<sub>6</sub>" ,"X<sub>7</sub>","X<sub>8</sub>","X<sub>9</sub>"};
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
        TextMeshProUGUI text = Round_Board.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TurnCount++;
        if (TurnCount == 2)
        {
            if (Xturn)
            {
                text.text = "O Turn";
                Round.charX_num++;
            }
            else
            {
                text.text = "X Turn";
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
    public void DisableAllButtons()
    {
        for (int i = 0; i <= 8; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
              cell.GetComponent<Button>().interactable = false;
        }
    }
    private bool CheckEmpty(Cell cell)
    {
        int i;
        for (i = 0; i <= 8; i++)
        {

            GameObject Grid = cell.transform.GetChild(0).gameObject;
            TextMeshProUGUI text = Grid.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            //GameObject text = Grid.transform.GetChild(i).gameObject;
            string content = text.text;
            if (content == "")
            {
                return true;
            }
        }
        return false;
    }

    


}


