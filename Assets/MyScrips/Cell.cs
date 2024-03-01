using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject Director;
    GameObject CheckLoop;
    GameObject Cells;
    // Start is called before the first frame update
    void Start()
    {
        this.Director = GameObject.Find("Director");
        this.CheckLoop = GameObject.Find("CheckLoop");
        this.Cells = GameObject.Find("CellGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fill()
    {
        GameObject Grid = transform.GetChild(0).gameObject;
        if (CheckFilled() == 9)
        {
            transform.GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject text = Grid.transform.GetChild(CheckFilled()).gameObject;
            text.GetComponent<Text>().text = Director.GetComponent<Director>().GetCharacter();
            Director.GetComponent<Director>().SwitchPlayer();
            transform.GetComponent<Button>().interactable = false;
            Round.twoRound++;
            playerRound(Round.twoRound);
            if(CheckLoop.GetComponent<CheckLoop>().checkLoop() == true)
            {
                for(int i = 0;i < 9; i++)
                {
                    Cell cell = this.Cells.GetComponent<CellGenerator>().cells[i];
                    cell.GetComponent<Button>().interactable = false;
                }
            }



            foreach(string x in Round.LoopCheck)
            {
                print("arrayNameList = "+x);
            }




            //for(int i = 0;i < Round.array_list_backup.Length; i++)
            {
                //foreach (string x in Round.array_list_backup[i])
                {
                    //print("array_list_backup = " + x);
                }
            }
                
       

        }            
    }
    private int CheckFilled()
    {
        int i;
        for ( i = 0; i <= 8; i++)
        {
            
            GameObject Grid = transform.GetChild(0).gameObject;
            GameObject text = Grid.transform.GetChild(i).gameObject;
            string content = text.GetComponent<Text>().text;
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
