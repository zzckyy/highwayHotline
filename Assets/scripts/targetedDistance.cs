using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class targetedDistance : MonoBehaviour
{
    scoreDistanceSystem _scoreDistanceSystem;
    public economySystem _ekonomi;
    public GameObject winPanel;
    AudioSource winSound;

    [Header("Distance Target")]
    public Slider targerDistanceSlider;
    public float targetDistance;
    public Text targetDistanceUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         _scoreDistanceSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<scoreDistanceSystem>();
         winSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDistance = targerDistanceSlider.value;

        targetDistanceUI.text = Mathf.RoundToInt(targetDistance).ToString();
        if(_scoreDistanceSystem.distance >= targetDistance)
        {
            gameMenang();
        }
    }

    public void gameMenang()
    {
        _scoreDistanceSystem.StopGame();

        winPanel.SetActive(true);
        winSound.Play();

        _ekonomi.Point += Mathf.FloorToInt(targetDistance);
    }
}
