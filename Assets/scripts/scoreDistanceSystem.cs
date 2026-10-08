using UnityEngine;
using TMPro;

public class scoreDistanceSystem : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text distanceText;
    public TMP_Text highScoreDistances;

    [Header("Settings")]
    public carBehavior _player;
    public gameSettings _gs;
    public float distance = 0f;

    [HideInInspector]
    public float highScoreDistances_Var;

    void Start()
    {

    }

    void Update()
    {
        float highscore_prefs = PlayerPrefs.GetFloat("highscore", 0);
        highScoreDistances.text = Mathf.RoundToInt(highscore_prefs).ToString() + " M";
        if (!_gs.isPlay) return;

        distance += Time.deltaTime * _player.speed;

        UpdateUI();

        if (distance >= highScoreDistances_Var)
        {
            highScoreDistances_Var = distance;

        }


    }

    void UpdateUI()
    {

        if (distanceText != null)
        {
            distanceText.text = Mathf.RoundToInt(distance).ToString() + " M";
        }


        
    }

}
