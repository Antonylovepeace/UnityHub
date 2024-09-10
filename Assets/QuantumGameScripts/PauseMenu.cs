using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    public void PauseButtonOnSelected()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitButtonOnSelected()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

   public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void restartButton()
    {
        QuitButtonOnSelected();
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            resetBoard();
            SceneManager.LoadScene("CutScene");
        }
        else if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            resetBoard();
            SceneManager.LoadScene("ExampleScene");
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
    }
}
