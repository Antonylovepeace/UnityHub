using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class collapse : MonoBehaviour
{
    GameObject CellGenerator;
    GameObject Measure;
    public GameObject PrefabButton;
    public GameObject[] Buttons = new GameObject[2];
    string refer;
    
    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.Measure = GameObject.Find("measure");
    }

    public void LoopConfirm()
    {
        InteractableFalse();                                                        // ���ⲣ�Ͱj��H�~��cell�����^��
        foreach (int i in Round.collapseCells)                                      // �A�ⲣ�Ͱj�骺cell, RemoveAllListeners(),�B���C��аO
        {
            ChangeColor(i);
            Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
            cell.GetComponent<Button>().onClick.RemoveAllListeners();
            cell.GetComponent<EventTrigger>().enabled = true;
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject newButton = Instantiate(PrefabButton, transform);
            Buttons[i] = newButton;
        }
        this.Measure.GetComponent<Measure>().BuildButton();
        print("Measure");
    }
    
    public void Collapse(string c)
    {
        int n = Round.selectedCell;
        string refer = FindReferText(c, n);
        int m = FindReferNum(refer);
        int times = Round.collapseCells.Length + 1;
        for (int i = 0; i < times; i++)
        {
            string newRefer = FindReferText(refer, m);
            m = FindReferNum(newRefer);
            refer = newRefer;
        }
        
        while(OddElements().Length != 0)
        {
            foreach(string ch in OddElements())
            {
                print("OddElements = " + ch);
                print("once");
                for (int a = 0; a < 9; a++)
                {
                    Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[a];
                    GameObject Grid = cell.transform.GetChild(0).gameObject;
                    for (int b = 0; b < 9; b++)
                    {
                        string content = Grid.transform.GetChild(b).GetComponent<Text>().text;
                        if (content == ch)
                        {
                            var lst = Round.InteractableFalseCells_num.ToList();
                            lst.Add(a);
                            Round.InteractableFalseCells_num = lst.ToArray();
                            CleanCellText(a);
                            cell.transform.GetChild(1).GetComponent<Text>().text = ch;
                            continue;
                        }
                    }
                }
            }
        }
    }


    public string[] OddElements()
    {
        string[] strings = new string[] { };
        string[] stringsRepeat = new string[] { };
        var lst = strings.ToList();
        for(int i = 0;i < 9;i++)
        {
            Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
            GameObject Grid = cell.transform.GetChild(0).gameObject;
            for(int j = 0; j < 9; j++)
            {
                string content = Grid.transform.GetChild(j).GetComponent<Text>().text;
                if(content != "")
                {
                    lst.Add(content);
                }
            }
        }
        
        strings = lst.ToArray();
        
        for (int m = 0; m < strings.Length; m++)
        {
            for (int n = m + 1; n < strings.Length; n++)
            {
                if (strings[m] == strings[n] && strings[m] != "")
                { 
                    var temp = stringsRepeat.ToList();
                    string c = strings[m];
                    print("repeat = " + c);
                    temp.Add(c);
                    stringsRepeat = temp.ToArray();
                }
            }
        }
        foreach (string x in stringsRepeat)
        {
            print("stringsRepeat = " + x);
        }
        foreach (string x in stringsRepeat)
        {
            var temp = strings.ToList();
            temp.Remove(x);
            temp.Remove(x);
            strings = temp.ToArray();
        }
        return strings;
    }
    private string FindReferText(string c,int n)
    {
        
        Cell SelectedCell = this.CellGenerator.GetComponent<CellGenerator>().cells[n];
        GameObject Grid = SelectedCell.transform.GetChild(0).gameObject;
        foreach (string ch in Round.collapseTexts)
        {
            for (int j = 0; j < 9; j++)
            {
                string content = Grid.transform.GetChild(j).GetComponent<Text>().text;
                if (ch == content && ch != c)
                {
                    var lst = Round.collapseCells.ToList();
                    CleanCellText(n);
                    lst.Remove(n);
                    Round.collapseCells = lst.ToArray();
                    foreach (int Data in Round.collapseCells)
                    {
                        //print("collapseCells = " + Data);
                    }
                    SelectedCell.transform.GetChild(1).GetComponent<Text>().text = c;
                    return content;
                }
            }  
        }
        return null;
    }
    private int FindReferNum(string c)
    {
        foreach (int num in Round.collapseCells)
        {          
            Cell SelectedCell = this.CellGenerator.GetComponent<CellGenerator>().cells[num];
            GameObject Grid = SelectedCell.transform.GetChild(0).gameObject;
            for (int i = 0; i < 9; i++)
            {
                string content = Grid.transform.GetChild(i).GetComponent<Text>().text;
                if (c == content)
                {
                    print("cells = " + num);
                    SelectedCell.transform.GetChild(1).GetComponent<Text>().text = c;
                    return num;
                }
            }
        }
        return 0;
        //print("keep");
        
    }

    private void CleanCellText(int i)
    {
        Cell Cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
        GameObject Grid = Cell.transform.GetChild(0).gameObject;
        for (int j = 0; j < 9; j++)
        {
            Grid.transform.GetChild(j).GetComponent<Text>().text = "";
        }
    }
    private void InteractableFalse()
    {
        int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        var lst = list.ToList();
        var lst1 = Round.InteractableFalseCells_num.ToList();
        foreach (int i in list)
        {
            foreach (int j in Round.collapseCells)
            {
                if (i == j)
                {
                    //lst1.Add(i);
                    lst.Remove(i);
                }
            }
        }
        list = lst.ToArray();
        Round.InteractableFalseCells_num = lst1.ToArray();
        foreach (int i in list)
        {
            print("i = "+i);
            Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
            cell.GetComponent<Button>().interactable = false;
        }
    }
    private void ChangeColor(int i)
    {    
        Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];                  //Button Color
        

        GameObject Grid = cell.transform.GetChild(0).gameObject;                        //Text Color
        for (int j = 0; j < 9; j++)
        {
            GameObject text = Grid.transform.GetChild(j).gameObject;
            string content = text.GetComponent<Text>().text;
            foreach (string c in Round.collapseTexts)
            {
                if(content == c)
                {
                    Color color = text.GetComponent<Text>().color;
                    color = Color.red;
                    text.GetComponent<Text>().color = color;
                }
            }
        }

    }
    
}
