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
        Invoke("Text_ReadyToPlayWithPC", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Text_ReadyToPlayWithPC()
    {
        TypeWriter2.Add("正式開始遊戲"  );
        TypeWriter2.Active();
    }

    public void FirstMoverButtonOnClicked()
    {
        print("FirstMoverButtonOnClicked");
        SceneManager.LoadScene("GameScene");
        nextScene.SetActive(false);
        Round.FirstMove = true;
    }
    public void SecondMoveButtonOnClicked()
    {
        print("SecondMoveButtonOnClicked");
        SceneManager.LoadScene("GameScene");
        nextScene.SetActive(false);
        Round.FirstMove = false;
    }
}
