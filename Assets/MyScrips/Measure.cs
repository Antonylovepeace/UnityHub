using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Measure : MonoBehaviour
{
    public Text Winner;
    public GameObject measureButton;
    GameObject collapse;
    GameObject newButton;
    GameObject Director;
    GameObject Canvas;
    string c;
    // Start is called before the first frame update
    void Start()
    {
        this.collapse = GameObject.Find("collapse");
        this.Director = GameObject.Find("Director");
        //this.Canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildButton()
    {
        newButton = Instantiate(measureButton,transform);
    }

    public void measureButtonDown()
    {
        for (int j = 0; j < 2; j++)
        {
            GameObject newBt = this.collapse.GetComponent<collapse>().Buttons[j];
            ColorBlock cb = newBt.GetComponent<Button>().colors;

            if(cb.normalColor == cb.selectedColor)
            {
                c = newBt.transform.GetChild(0).GetComponent<Text>().text;
            }
        }
        if(c != null && c != "")
        {
            this.collapse.GetComponent<collapse>().Collapse(c);
            for (int i = 0; i < 2; i++)
            {
                Destroy(this.collapse.GetComponent<collapse>().Buttons[i]);
            }
            Destroy(GameObject.Find("measureButton(Clone)"));
        }
        this.Director.GetComponent<Director>().ButtonReset();
        foreach(int x in Round.InteractableFalseCells_num)
        {
            print("InteractableFalseCells_num = "+x);
        }
        if (this.Director.GetComponent<Director>().checkWinning())
        {

            
            //Text text = Instantiate(Winner, transform, false) as Text;
           // Winner.transform.SetParent(Canvas.transform, false);
            //Winner.GetComponent<Text>().text = Round.Winner;
        }
    }

}
