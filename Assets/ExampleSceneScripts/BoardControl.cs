using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class BoardControl : MonoBehaviour
{
    GameObject nextButton;
    GameObject Cells;
    GameObject nextButton2;
    public GameObject NextStepButtonPrefab;
    public float showForSeconds = 1.0f;
    public GameObject NextButtonPrefab2;
    public GameObject NextButtonPrefab;
    public GameObject ClickedAnime;
    public bool forthStep = false;
    public GameObject animePage1;
    public GameObject nextScene;
    public GameObject Mask;
    GameObject InteractiveUI;
    // GameObject animePage1;
    void Start()
    {
        //this.animePage1 = GameObject.Find("animePage1");
        this.Cells = GameObject.Find("CellGenerator");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
        //Invoke("CellsDisable", 0);
        
    }
    void Update()
    {
        //if(forthStep == true)
        //{
        //    Transion();
        //}

    }
    public void AcallFirstStep()
    {
        CellsDisable();
        Invoke("FirstStep", 0.35f);
    }
    public void FirstStep()
    {
    
        print("FirstStep");
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("接下來請點擊兩格白底格子");
        TypeWriter.Active();
        for (int i = 4; i < 6; i++)                      //請選擇5、6格子
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
        Mask.SetActive(true);
        Invoke("SecondStep", 1.5f);
    }
    public void SecondStep()
    {
        print("SecondStep");
        Instantiate(NextStepButtonPrefab, transform);
        
    }
    public void AcallSecondPoint5Step()
    {
        Invoke("SecondPoint5Step", 0.4f);
    }
    public void SecondPoint5Step()
    {
        print("SecondPoint5Step");
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("接下來請點擊兩格白底格子");
        TypeWriter.Active();
        for (int i = 1; i < 6; i += 3)                      //請選擇5、6格子
        {
            //print("i = "+i);
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
        print("ThirdStep");
        for (int i = 1; i < 6; i += 4)                      //請選擇2、6格子
        {
            //print("i = " + i);
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
        Invoke("ForthStep", 1.5f);
    }
    void ForthStep()
    {
        print("ForthStep");
        Instantiate(NextStepButtonPrefab, transform);
        //nextButton = Instantiate(NextButtonPrefab, transform);
        forthStep = true;

    }




    public void AcallFifthStep()
    {
        Invoke("FifthStep", 0.5f);
    }
    void FifthStep()
    {
        //acallFunckeepTyping();
        print("FifthStep");
        Invoke("InstantiateNextButton", 2f);
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("此時第 ②、⑤、⑥ 格子形成封閉迴圈當迴圈形成後" +
            "\n我們就要開始進行觀測" +
            "\n若觀測格子②，則會發生影片內所提到的，一系列「塌縮」" +
            "\n\n接下來依指示點擊格子②");
        TypeWriter.Active();
    }
    //void acallFunckeepTyping()
    //{
    //    StartCoroutine(keepTyping());
    //}
    //IEnumerator keepTyping()
    //{
    //    yield return new WaitForSecondsRealtime(1.4f);
    //    Invoke("InstantiateNextButton", 3.5f);
    //    print("KeepTyping");
    //    InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
    //    TypeWriter.Add("此時第 ②、⑤、⑥ 格子形成封閉迴圈\n" +
    //            "觀察X₁在⑤格子→另一個X₁在⑥格子\n→⑥格子內有X₂→另一個X₂在②格子\n→②格子內有O₁→另一個O₁在⑤格子，又回到一開始觀察X₁所在的⑤格子\n" +
    //            "\n不管以哪個字母為起點，去觀察另一個量子糾纏的字母(另一半)在的格子中，只要觀察到最後有其他字母的另一半能重新回到起點的格子\n則有「封閉迴圈」");
    //    TypeWriter.Active();
    //}
    void InstantiateNextButton()
    {
        ClickedAnime.SetActive(true);
        nextButton = Instantiate(NextButtonPrefab2, transform);
    }






    public void AcallSixthStep()
    {
        SixthStep();
    }
    void SixthStep()
    {
        print("SixthStep");
        ClickedAnime.SetActive(false);
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("接下來請選擇想觀測的元素後" +
            "\n按下measure鍵，即完成對特定元素的觀測了!\r\n");
        TypeWriter.Active();
    }


    public void AcallSevenhStep()
    {
        SevenhStep();
    }
    void SevenhStep()
    {
        print("SevenhStep");
        nextScene.SetActive(true);
    }



    public void AcallFuncAnimeScene()
    {
        animePage1.SetActive(true);
        
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
        text.color = Color.Lerp(Color.blue, Color.yellow, Mathf.PingPong(Time.time/2, 1));
    }
















    
    // Start is called before the first frame update


    // Update is called once per frame


}
