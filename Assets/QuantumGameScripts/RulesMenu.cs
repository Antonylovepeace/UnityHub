using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject Rules_Menu;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject image;
    // Update is called once per frame
    public void HintButtonOnClick()
    {
        Rules_Menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackButtonOnSelected()
    {
        Rules_Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void NextPageButton()
    {
        image.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(true);
        Time.timeScale = 1f;
    }
    public void FrontPageButton()
    {
        image.SetActive(false);
        Page1.SetActive(true);
        Page2.SetActive(false);
        Time.timeScale = 1f;
    }

}
