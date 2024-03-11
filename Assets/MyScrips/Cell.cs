using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using TMPro;

public class Cell : MonoBehaviour
{
    GameObject Director;
    GameObject CheckLoop;
    GameObject collapse;
    GameObject CellGenerator;


    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.Director = GameObject.Find("Director");
        this.CheckLoop = GameObject.Find("CheckLoop");
        this.collapse = GameObject.Find("collapse");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill()
    {
        int z = transform.childCount;
        GameObject Grid = transform.GetChild(0).gameObject;
        if (CheckFilled() == 9)
        {
            transform.GetComponent<Button>().interactable = false;
        }
        else
        {
            TextMeshProUGUI text = Grid.transform.GetChild(CheckFilled()).GetComponent<TextMeshProUGUI>();
            text.text = Director.GetComponent<Director>().GetCharacter();
            //text.GetComponent<TextMeshPro>().text = Director.GetComponent<Director>().GetCharacter();
            Director.GetComponent<Director>().SwitchPlayer();
            transform.GetComponent<Button>().interactable = false;
            Round.twoRound++;
            playerRound(Round.twoRound);

            // °j°é«á¶òÁY
            /*
            if (CheckLoop.GetComponent<CheckLoop>().checkLoop() == true)
            {
                RemoveDouble(Round.collapseCells);
                this.collapse.GetComponent<collapse>().LoopConfirm();
                var lst1 = Round.LoopCheck.ToList();
                lst1.Clear();
                Round.LoopCheck = lst1.ToArray();
            }
            */
        }   
        foreach(string x in Round.LoopCheck)
        {
            print("LoopCheck = "+x);
        }
        
    }
    public void RemoveDouble(int[] list)
    {
        var lst = Round.collapseCells.ToList();
        lst.Clear();

        foreach (int Data in list)
        {
            if (!lst.Contains(Data))
            {
                lst.Add(Data);
            }
        }
        Round.collapseCells = lst.ToArray();
    }
    public void CellOnSelect()
    {  
        int x = 0;
        int n = transform.GetSiblingIndex();
        Round.selectedCell = n;
        GameObject Grid = this.CellGenerator.GetComponent<CellGenerator>().cells[n].transform.GetChild(0).gameObject;
        for (int j = 0; j < 9; j++)
        {
            GameObject text = Grid.transform.GetChild(j).gameObject;
            string c = text.GetComponent<Text>().text;
            foreach (string s in Round.collapseTexts)
            {
                //print("s = " + s);
                if (s == c)
                {
                    this.collapse.GetComponent<collapse>().Buttons[x].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = s;
                    x++;
                    if (x == 2)
                        break;
                }
            }
        }
        for(int j = 0;j < 2; j++)
        {
            ColorBlock cb = this.collapse.GetComponent<collapse>().Buttons[j].GetComponent<Button>().colors;
            cb.normalColor = Color.white;
            this.collapse.GetComponent<collapse>().Buttons[j].GetComponent<Button>().colors = cb;
        }

    }
    int x = 0;
    public void MeasureButtonOnSelected()
    {
        int n = transform.GetSiblingIndex();
        if (n == 0)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }
        ColorBlock cb = this.collapse.GetComponent<collapse>().Buttons[n].GetComponent<Button>().colors;
        cb.normalColor = cb.selectedColor;
        this.collapse.GetComponent<collapse>().Buttons[n].GetComponent<Button>().colors = cb;
        ColorBlock cb2 = this.collapse.GetComponent<collapse>().Buttons[x].GetComponent<Button>().colors;
        cb2.normalColor = Color.white;
        this.collapse.GetComponent<collapse>().Buttons[x].GetComponent<Button>().colors = cb2;
    }
    private int CheckFilled()
    {
        int i;
        for ( i = 0; i <= 8; i++)
        {
            
            GameObject Grid = transform.GetChild(0).gameObject;
            //GameObject text = Grid.transform.GetChild(i).gameObject;;
            TextMeshProUGUI text = Grid.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            string content = text.text;
            if ( content == "")
            {
                return i;
            }
        }
        return 0;
    }

    private void playerRound(int x)
    {  
        if(x == 2)
        {
            Round.twoRound = 0;
            this.Director.GetComponent<Director>().ButtonReset();
        }
    }

    

    

}
