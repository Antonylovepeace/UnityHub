using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Opening : MonoBehaviour
{
    public GameObject InteractiveUi;
    public GameObject opening;
    public GameObject StartButton;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "ExampleScene")
        {
            //TypeWriterMessage.timerPerChar = 0.05f;
            transform.GetComponent<TypeWriter>().messages.Clear();
            TypeWriter.Add("welcome to quantum tic tac toe！\n" +
                "這不是普通的井字遊戲，而是結合了簡單的量子概念\n" +
                "讓你在遊戲中體驗量子的奇妙。\n" +
                "每一步都有其獨特的量子意義，帶你快速了解量子的基本概念\n" +
                "準備好迎接挑戰，探索量子的奧秘吧！\r\n");
            TypeWriter.Active();
        }
        Invoke("startButton", 1.5f);
    }
    void startButton()
    {
        Instantiate(StartButton, transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AcallFuncStartButtonOnClicked()
    {
        InteractiveUi.SetActive(true);
        opening.SetActive(false);
        Destroy(GameObject.Find("StartButton(Clone)"));
    }
}
