using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    public bool Xturn = true;
    public int TurnCount = 0;
    public int twoRound = 0;
    GameObject Cells;
    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetCharacter()
    {
        twoRound++;
        if (Xturn == true)
        {
            return "X";
        }
        else
        {
            return "O";
        }

    }

    public void SwitchPlayer()
    {
        TurnCount++;
        if (TurnCount == 2)
        {
            Xturn = ! Xturn;
            TurnCount = 0;
        }        
        
    }
    public void ButtonReset()
    {

        for(int i = 0;i<=8; i++)
        {
            Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
            if (CheckEmpty(cell))
            {
                cell.GetComponent<Button>().interactable = true;
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


