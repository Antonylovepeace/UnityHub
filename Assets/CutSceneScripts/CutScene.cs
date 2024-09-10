using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pvpButtonOnClicked()
    {
        page1.SetActive(false);
        Round.PVP = true;
        SceneManager.LoadScene("GameScene");
    }
    public void PlayerVsPcButtonOnClicked()
    {
        Round.PVP = false;
        page1.SetActive(false);
        page2.SetActive(true);
    }
}
