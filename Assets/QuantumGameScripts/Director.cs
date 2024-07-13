using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Director : MonoBehaviour
{

    public bool Xturn = true;
    public bool NextTurn = true;
    public int TurnCount = 0;
    public GameObject Round_Board;
    GameObject Cells;
    GameObject CheckLoop;
    GameObject InteractiveUI;

    void Start()
    {
        TypeWriter.Add("歡迎來到量子物理的世界!!!\r\n請選擇兩格不同格子落子。\r\n");
        TypeWriter.Active();

        this.Cells = GameObject.Find("CellGenerator");
        this.CheckLoop = GameObject.Find("CheckLoop");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
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
        string[] Data = new string[] { };
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
            else if (lstX.Contains(Text))
            {
                lst.Add("X");
            }
            else if (Text == "")
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
    int x;
    public bool checkWinning()
    {
        x = 0;
        TextMeshProUGUI text = Round_Board.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        string[] Data = GetBoardData();

        //vertical
        for (int i = 0; i < 3; i++)
        {
            if (Data[i] == Data[i + 3] && Data[i] == Data[i + 6] && Data[i] != "")
            {
                text.text = checkDoubleLine(i, i + 3, i + 6, Data) + " is winner !";
                DisableAllButtons();
                DrawLine(i, i + 3, i + 6);
                Round.Winner = Data[i] + " is winner !";
                x = 1;
            }
        }
        //horizon
        for (int i = 0; i < 7; i += 3)
        {
            if (Data[i] == Data[i + 1] && Data[i] == Data[i + 2] && Data[i] != "")
            {
                text.text = checkDoubleLine(i, i + 1, i + 2, Data) + " is winner !";
                DisableAllButtons();
                DrawLine(i, i + 1, i + 2);
                Round.Winner = Data[i] + " is winner !";
                x = 1;
            }
        }
        //Diagonal
        if (Data[0] == Data[4] && Data[0] == Data[8] && Data[0] != "")
        {
            text.text = checkDoubleLine(0, 4, 8, Data) + " is winner !";
            DisableAllButtons();
            DrawLine(0, 4, 8);
            Round.Winner = Data[0] + " is winner !";
            x = 1;
        }
        else if (Data[2] == Data[4] && Data[2] == Data[6] && Data[2] != "")
        {
            text.text = checkDoubleLine(2, 4, 6, Data) + " is winner !";
            DisableAllButtons();
            DrawLine(2, 4, 6);
            Round.Winner = Data[2] + " is winner !";
            x = 1;
        }
        if (x == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private string checkDoubleLine(int a, int b, int c, string[] Data)
    {
        var lst = Round.Cells.ToList();
        lst.Add(a);
        lst.Add(b);
        lst.Add(c);
        Round.Cells = lst.ToArray();
        if (Round.Cells.Length == 3)
        {
            print("長度為三");
            InteractiveUI.GetComponent<InteractiveUI>().NormalWiningText(Data[a]);
            return Data[a];
        }
        else
        {
            print("長度為六");
            return GetLowerNum(Round.Cells);
        }
    }
    private string GetLowerNum(int[] Cells)
    {
        string[] charO = new string[] { "O<sub>1</sub>" , "O<sub>2</sub>" , "O<sub>3</sub>" ,"O<sub>4</sub>" ,"O<sub>5</sub>" ,
                                                            "O<sub>6</sub>" ,"O<sub>7</sub>","O<sub>8</sub>","O<sub>9</sub>"};
        string[] charX = new string[] { "X<sub>1</sub>" , "X<sub>2</sub>" , "X<sub>3</sub>" ,"X<sub>4</sub>" ,"X<sub>5</sub>" ,
                                                            "X<sub>6</sub>" ,"X<sub>7</sub>","X<sub>8</sub>","X<sub>9</sub>"};

        string[] Line1 = new string[] { };
        string[] Line2 = new string[] { };
        int[] Compare_O = new int[] { };
        int[] Compare_X = new int[] { };
        for (int i = 0; i < 3; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[Cells[i]];
            TextMeshProUGUI text = cell.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            string Text = text.text;
            var temp = Line1.ToList();
            temp.Add(Text);
            Line1 = temp.ToArray();
        }
        for (int i = 3; i < 6; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[Cells[i]];
            TextMeshProUGUI text = cell.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            string Text = text.text;
            var temp = Line2.ToList();
            temp.Add(Text);
            Line2 = temp.ToArray();
        }
        for (int x = 0; x < 9; x++)
        {
            string O = charO[x];
            string X = charX[x];
            var lst1 = Compare_O.ToList();
            var lst2 = Compare_X.ToList();
            foreach (string L1 in Line1)
            {
                if (L1 == O)
                {
                    lst1.Add(x);
                }
                else if (L1 == X)
                {
                    lst2.Add(x);
                }
            }
            foreach (string L2 in Line2)
            {
                if (L2 == O)
                {
                    lst1.Add(x);
                }
                else if (L2 == X)
                {
                    lst2.Add(x);
                }
            }
            Compare_O = lst1.ToArray();
            Compare_X = lst2.ToArray();
        }
        int num1 = Compare_O.Min();
        int num2 = Compare_X.Min();
        if (num1 > num2)
        {
            print("X比較小");
            InteractiveUI.GetComponent<InteractiveUI>().UnNormalWiningText("Case1");
            return "X";
        }
        else if (num1 < num2)
        {
            print("O比較小");
            InteractiveUI.GetComponent<InteractiveUI>().UnNormalWiningText("Case2");
            return "O";
        }
        else
        {
            print("一樣小");
            InteractiveUI.GetComponent<InteractiveUI>().UnNormalWiningText("Case3");
            return "X";
        }
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
            cb.disabledColor = UnityEngine.Color.blue;
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
                if (Round.typeWriter_quantumEntanglement < 1)
                {
                    InteractiveUI.GetComponent<InteractiveUI>().quantumEntanglement();
                }
            }
            else
            {
                text.text = "X Turn";
                Round.charO_num++;
            }
            Xturn = !Xturn;
            TurnCount = 0;
        }

    }

    public void ButtonReset()
    {
        for (int i = 0; i <= 8; i++)
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


