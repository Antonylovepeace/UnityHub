using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill()
    {
        GameObject Grid = transform.GetChild(0).gameObject;
        GameObject text = Grid.transform.GetChild(ChecktFilled()).gameObject;
        text.GetComponent<Text>().text = "X";
    }
    public  ChecktFilled()
    {
        for(int i = 0; i <= 8; i++)
        {
            GameObject Grid = transform.GetChild(0).gameObject;
            GameObject text = Grid.transform.GetChild(i).gameObject;
            Text content = text.GetComponent<Text>();
            if (content == null)
            {
                return i;
            }
        }
        
    }
}
