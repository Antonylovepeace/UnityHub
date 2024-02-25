using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckLoop : MonoBehaviour
{
    GameObject Cells;
    
    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
    }

  
    





    public void CellsInformation(int BaseNum, int CompareNum)
    {
        Array.Clear(Round.Base, 0, Round.Base.Length);
        Array.Clear(Round.Compare, 0, Round.Compare.Length);
        Cell cell_base = this.Cells.GetComponent<CellGenerator>().cells[BaseNum];
        GameObject Grid_base = cell_base.transform.GetChild(0).gameObject;
        for (int j = 0; j <= 8; j++)
        {

            GameObject text = Grid_base.transform.GetChild(j).gameObject;
            string content = text.GetComponent<Text>().text;
            if (content != "")
            {
                var lsts = Round.Base.ToList();
                Round.Base = lsts.Append(content).ToArray();
            }
        }
        Cell cell_compare = this.Cells.GetComponent<CellGenerator>().cells[CompareNum];
        GameObject Grid_compare = cell_compare.transform.GetChild(0).gameObject;
        for (int j = 0; j <= 8; j++)
        {

            GameObject text = Grid_compare.transform.GetChild(j).gameObject;
            string content = text.GetComponent<Text>().text;
            if (content != "")
            {
                var lsts = Round.Compare.ToList();
                Round.Compare = lsts.Append(content).ToArray();
            }

        }       
    }

    public void checkLoop()
    {

    }
}
