using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Measure : MonoBehaviour
{
    public Text Winner;
    public GameObject measureButton;
    GameObject collapse;
    GameObject newButton;
    GameObject Director;
    GameObject Canvas;
    GameObject InteractiveUI;
    string c;
    // Start is called before the first frame update
    void Start()
    {
        this.collapse = GameObject.Find("collapse");
        this.Director = GameObject.Find("Director");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
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
                TextMeshProUGUI text = newBt.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                c = text.text;
                //c = newBt.transform.GetChild(0).GetComponent<Text>().text;
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
            this.Director.GetComponent<Director>().ButtonReset();
            this.Director.GetComponent<Director>().AcallFuncCheckWin(c);
            //StartCoroutine(DelayFunc(c));

            //if (this.Director.GetComponent<Director>().checkWinning() == false)
            {
 
                //InteractiveUI.GetComponent<InteractiveUI>().Quantum_collapse(c);
            }
            
        }       
    }
    IEnumerator DelayFunc(string c)
    {
        Round.timeDelay += 0.2f;
        print("timeDelay =" + Round.timeDelay);
        yield return new WaitForSecondsRealtime(5);
       
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
}
