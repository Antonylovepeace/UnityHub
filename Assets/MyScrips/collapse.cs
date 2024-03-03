using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class collapse : MonoBehaviour
{
    GameObject CellGenerator;
    GameObject Cells;
    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.Cells = GameObject.Find("BigCell");
    }

    public void CellsCollapse()
    {
        foreach (int i in Round.collapseCells)
        {
            ChangeColor(i);
            Cell cell = this.CellGenerator.GetComponent<CellGenerator>().cells[i];
            cell.GetComponent<Button>().interactable = false;
            //cell.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        var lst = Round.collapseCells.ToList();
        lst.Clear();
        Round.collapseCells = lst.ToArray();
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
