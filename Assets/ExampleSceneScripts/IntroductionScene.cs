using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionScene : MonoBehaviour
{
    public GameObject IntroScene;
    public GameObject MainScene;
    public GameObject VideoScene;
    public GameObject PLAYButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateButton());
        Introduction();
    }
    IEnumerator InstantiateButton()
    {
        yield return new WaitForSecondsRealtime(3f);
        GameObject PLAYButton = Instantiate(PLAYButtonPrefab, transform);
    }

    public void setSceneFalse()
    {
        if(Round.IntroductionPlayButton == 0)
        {
            transform.GetComponent<TypeWriter2>().messages.Clear();
            TypeWriter2.Add("接下是簡單的遊戲教學\r\n" +
                "\n右側按鈕開始播放影片\r\n");
            TypeWriter2.Active();
        }
        else if (Round.IntroductionPlayButton == 1)
        {
            IntroScene.SetActive(false);
            VideoScene.SetActive(true);
        }
        Round.IntroductionPlayButton++;
    }
    public void Introduction()
    {
        transform.GetComponent<TypeWriter2>().messages.Clear();
        TypeWriter2.Add("welcome to quantum tic tac toe！" +
            "\n\n這不是普通的井字遊戲，而是結合了簡單的量子概念" +
            "\n\n讓你在遊戲中體驗量子的奇妙。" +
            "\n\n每一步都有其獨特的量子意義，帶你快速了解量子的基本概念。" +
            "\n\n準備好迎接挑戰，探索量子的奧秘吧！");
        TypeWriter2.Active();
    }
}
