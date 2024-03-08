using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Measure : MonoBehaviour
{
    public GameObject measureButton;
    GameObject collapse;
    GameObject newButton;
    string c;
    // Start is called before the first frame update
    void Start()
    {
        this.collapse = GameObject.Find("collapse");

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
        
        print("selectedText = "+c);
    }

}
