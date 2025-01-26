using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;   
    public AudioSource backgroundMusic; 

    void Start()
    {
        if (backgroundMusic != null)
            volumeSlider.value = backgroundMusic.volume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        if (backgroundMusic != null)
            backgroundMusic.volume = volume;
    }
}
