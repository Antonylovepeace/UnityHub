using System.Collections;
using System.Collections.Generic;
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
    public void MainMenuButtonOnSelected()
    {
        SceneManager.LoadScene("StartScene");
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void restartButtom()
    {
        QuitButtonOnSelected();
        SceneManager.LoadScene("GameScene");
    }
}
