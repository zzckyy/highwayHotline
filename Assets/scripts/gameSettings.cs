using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class gameSettings : MonoBehaviour
{

    [Header("Attach To System")]
    public scoreDistanceSystem _scoreDistanceSystem;

    [HideInInspector]
    public bool isPlay;

    [Header("UI Game Object")]
    public GameObject uiGameplay;
    public GameObject uiPause;
    public GameObject uiWin;
    public GameObject uiGameover;
    public GameObject uiMainMenu;


    public enum UIState
    {
        Gameplay,
        Pause,
        Win,
        GameOver,
        MainMenu
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
        uiMainMenu.SetActive(false);
    }

    public void SetState(UIState state)
    {
        switch (state)
        {
            case UIState.Gameplay:
                isPlay = true;
                uiGameplay.SetActive(true);
                Time.timeScale = 1f;
                break;

            case UIState.Pause:
                uiPause.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                break;

            case UIState.Win:
                uiWin.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                break;

            case UIState.GameOver:
                uiGameover.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                break;

            case UIState.MainMenu:
                isPlay = false;
                uiMainMenu.SetActive(true);
                Time.timeScale = 1f;
                break;
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
