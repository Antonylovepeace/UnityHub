using System.Collections.Generic;
using System.Linq;
using TMPro;
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
        InteractableFalse();                                                        // 先把產生迴圈以外的cell取消回應
        foreach (int i in Round.collapseCells)                                      // 再把產生迴圈的cell, RemoveAllListeners(),且用顏色標記
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
                        TextMeshProUGUI text = Grid.transform.GetChild(b).GetComponent<TextMeshProUGUI>();
                        string content =text.text;
                        if (content == ch)
                        {
                            var lst = Round.InteractableFalseCells_num.ToList();
                            lst.Add(a);
                            Round.InteractableFalseCells_num = lst.ToArray();
                            CleanCellText(a);
                            TextMeshProUGUI text1 = cell.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                            text1.text = ch;
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
                TextMeshProUGUI text = Grid.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                string content = text.text;
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
                TextMeshProUGUI text = Grid.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
                string content = text.text;
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
                    TextMeshProUGUI text1 = SelectedCell.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                    text1.text = c;
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
                TextMeshProUGUI text = Grid.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
                string content = text.text;
                if (c == content)
                {
                    print("cells = " + num);
                    TextMeshProUGUI text1 = SelectedCell.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                    text1.text = c;
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
            TextMeshProUGUI text = Grid.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
            text.text = "";
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
            TextMeshProUGUI text = Grid.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
            
            string content = text.text;
            foreach (string c in Round.collapseTexts)
            {
                if(content == c)
                {
                    text.color = Color.yellow;
                    //Color color = text.GetComponent<Text>().color;
                    //color = Color.red;
                    //text.GetComponent<Text>().color = color;
                }
            }
        }

    }
    
}
