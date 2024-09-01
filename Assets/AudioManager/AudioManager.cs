using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMsource;
    [SerializeField] AudioSource SFXsource;

    public AudioClip Start_Scene;
    public AudioClip Example_Scene;
    public AudioClip Game_Scene;
    public AudioClip Start_SFX;
    public AudioClip OorX_SFX;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
            BGMsource.clip = Start_Scene;
        if (SceneManager.GetActiveScene().name == "ExampleScene")
            BGMsource.clip = Example_Scene;
        if (SceneManager.GetActiveScene().name == "GameScene")
            BGMsource.clip = Game_Scene;

        BGMsource.Play();
    }

    public void StartSFX()
    {
        SFXsource.clip = Start_SFX;
        SFXsource.Play();
    }

    public void OorXSFX()
    {
        SFXsource.clip = OorX_SFX;
        SFXsource.Play();
    }

    public void MusicStop()
    {
        BGMsource.Stop();
    }

}
