using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public GameObject nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerVSplayerButtonOnClicked()
    {
        SceneManager.LoadScene("GameScene");
        nextScene.SetActive(false);
    }
    public void pcVSplayerButtonOnClicked()
    {
        print("pcVSplayerButtonOnClicked");
        nextScene.SetActive(false);
    }
}
