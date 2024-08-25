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

    [SerializeField] public RawImage rawImage; // 在Inspector中指定Raw Image

    private VideoPlayer videoPlayer;
    private RenderTexture renderTexture;
    //public int videoCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.video = GameObject.Find("BackgroundVid");

        renderTexture = new RenderTexture(1920, 1080, 0); // 設置寬度、高度和深度
        rawImage.texture = renderTexture; // 將Render Texture設置為Raw Image的紋理

        VideoGo();
    }

    public void VideoGo()
    {

        videoPlayer = video.AddComponent<UnityEngine.Video.VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.url = videoPath;

            videoPlayer.targetTexture = renderTexture; // 將Render Texture設置為Video Player的目標紋理

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