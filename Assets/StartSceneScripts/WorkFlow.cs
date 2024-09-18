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
    GameObject AudioManager;

    public GameObject VideoScene;
    public GameObject MainScene;
    public GameObject Mask;
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
        this.AudioManager = GameObject.Find("AudioManager");
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
        AudioManager.GetComponent<AudioManager>().StartSFX();
        Time.timeScale = 1.0f;
        resetBoard();
        SceneManager.LoadScene("ExampleScene");
    }
    public void SkipButtonOnClick()
    {
        Time.timeScale = 1.0f;
        resetBoard();
        //this.BoardControl.GetComponent<BoardControl>().AcallSevenhStep();
        SceneManager.LoadScene("CutScene");
    }


    
    public void NextButton_2OnClicked()
    {
        //this.BoardControl.GetComponent<BoardControl>().AcallFuncAnimeScene();
        //this.BoardControl.GetComponent<BoardControl>().AcallFifthPointOneStep();
        //Destroy(GameObject.Find("NextButton2(Clone)"));
        //ButtonsInteractive();
        //Round.AnimeArrowLoop = true;
        //Round.AnimeCircleLoop = false;

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
        Round.videoCounter = 1;
        Round.afterVideo_Anime = 0;
        Round.FirstMove = false;
        Round.Winner = "";
        Round.AnimeCircleLoop = false;
        Round.AnimeArrowLoop = false;
        Round.AI = true;
        Round.IntroductionPlayButton = 0;
        Round.MeasureButton_PlayAnime = true;
        Round.twoRound = 0;
    }

    public void PLAYButtonOnClicked()
    {
        this.IntroductionScene.GetComponent<IntroductionScene>().setSceneFalse();
    }
    public void nextButtonOnClicked()
    {
        if (Round.afterVideo_Anime == 0)
        {
            this.BoardControl.GetComponent<BoardControl>().AcallFirstStep();

            AudioManager.GetComponent<AudioManager>().Start();
        }
        if (Round.afterVideo_Anime == 1)
        {
            this.BoardControl.GetComponent<BoardControl>().AcallSecondPoint5Step();

            AudioManager.GetComponent<AudioManager>().Start();
        }
        if (Round.afterVideo_Anime == 2)
        {
            AudioManager.GetComponent<AudioManager>().Start();

            Round.AnimeCircleLoop = true;
            this.Anime.GetComponent<Animetion>().AcallFuncAnimeLoop();
            this.BoardControl.GetComponent<BoardControl>().forthStep = false;
            this.BoardControl.GetComponent<BoardControl>().AcallFifthStep();
        }
        Round.afterVideo_Anime++;
        VideoScene.SetActive(false);
        Destroy(GameObject.Find("NextStepButton(Clone)"));
        //Mask.SetActive(false);
    }
    public void VideoStepButtonOnClicked()
    {
        ThreeVideo.GetComponent<VideoStep>().NextButtonOnClicked();
        //Destroy(GameObject.Find("NextStepButton(Clone)"));
    }
    public void ExitButtonOnClicked()
    {
        Application.Quit();
    }
}
