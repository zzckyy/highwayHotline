using UnityEngine;
using TMPro;

public class scoreDistanceSystem : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text distanceText;

    [Header("Settings")]
    public float distanceMultiplier = 1f;

    int score = 0;

    [HideInInspector]
    public bool isPlaying = false;
    public float distance = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isPlaying) return;

        // distance naik terus (endless runner style)
        distance += Time.deltaTime * distanceMultiplier;

        UpdateUI();
    }

    void UpdateUI()
    {
        if(distanceText != null)
        {
        distanceText.text = Mathf.RoundToInt(distance).ToString() + " M";
        }
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
