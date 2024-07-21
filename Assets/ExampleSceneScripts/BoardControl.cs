using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BoardControl : MonoBehaviour
{
    public GameObject NextButtonPrefab;
    GameObject nextButton;
    public float showForSeconds = 1.0f;
    GameObject Cells;

    public bool forthStep = false;


    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        Invoke("CellsDisable", 0);
        Invoke("FirstStep", 1);
    }
    void Update()
    {
        if(forthStep == true)
        {
            Transion();
        }

    }

    public void FirstStep()
    {
        for(int i = 4; i < 6; i++)                      //請選擇5、6格子
        {
            Cell cells = this.Cells.GetComponent<CellGenerator>().cells[i];
            Button cell = cells.GetComponent<Button>();
            ColorBlock colors = cell.colors;
            colors.normalColor = new Color32(255, 255, 255, 90);
            cell.colors = colors;
        }
        CellsInteractable(4, 5, 5);
    }

    public void AcallSecondStep()
    {
        Invoke("SecondStep", 2);
    }
    public void SecondStep()
    {
        for (int i = 1; i < 6; i += 3)                      //請選擇5、6格子
        {
            print("i = "+i);
            Cell cells = this.Cells.GetComponent<CellGenerator>().cells[i];
            Button cell = cells.GetComponent<Button>();
            ColorBlock colors = cell.colors;
            colors.normalColor = new Color32(255, 255, 255, 90);
            cell.colors = colors; 
        }
        CellsInteractable(1, 4, 4);
    }


    public void AcallThirdStep()
    {
        Invoke("ThirdStep", 2);
    }
    public void ThirdStep()
    {
        for (int i = 1; i < 6; i += 4)                      //請選擇2、6格子
        {
            print("i = " + i);
            Cell cells = this.Cells.GetComponent<CellGenerator>().cells[i];
            Button cell = cells.GetComponent<Button>();
            ColorBlock colors = cell.colors;
            colors.normalColor = new Color32(255, 255, 255, 90);
            cell.colors = colors;
        }
        CellsInteractable(1, 5, 5);
    }


    public void AcallForthStep()
    {
        Invoke("ForthStep", 5);
    }
    public void ForthStep()
    {
        print("ForthStep");
        nextButton = Instantiate(NextButtonPrefab, transform);
        forthStep = true;
    }

    
    public void CellsInteractable(int a,int b,int c)
    {
        for( int i = 0; i < 9; i++)
        {
            if(i == a || i == b || i == c)
            {
                this.Cells.GetComponent<CellGenerator>().cells[i].GetComponent<Button>().interactable = true;
            }
        }
    }
    public void CellsDisable()
    {
        for (int i = 0; i < 9; i++)
        {             
            this.Cells.GetComponent<CellGenerator>().cells[i].GetComponent<Button>().interactable = false;
        }
    }


    void Transion()
    {
        UnityEngine.UI.Text text = nextButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        print("Time.time = " + Time.time / 2);
        text.color = Color.Lerp(Color.blue, Color.yellow, Mathf.PingPong(Time.time/2, 1));
    }
















    
    // Start is called before the first frame update


    // Update is called once per frame


}
