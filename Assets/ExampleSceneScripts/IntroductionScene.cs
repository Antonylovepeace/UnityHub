using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionScene : MonoBehaviour
{
    public GameObject IntroScenen;
    public GameObject MainScene;
    public GameObject PLAYButtonPrefab;

    GameObject IntroScene;
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
        IntroScenen.SetActive(false);
        MainScene.SetActive(true);
    }
    public void Introduction()
    {
        transform.GetComponent<TypeWriter>().messages.Clear();
        TypeWriter.Add("Welcome to Quantum Tic Tac Toe!!!\r\n");
        TypeWriter.Active();
    }
}
