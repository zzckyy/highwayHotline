using UnityEngine;
using TMPro;

public class scoreDistanceSystem : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text distanceText;

    [Header("Settings")]
    public float distanceMultiplier = 1f; // biar bisa tuning
    public int scorePerMeter = 10;

    float distance = 0f;
    int score = 0;

    int highScore;

    [HideInInspector]
    public bool isPlaying = false;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        if (!isPlaying) return;

        // distance naik terus (endless runner style)
        distance += Time.deltaTime * distanceMultiplier;

        // score dari distance
        score = Mathf.FloorToInt(distance * scorePerMeter);
        

        highScore = (score > highScore) ? score : highScore;
        PlayerPrefs.SetInt("Highscore", highScore);


        UpdateUI();

    }

    void UpdateUI()
    {
        distanceText.text = distance.ToString("F1") + " m";
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        isPlaying = true;
    }

    public void StopGame()
    {
        isPlaying = false;
    }

    // BONUS SYSTEM (optional)
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }
}
