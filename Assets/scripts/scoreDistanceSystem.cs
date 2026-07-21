using UnityEngine;
using TMPro;

public class scoreDistanceSystem : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text distanceText;

    [Header("Settings")]
    public float distanceMultiplier = 1f;
    public targetedDistance _targetedDistance;
    public gameSettings _gs;

    int score = 0;
    public float distance = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!_gs.isPlay) return;

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
        _gs.isPlay = true;
    }

    public void StopGame()
    {
        _gs.isPlay = false;
    }

    // BONUS SYSTEM (optional)
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }
}
