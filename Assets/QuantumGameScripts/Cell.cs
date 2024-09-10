using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using System.Xml.Xsl;
using static System.Net.Mime.MediaTypeNames;

public class Cell : MonoBehaviour
{
    GameObject Director;
    GameObject CheckLoop;
    GameObject collapse;
    GameObject CellGenerator;
    GameObject AI;
    GameObject BoardControl;
    GameObject AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.Director = GameObject.Find("Director");
        this.CheckLoop = GameObject.Find("CheckLoop");
        this.collapse = GameObject.Find("collapse");
        this.AI = GameObject.Find("AI_Controller");
        this.BoardControl = GameObject.Find("BoardControl");
        this.AudioManager = GameObject.Find("AudioManager");
    }

    // Update is called once per frame
    void Update()
    {
        Transion();
    }
    void Transion()
    {

        for (int i = 0; i < 9; i++)
        {
            GameObject Grid = transform.GetChild(0).gameObject;
            TextMeshProUGUI text = Grid.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            //Debug.Log("i = "+Grid.transform.GetChild(i));
            string content = text.text;
            
            if (content!= "" && compare(content))
            {
                //print("enter");
                //print("content = " + content);
                //Color color = new Color(0f, 0f, 0f, 0f);
                text.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time / 2.5f, 1));
            }
            
            
        }
        
    }
    bool compare(string content)
    {
        int x = 0;
        foreach (string c in Round.collapseTexts)
        {
            if (content != c)
            {
                x++;
            }
        }
        if(x == Round.collapseTexts.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Fill()
    {
        AudioManager.GetComponent<AudioManager>().OorXSFX();

        GameObject Grid = transform.GetChild(0).gameObject;
        if (CheckFilled() == 9)
        {
            transform.GetComponent<Button>().interactable = false;
        }
        else
        {
            //GameObject text = Grid.transform.GetChild(CheckFilled()).gameObject;
            TextMeshProUGUI text = Grid.transform.GetChild(CheckFilled()).GetComponent<TextMeshProUGUI>();
            text.text = Director.GetComponent<Director>().GetCharacter();
            if (Director.GetComponent<Director>().PrecheckWinning() == false)
            {
                Director.GetComponent<Director>().SwitchPlayer();
            }
            transform.GetComponent<Button>().interactable = false;
            Round.twoRound++;
            playerRound(Round.twoRound);

            // °j°é«á¶òÁY
            
            if (CheckLoop.GetComponent<CheckLoop>().checkLoop() == true)
            {
                RemoveDouble(Round.collapseCells);
                this.collapse.GetComponent<collapse>().LoopConfirm();
                var lst1 = Round.LoopCheck.ToList();
                lst1.Clear();
                Round.LoopCheck = lst1.ToArray();

                if (SceneManager.GetActiveScene().name == "GameScene" && Round.PVP == false)
                {
                    if (Round.AI)
                    {
                        AI.GetComponent<AI>().WhoseMeasure();
                    }
                        
                }
                
            }
        }
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            Button cell = transform.GetComponent<Button>();
            ColorBlock colors = cell.colors;
            colors.normalColor = new Color32(255, 200, 240, 200);
            cell.colors = colors;
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
            TextMeshProUGUI text = Grid.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
            //GameObject text = Grid.transform.GetChild(j).gameObject;
            string c = text.text;
            foreach (string s in Round.collapseTexts)
            {
                //print("s = " + s);
                if (s == c)
                {
                    TextMeshProUGUI label = this.collapse.GetComponent<collapse>().Buttons[x].transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                    label.text = s;
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
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            print("index = " + transform.GetSiblingIndex());
            Button cell = transform.GetComponent<Button>();
            ColorBlock colors = cell.colors;
            colors.normalColor = new Color32(255, 200, 240, 200);
            cell.colors = colors;
            if (transform.GetSiblingIndex() == 1 && Round.MeasureButton_PlayAnime)
            {
                this.BoardControl.GetComponent<BoardControl>().AcallFifthPointOneStep();
                transform.GetComponent<Button>().interactable = false;
                //transform.GetComponent<Button>().interactable = false;
            }

        }

    }

    
    private int CheckFilled()
    {
        int i;
        for ( i = 0; i <= 8; i++)
        {
            
            GameObject Grid = transform.GetChild(0).gameObject;
            TextMeshProUGUI text = Grid.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            //GameObject text = Grid.transform.GetChild(i).gameObject;
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
