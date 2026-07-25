using UnityEngine;
using TMPro;

public class scoreDistanceSystem : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text distanceText;

    [Header("Settings")]
    public carBehavior _player;
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

        distance += Time.deltaTime * _player.speed;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (distanceText != null)
        {
            distanceText.text = Mathf.RoundToInt(distance).ToString() + " M";
        }
    }
}
