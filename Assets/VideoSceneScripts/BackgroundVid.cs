using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackgroundVid : MonoBehaviour
{
    [SerializeField] string videoFileName;
    GameObject video;

    [SerializeField] public RawImage rawImage; // �bInspector�����wRaw Image

    private VideoPlayer videoPlayer;
    private RenderTexture renderTexture;
    //public int videoCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.video = GameObject.Find("BackgroundVid");

        renderTexture = new RenderTexture(1920, 1080, 0); // �]�m�e�סB���שM�`��
        rawImage.texture = renderTexture; // �NRender Texture�]�m��Raw Image�����z

        VideoGo();
    }

    public void VideoGo()
    {

        videoPlayer = video.AddComponent<UnityEngine.Video.VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.url = videoPath;

            videoPlayer.targetTexture = renderTexture; // �NRender Texture�]�m��Video Player���ؼЯ��z

            videoPlayer.playOnAwake = false;
            videoPlayer.waitForFirstFrame = true;
            videoPlayer.isLooping = true;
            videoPlayer.Play();
        }

        if (renderTexture != null)
        {
            renderTexture.Release();
        }
    }

}