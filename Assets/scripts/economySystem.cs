using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class economySystem : MonoBehaviour
{
    public int Point;
    public int PointOnRun;

    public TMP_Text pointDisplay;

    // Update is called once per frame
    void Update()
    {
        Point = PlayerPrefs.GetInt("Point", 0);
        pointDisplay.text = "Point: " + Point;
    }
}
