using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class collapse : MonoBehaviour
{
    GameObject CellGenerator;
    GameObject Cells;
    GameObject CheckLoop;
    public GameObject Cell;
    public GameObject PrefabButton;
    public GameObject[] Buttons = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.CheckLoop = GameObject.Find("CheckLoop");
    }

    public void CellsCollapse()
    {
        InteractableFalse();                                                        // 先把產生迴圈以外的cell取消回應
        foreach (int i in Round.collapseCells)                                      // 再把產生迴圈的cell, RemoveAllListeners(),且用顏色標記
        {
            ChangeColor(i);
            Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
            cell.GetComponent<Button>().onClick.RemoveAllListeners();
            ButtonSelect(i);
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject newButton = Instantiate(PrefabButton, transform);
            Buttons[i] = newButton;
        }
        //var lst = Round.collapseCells.ToList();
        //lst.Clear();
        //Round.collapseCells = lst.ToArray();
    }
    private void ButtonSelect(int i)
    {
        Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
        UnityEngine.Events.UnityAction<BaseEventData> call = new UnityEngine.Events.UnityAction<BaseEventData>(this.Cell.GetComponent<Cell>().ButtonSelected);
        EventTrigger trigger = cell.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Select;
        entry.callback.AddListener(this.Cell.GetComponent<Cell>().ButtonSelected);
        trigger.triggers.Add(entry);
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
