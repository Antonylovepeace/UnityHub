using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class BoardControl : MonoBehaviour
{
    public float showForSeconds = 1.0f;
    GameObject Cells;
    void Start()
    {
        this.Cells = GameObject.Find("CellGenerator");
        Invoke("CellsDisable", 0);
        Invoke("FirstStep", 1);
    }
    void Update()
    {

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
        Invoke("ForthStep", 2);
    }
    public void ForthStep()
    {
        for (int i = 1; i < 6; i += 4)                      //請選擇2、6格子
        {
            
        }
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



















    IEnumerator DoTimer()
    {
        Cell cells =  this.Cells.GetComponent<CellGenerator>().cells[0];
        Button cell = cells.GetComponent<Button>();
        ColorBlock colors = cell.colors;
        colors.normalColor = new Color32(255, 0, 0, 255);
        cell.colors = colors;
        yield return new WaitForSeconds(showForSeconds);
        colors.normalColor = new Color32(255, 128, 128, 255);
        cell.colors = colors;
    }
    // Start is called before the first frame update


    // Update is called once per frame


}
