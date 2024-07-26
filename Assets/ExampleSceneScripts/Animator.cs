using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                mAnimator.SetTrigger("TrCircle");
                //StartCoroutine(animeArrow());
            }
            
            
        }
    }
    IEnumerator animeArrow()
    {
        yield return new WaitForSecondsRealtime(1.3f);
        print("enter");
        mAnimator.ResetTrigger("TrCircle");
    }
}
