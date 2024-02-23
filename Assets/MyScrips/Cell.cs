using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject Director;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        this.Director = GameObject.Find("Director");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fill()
    {
        GameObject Grid = transform.GetChild(0).gameObject;
        if (CheckFilled() == 8)
        {
            GameObject text = Grid.transform.GetChild(CheckFilled()).gameObject;
            text.GetComponent<Text>().text = Director.GetComponent<Director>().GetCharacter();
            Director.GetComponent<Director>().SwitchPlayer();
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
