using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExInteractiveUI : MonoBehaviour
{
    GameObject interactiveUI;
    // Start is called before the first frame update
    void Start()
    {
        this.interactiveUI = GameObject.Find("InteractiveUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstExample()
    {
        interactiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("基本規則：\n玩家每回合可下兩次\n請點擊九宮格中的任一兩個空格");
        TypeWriter.Active();
    }
}
