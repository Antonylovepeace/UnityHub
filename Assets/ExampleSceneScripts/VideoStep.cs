using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoStep : MonoBehaviour
{
    public GameObject VideoScene;
    GameObject Anime;
    GameObject BoardControl;
    public GameObject VidPlayer;
    GameObject AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        this.Anime = GameObject.Find("Animation");
        this.BoardControl = GameObject.Find("BoardControl");
        this.AudioManager = GameObject.Find("AudioManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextButtonOnClicked()
    {
        Round.videoCounter++;
        VideoScene.SetActive(true);
        VidPlayer.GetComponent<VidPlayer>().VideoGo();

        AudioManager.GetComponent<AudioManager>().MusicStop();
    }
}
