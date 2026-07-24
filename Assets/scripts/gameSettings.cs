using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class gameSettings : MonoBehaviour
{

    [Header("Attach To System")]
    public scoreDistanceSystem _scoreDistanceSystem;
    public economySystem _ekonomi;
    public Transform _playerPos;
    public AudioSource music;
    bool isWinProccessed;


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
                isWinProccessed = false;
                break;

            case UIState.Pause:
                HideAll();
                uiPause.SetActive(true);
                Time.timeScale = 0f;
                isPlay = false;
                break;

            case UIState.Win:
                if (!isWinProccessed)
                {
                    HideAll();
                    uiWin.SetActive(true);
                    Time.timeScale = 0f;
                    isPlay = false;
                    int Reward = Mathf.FloorToInt(_scoreDistanceSystem.distance);
                    _ekonomi.Point += Reward;

                    isWinProccessed = true;

                    PlayerPrefs.SetInt("Point", _ekonomi.Point);
                    PlayerPrefs.Save();
                }
                break;

            case UIState.GameOver:
                HideAll();
                uiGameover.SetActive(true);
                Time.timeScale = 1f;
                isPlay = false;
                _ekonomi.PointOnRun = 0;
                _playerPos.position -= Vector3.down * 3;
                break;

            case UIState.MainMenu:
                HideAll();
                isPlay = false;
                uiMainMenu.SetActive(true);
                Time.timeScale = 1f;
                
                PlayerPrefs.GetInt("Point", 0);
                break;
        }
    }

    public void Update()
    {
        if (isPlay) { music.mute = false; } else { music.mute = true; }
    }


    public void exitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SetState(UIState.MainMenu);
    }
}
