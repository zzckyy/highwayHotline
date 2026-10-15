using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using CrazyGames;
public class gameSettings : MonoBehaviour
{

    [Header("Attach To System")]
    public scoreDistanceSystem _scoreDistanceSystem;
    public Transform _playerPos;
    public AudioSource music;

    bool _gameOverHandled;
    bool _crazySdkInitialized;
    bool _hasPendingScore;
    float _pendingScore;


    [HideInInspector]
    public bool isPlay;

    [Header("UI Game Object")]
    public GameObject uiGameplay;
    public GameObject uiPause;
    public GameObject uiGameover;
    public GameObject uiMainMenu;
    public GameObject uiHelp;


    public enum UIState
    {
        Gameplay,
        Pause,
        GameOver,
        MainMenu,
        Help
    }

    public UIState state;

    void Start()
    {
        if (Application.isEditor || Application.platform == RuntimePlatform.WebGLPlayer)
        {
            CrazySDK.Init(OnCrazySdkInitialized);
        }

        SetStateInt(3);
    }

    void OnCrazySdkInitialized()
    {
        _crazySdkInitialized = true;
        if (!_hasPendingScore) return;

        CrazySDK.User.AddScore(_pendingScore);
        _hasPendingScore = false;
    }

    void ReportScore(float score)
    {
        if (!Application.isEditor && Application.platform != RuntimePlatform.WebGLPlayer) return;

        if (_crazySdkInitialized)
        {
            CrazySDK.User.AddScore(score);
            return;
        }

        _pendingScore = score;
        _hasPendingScore = true;
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
        uiGameover.SetActive(false);
        uiMainMenu.SetActive(false);
        uiHelp.SetActive(false);
    }

    public void SetState(UIState state)
    {
        switch (state)
        {
            case UIState.Gameplay:
                HideAll();
                _gameOverHandled = false;
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

            case UIState.GameOver:
                if (_gameOverHandled) break;
                _gameOverHandled = true;

                HideAll();
                uiGameover.SetActive(true);
                Time.timeScale = 1f;
                isPlay = false;
                _playerPos.position += Vector3.down * 3;

                float runScore = _scoreDistanceSystem.distance;
                float previousBest = PlayerPrefs.GetFloat("highscore", 0f);
                PlayerPrefs.SetFloat("highscore", Mathf.Max(previousBest, runScore));
                PlayerPrefs.Save();
                ReportScore(Mathf.RoundToInt(runScore));
                break;

            case UIState.MainMenu:
                HideAll();
                isPlay = false;
                uiMainMenu.SetActive(true);
                Time.timeScale = 1f;
                break;

            case UIState.Help:
                HideAll();
                uiHelp.SetActive(true);
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

    public void playGame()
    {
        SetStateInt(0);
    }
}
