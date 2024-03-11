using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    GameObject Button;
    public TextMeshProUGUI mytext;
    // Start is called before the first frame update
    void Start()
    {
        Button = GameObject.Find("abc");
        TextMeshProUGUI text = this.Button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.text = "H<sub>2</sub>O";
        //transform.GetComponent<TextMeshPro>().text = "1m<sup>3</sup> of H<sub>2</sub>O";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void write()
    {
        mytext.text = "1m<sup>3</sup> of H<sub>2</sub>O";
        //this.Button.transform.GetChild(0).GetComponent<TextMeshPro>().text = "1m<sup>3</sup> of H<sub>2</sub>O";
    }
}
