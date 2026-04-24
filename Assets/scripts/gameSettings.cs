using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class gameSettings : MonoBehaviour
{
    public AudioMixer mixer;

    [Header("UI Slider")]
    public Slider musicSlider;
    public Slider sfxSlider;



    bool isPause;

    void Start()
    {
        isPause = false;
        // default value
        // musicSlider.value = PlayerPrefs.GetFloat("musicVol", 0.75f);
        // sfxSlider.value = PlayerPrefs.GetFloat("sfxVol", 0.75f);
        if(musicSlider != null || sfxSlider != null )
        {
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
            
        }
    }

    void Update()
    {

    }

    public void pause()
    {
        Time.timeScale = 0;
        isPause = true;
        mixer.SetFloat("music", -80);
    }

    public void resume()
    {
        Time.timeScale = 1;
        isPause = false;

        float value = PlayerPrefs.GetFloat("musicVol", 0.75f);
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;

        mixer.SetFloat("music", PlayerPrefs.GetFloat("musicVol", value));
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void SetMusicVolume(float value)
    {
        // convert ke dB
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        mixer.SetFloat("music", dB);

        PlayerPrefs.SetFloat("musicVol", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        mixer.SetFloat("sfx", dB);

        PlayerPrefs.SetFloat("sfxVol", value);
        PlayerPrefs.Save();
    }
}
