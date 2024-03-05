using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    public GameObject Director;
    GameObject CheckLoop;
    GameObject collapse;
    GameObject Cells;
    // Start is called before the first frame update
    void Start()
    {
        this.Director = GameObject.Find("Director");
        this.CheckLoop = GameObject.Find("CheckLoop");
        this.collapse = GameObject.Find("collapse");
        this.Cells = GameObject.Find("CellGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill()
    {
        print("buttondown");
        int z = transform.childCount;
        print("z = "+z);
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

            // °j°é«á¶òÁY
            if (CheckLoop.GetComponent<CheckLoop>().checkLoop() == true)
            {
                this.collapse.GetComponent<collapse>().CellsCollapse();
                var lst1 = Round.LoopCheck.ToList();
                lst1.Clear();
                Round.LoopCheck = lst1.ToArray();            
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
