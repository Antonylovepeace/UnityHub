using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public bool Xturn = true;
    public int TurnCount = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetCharacter()
    {

        if (Xturn == true)
        {
            return "X";
        }
        else
        {
            return "O";
        }

    }

    public void SwitchPlayer()
    {
        TurnCount++;
        if(TurnCount == 2)
        {
            Xturn = !Xturn;
            TurnCount = 0;
        }        
    }
}


