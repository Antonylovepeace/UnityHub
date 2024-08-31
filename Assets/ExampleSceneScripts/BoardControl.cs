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
    public GameObject ClickedAnime1;
    public GameObject ClickedAnime2;
    public GameObject ClickedAnime3;
    public GameObject Mask2;
    public GameObject Mask3;
    public GameObject Mask4;
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
        TypeWriter.Add("與一般井字遊戲不同" +
            "\n玩家可在一回合內下兩次，但需下在不同格子" +
            "\r\n接下來請跟隨框框內的指示" +
            "\n\n➤ 請點擊兩格白色格子\r\n");
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
        TypeWriter.Add("在此遊戲中，同一個格子內可有多個 O、X 同時存在" +
            "\n但如前面所說" +
            "\n同一回合內，同個格子不能重複下兩次" +
            "\r\n\n➤ 請點擊兩格白色格子\r\n");
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
        Mask4.SetActive(true);
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

        Invoke("anime", 2f);
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("此時第 ②、⑤、⑥ 格子形成封閉迴圈當迴圈形成後 " +
            "\n我們就要開始進行觀測 " +
            "\n若觀測格子②，則會發生影片內所提到的，一系列「塌縮」" +
            "\n那「塌縮」究竟是怎樣的一個過程呢" +
            "\n\n➤ 點擊格子②看詳細「塌縮」過程");
        TypeWriter.Active();
    }
    void anime()
    {
        Cell cells = this.Cells.GetComponent<CellGenerator>().cells[1];
        Button cell = cells.GetComponent<Button>();
        ColorBlock colors = cell.colors;
        colors.normalColor = new Color32(255, 255, 255, 90);
        cell.colors = colors;
        Mask2.SetActive(true);
        CellsInteractable(1, 1, 1);
        ClickedAnime1.SetActive(true);
    }
    public void AcallFifthPointOneStep()
    {
        Invoke("FifthPointOneStep", 0.5f);
    }
    void FifthPointOneStep()
    {
        Mask4.SetActive(false);
        ClickedAnime1.SetActive(false);
        ClickedAnime2.SetActive(true);
    }
    public void AcallFifthPointTwoStep()
    {
        Invoke("FifthPointTwoStep", 0.5f);
    }
    void FifthPointTwoStep()
    {
        Mask2.SetActive(false);
        Mask3.SetActive(true);
        ClickedAnime2.SetActive(false);
        ClickedAnime3.SetActive(true);
    }
    public void AcallFifthPointThreeStep()
    {
        Invoke("FifthPointThreeStep", 0.5f);
    }
    void FifthPointThreeStep()
    {
        Mask3.SetActive(false);
        ClickedAnime3.SetActive(false);
        AcallFuncAnimeScene();
        CellsInteractable(1, 4, 5);
        Round.AnimeArrowLoop = true;
        Round.AnimeCircleLoop = false;
    }









    public void AcallSixthStep()
    {
        SixthStep();
    }
    void SixthStep()
    {
        print("SixthStep");
        
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("此時第 ②、⑤、⑥ 格子形成封閉迴圈" +
            "\n選擇棋盤上你想觀測的格子並點擊它" +
            "\n右側會出現格子中可被觀測的元素" +
            "\n選擇你想觀測的元素(綠色框框)並按下 measure" +
            "\n這樣就完成觀測了" +
            "\n\n注意到，觀測不同的元素可能造成的結果會不同，" +
            "\n可試著想像，如何觀測，才可使你獲得最大的優勢喔！r\n");
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
    void CellsInteractive()
    {
        for (int i = 0; i < 9; i++)
        {
            this.Cells.GetComponent<CellGenerator>().cells[i].GetComponent<Button>().interactable = true;
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
