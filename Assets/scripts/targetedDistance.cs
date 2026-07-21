using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class targetedDistance : MonoBehaviour
{
    scoreDistanceSystem _scoreDistanceSystem;
    AudioSource winSound;

    [Header("Distance Target")]
    public Slider targetDistanceSlider;
    public float targetDistance;
    public TMP_Text targetDistanceUI;

    public gameSettings _gs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         _scoreDistanceSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<scoreDistanceSystem>();
         winSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDistance = targetDistanceSlider.value;

        targetDistanceUI.text = Mathf.RoundToInt(targetDistance).ToString();
        if(_scoreDistanceSystem.distance >= targetDistance)
        {
            _gs.SetState(gameSettings.UIState.Win);
        }
    }
}
