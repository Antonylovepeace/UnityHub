using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] string videoFileName;
    GameObject video;

    [SerializeField] public RawImage rawImage; // �bInspector�����wRaw Image

    private VideoPlayer videoPlayer;
    private RenderTexture renderTexture;
    private string videoName;
    //public int videoCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.video = GameObject.Find("VidPlayer");

        renderTexture = new RenderTexture(1920, 1080, 0); // �]�m�e�סB���שM�`��
        rawImage.texture = renderTexture; // �NRender Texture�]�m��Raw Image�����z

        VideoGo();
    }

    public string VideoChoose()
    {
        if (Round.videoCounter == 1)
        {
            videoName = "Video2-1_1080P.mp4";
            rawImage.name = "Video2-1_1080P";
        }
        if (Round.videoCounter == 2)
        {
            videoName = "Video2-2_1080P.mp4";
            rawImage.name = "Video2-2_1080P";
        }
        if (Round.videoCounter == 3)
        {
            videoName = "Video2-3_1080P.mp4";
            rawImage.name = "Video2-3_1080P";
        }

        //videoCounter++;
        videoFileName = videoName;
        return videoFileName;
    }

    public void VideoGo()
    {
        VideoChoose();

        videoPlayer = video.AddComponent<UnityEngine.Video.VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.url = videoPath;

            videoPlayer.targetTexture = renderTexture; // �NRender Texture�]�m��Video Player���ؼЯ��z

            videoPlayer.playOnAwake = false;
            videoPlayer.waitForFirstFrame = true;
            videoPlayer.isLooping = false;
            videoPlayer.Play();
        }

        if (renderTexture != null)
        {
            renderTexture.Release();
        }
    }
    
}