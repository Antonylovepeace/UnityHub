using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonOnClicked : MonoBehaviour
{
    public GameObject opening;
    GameObject TypeWriter;
    // Start is called before the first frame update
    void Start()
    {
        this.TypeWriter = GameObject.Find("Opening");
        this.opening = GameObject.Find("Opening");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startButtonOnClicked()
    {
        opening.GetComponent<Opening>().AcallFuncStartButtonOnClicked();
        //TypeWriter.GetComponent<TypeWriterMessage>().timerPerChar = 0.05f;
    }
}
