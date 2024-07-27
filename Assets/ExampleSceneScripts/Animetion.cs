using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animetion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject circle1;
    public GameObject circle2; 
    public GameObject circle3;
    public GameObject circle4;
    public GameObject circle5;
    public GameObject circle6;
    public GameObject Page1;
    public GameObject Page2;

    void Start()
    {
        //StartCoroutine(loop1());
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
        arrow1.SetActive(true);
        circle1.SetActive(true);
        circle2.SetActive(true);
        yield return new WaitForSecondsRealtime(1.6f) ;
        if(Round.AnimeLoop == true)
        {
            StartCoroutine(loop2());
        }
        yield return new WaitForSecondsRealtime(0.4f);
        arrow1.SetActive(false);
        circle1.SetActive(false);
        circle2.SetActive(false);
        
    }
    IEnumerator loop2()
    {
        arrow2.SetActive(true);
        circle3.SetActive(true);
        circle4.SetActive(true);
        yield return new WaitForSecondsRealtime(1.6f);
        StartCoroutine(loop3());
        yield return new WaitForSecondsRealtime(0.4f);
        arrow2.SetActive(false);
        circle3.SetActive(false);
        circle4.SetActive(false);
    }
    IEnumerator loop3()
    {
        arrow3.SetActive(true);
        circle5.SetActive(true);
        circle6.SetActive(true);
        yield return new WaitForSecondsRealtime(1.6f);
        StartCoroutine(loop1());
        yield return new WaitForSecondsRealtime(0.4f);
        arrow3.SetActive(false);
        circle5.SetActive(false);
        circle6.SetActive(false);
    }
    public void NextPageButtonOnClicked()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
    }
}
