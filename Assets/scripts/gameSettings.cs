using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class gameSettings : MonoBehaviour
{

    [Header("Attach To System")]
    public scoreDistanceSystem _scoreDistanceSystem;
    public economySystem _ekonomi;

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

    public UIState state;

    void Start()
    {
        SetStateInt(4);
    }

    public void SetStateInt(int stateIndex)
    {
        state = (UIState)stateIndex;
        SetState(state);
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
                HideAll();
                isPlay = true;
                uiGameplay.SetActive(true);
                Time.timeScale = 1f;
                break;

            case UIState.Pause:
                HideAll();
                uiPause.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                break;

            case UIState.Win:
                HideAll();
                uiWin.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                _ekonomi.Point = +Mathf.FloorToInt(_scoreDistanceSystem.distance);
                break;

            case UIState.GameOver:
                HideAll();
                uiGameover.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                _ekonomi.Point -= Mathf.FloorToInt(_scoreDistanceSystem.distance * 2);
                break;

            case UIState.MainMenu:
                HideAll();
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
