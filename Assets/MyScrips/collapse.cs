using System.Linq;
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
        //var lst = Round.collapseCells.ToList();
        //lst.Clear();
        //Round.collapseCells = lst.ToArray();
    }
    
    public void Collapse(string c)
    {
        int n = Round.selectedCell;
        string refer = FindReferText(c, n);
        int m = FindReferNum(refer);
        print("firstRefer = " + refer);
        print("firstReferText = " + m);
        print("Round.collapseCells.Length = " + Round.collapseCells.Length);
        int times = Round.collapseCells.Length + 1;
        for (int i = 0; i < times; i++)
        {
            string newRefer = FindReferText(refer, m);
            print("newRefer = " + newRefer);
            m = FindReferNum(newRefer);
            print("newReferText = " + m);
            refer = newRefer;
        }
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
                    lst.Remove(n);
                    Round.collapseCells = lst.ToArray();
                    foreach (int Data in Round.collapseCells)
                    {
                        print("collapseCells = " + Data);
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
        foreach (int i in list)
        {
            foreach (int j in Round.collapseCells)
            {
                if (i == j)
                {
                    lst.Remove(i);
                }
            }
        }
        list = lst.ToArray();
        foreach(int i in list)
        {
            print("i = "+i);
            Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
            cell.GetComponent<Button>().interactable = false;
        }
    }
    private void ChangeColor(int i)
    {    
        Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];                  //Button Color
        ColorBlock cb = cell.GetComponent<Button>().colors;
        cb.disabledColor = Color.cyan;
        cell.GetComponent<Button>().colors = cb;

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
