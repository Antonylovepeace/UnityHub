using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RulesMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPause = false;
    public GameObject Rules_Menu;
    // Update is called once per frame
    public void exclamation_mark_ButonButtonOnSelected()
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
