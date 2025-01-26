using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoToggle : MonoBehaviour
{
    public VideoPlayer videoPlayer; // لربط الـ VideoPlayer
    public RawImage rawImage; // لربط الـ RawImage

    private void Start()
    {
        // التأكد من الربط الصحيح
        if (videoPlayer == null || rawImage == null)
        {
            Debug.LogError("Please assign the necessary components.");
            return;
        }
    }

    public void ToggleVideo()
    {
        // إذا الفيديو بيشتغل، يبقى نقفله
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            // إذا الفيديو مابيشتغلش، نبدأ تشغيله
            videoPlayer.Play();
        }
    }
}
