using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Measure : MonoBehaviour
{
    public GameObject measureButton;
    GameObject collapse;
    GameObject newButton;
    GameObject Director;
    string c;
    // Start is called before the first frame update
    void Start()
    {
        this.collapse = GameObject.Find("collapse");
        this.Director = GameObject.Find("Director");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildButton()
    {
        newButton = Instantiate(measureButton,transform);
    }


<<<<<<< HEAD
=======
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
            //Destroy(GameObject.Find("measureButton(Clone)"));
        }
        this.Director.GetComponent<Director>().ButtonReset();
        foreach(int x in Round.InteractableFalseCells_num)
        {
            print("InteractableFalseCells_num = "+x);
        }
        Director.GetComponent<Director>().checkWinning();
    }
>>>>>>> parent of f2f2345 (WinnerText)

}
