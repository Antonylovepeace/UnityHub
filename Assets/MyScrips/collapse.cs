using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class collapse : MonoBehaviour
{
    GameObject Cells;
    // Start is called before the first frame update
    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");

    }

    public void CellsCollapse()
    {
        
        foreach (int i in Round.collapseCells)
        {
            ChangeColor(i);
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            cell.GetComponent<Button>().interactable = false;
            print("ถiจำ");
        }
        var lst = Round.collapseCells.ToList();
        lst.Clear();
        Round.collapseCells = lst.ToArray();
    }
    
    private void ChangeColor(int i)
    {    
        Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
        ColorBlock cb = cell.GetComponent<Button>().colors;
        //cb.disabledColor = new Color(2, 250, 152, 1);
        cb.disabledColor = Color.cyan;
        cell.GetComponent<Button>().colors = cb;
    }
    
}
