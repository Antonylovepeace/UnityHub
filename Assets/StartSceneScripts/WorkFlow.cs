using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkFlow : MonoBehaviour
{

    GameObject InteractiveUI;
    GameObject CellGenerator;
    GameObject BoardControl;
    GameObject Anime;
    GameObject IntroductionScene;
    GameObject ThreeVideo;
    public GameObject VideoScene;
    public GameObject MainScene;
    //public GameObject AnimationScene;
    public int[] cells = { 1, 4, 5 };
    // Start is called before the first frame update
    void Start()
    {
        this.ThreeVideo = GameObject.Find("ThreeVideo");
        this.IntroductionScene = GameObject.Find("IntroductionScene");
        this.CellGenerator = GameObject.Find("CellGenerator");
        this.InteractiveUI = GameObject.Find("InteractiveUI");
        this.BoardControl = GameObject.Find("BoardControl");
        this.Anime = GameObject.Find("Animation");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startButtonOnSelect()
    {
        TextMeshProUGUI text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        text.color = Color.black;
    }
    public void startButtonDeSelect()
    {
        TextMeshProUGUI text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.color = Color.white;
    }

    public void StartButtonOnClick()
    {
        Time.timeScale = 1.0f;
        resetBoard();
        SceneManager.LoadScene("ExampleScene");
    }
    public void SkipButtonOnClick()
    {
        Time.timeScale = 1.0f;
        resetBoard();
        this.BoardControl.GetComponent<BoardControl>().AcallSevenhStep();
        //SceneManager.LoadScene("GameScene");
    }
    public void NextButton_1OnClicked()
    {
        InteractiveUI.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("但玩家想觀測，需要達成一項條件" +
            "\n那就是需要形成“封閉迴圈”" +
            "\n\n“封閉迴圈”只是此遊戲的特殊規則" +
            "\n並非實際量子物理的概念。\r\n");
        TypeWriter.Active();
        
        Round.AnimeCircleLoop = true;
        this.Anime.GetComponent<Animetion>().AcallFuncAnimeLoop();
        Destroy(GameObject.Find("NextButton1(Clone)"));
        this.BoardControl.GetComponent<BoardControl>().forthStep = false;
        this.BoardControl.GetComponent<BoardControl>().AcallFifthStep();


    }

    
    public void NextButton_2OnClicked()
    {
        this.BoardControl.GetComponent<BoardControl>().AcallFuncAnimeScene();
        Destroy(GameObject.Find("NextButton2(Clone)"));
        ButtonsInteractive();
        Round.AnimeArrowLoop = true;
        Round.AnimeCircleLoop = false;

    }


    void ButtonsInteractive()
    {
        foreach (int i in cells)
        {
            CellGenerator.GetComponent<CellGenerator>().cells[i].GetComponent<Button>().interactable = true;
        }
    }
    void resetBoard()
    {
        var lst = Round.InteractableFalseCells_num.ToList();
        var lst1 = Round.collapseCells.ToList();
        var lst2 = Round.collapseTexts.ToList();
        var lst3 = Round.InteractableFalseCells_num.ToList();
        lst.Clear();
        lst1.Clear();
        lst2.Clear();
        lst3.Clear();
        Round.InteractableFalseCells_num = lst.ToArray();
        Round.collapseCells = lst1.ToArray();
        Round.collapseTexts = lst2.ToArray();
        Round.InteractableFalseCells_num = lst3.ToArray();

        Round.charO_num = 0;
        Round.charX_num = 0;
        Round.typeWriter_quantumEntanglement = 0;
        Round.typeWriter_quantumSuperposition = 0;
        Round.Winner = "";
    }
    public void PLAYButtonOnClicked()
    {
        this.IntroductionScene.GetComponent<IntroductionScene>().setSceneFalse();
    }
    public void nextButtonOnClicked()
    {
        if (Round.afterVideo_Anime == 1)
        {
            Round.AnimeCircleLoop = true;
            this.Anime.GetComponent<Animetion>().AcallFuncAnimeLoop();
            this.BoardControl.GetComponent<BoardControl>().forthStep = false;
            this.BoardControl.GetComponent<BoardControl>().AcallFifthStep();
        }
        Round.afterVideo_Anime++;
        VideoScene.SetActive(false);
        Destroy(GameObject.Find("NextStepButton(Clone)"));
        
    }
    public void VideoStepButtonOnClicked()
    {
        ThreeVideo.GetComponent<VideoStep>().NextButtonOnClicked();
        //Destroy(GameObject.Find("NextStepButton(Clone)"));
    }
}
