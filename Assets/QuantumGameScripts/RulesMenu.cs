using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject Rules_Menu;
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

    
}
