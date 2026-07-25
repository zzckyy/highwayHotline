using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class targetedDistance : MonoBehaviour
{
    public scoreDistanceSystem _scoreDistanceSystem;
    AudioSource winSound;

    [Header("Distance Target")]
    public float targetDistance;
    public TMP_Text targetDistanceUI;

    public gameSettings _gs;
    public economySystem _ekonomi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_gs.isEndless == false)
        {
            targetDistanceUI.text = Mathf.RoundToInt(targetDistance).ToString();
            if (_scoreDistanceSystem.distance >= targetDistance && _gs.isPlay)
            {
                _gs.SetState(gameSettings.UIState.Win);
            }

        }
    }
}
