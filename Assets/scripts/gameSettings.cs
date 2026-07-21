using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class gameSettings : MonoBehaviour
{

    [Header("Attach To System")]
    public scoreDistanceSystem _scoreDistanceSystem;
    public bool isPlay;

    [Header("UI Game Object")]
    public GameObject uiGameplay;
    public GameObject uiPause;
    public GameObject uiWin;
    public GameObject uiGameover;


    public enum UIState
    {
        Gameplay,
        Pause,
        Win,
        GameOver
    }



    bool isPause;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void HideAll()
    {
        uiGameplay.SetActive(false);
        uiPause.SetActive(false);
        uiWin.SetActive(false);
        uiGameover.SetActive(false);
    }

    public void SetState(UIState state)
    {
        HideAll();

        switch (state)
        {
            case UIState.Gameplay:
                uiGameplay.SetActive(true);
                Time.timeScale = 1f;
                break;

            case UIState.Pause:
                uiPause.SetActive(true);
                Time.timeScale = 0f;
                break;

            case UIState.Win:
                uiWin.SetActive(true);
                Time.timeScale = 0f;
                break;

            case UIState.GameOver:
                uiGameover.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
