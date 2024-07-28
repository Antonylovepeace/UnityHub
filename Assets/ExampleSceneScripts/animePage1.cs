using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animePage1 : MonoBehaviour
{
    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;
    public GameObject pointer4;
    public GameObject pointer5;
    public GameObject pointer6;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("AcallFuncAnimeLoop", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcallFuncAnimeLoop()
    {
        StartCoroutine(loop1());
    }

    IEnumerator loop1()
    {
        pointer1.SetActive(true);
        pointer4.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        pointer1.SetActive(false);
        pointer2.SetActive(true);

        pointer4.SetActive(false);
        pointer5.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        pointer2.SetActive(false);
        pointer3.SetActive(true);

        pointer5.SetActive(false);
        pointer6.SetActive(true);
        StartCoroutine(loop2());
    }




    IEnumerator loop2()
    {
        yield return new WaitForSecondsRealtime(2f);
        pointer3.SetActive(false);
        pointer6.SetActive(false);
        if (Round.AnimeArrowLoop == true)
        {
            StartCoroutine(loop2());
        }
        StartCoroutine(loop1());
    }

}
