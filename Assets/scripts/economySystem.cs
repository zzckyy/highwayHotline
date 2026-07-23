using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class economySystem : MonoBehaviour
{
    public int Point;

    public TMP_Text pointDisplay;

    // Update is called once per frame
    void Update()
    {
        pointDisplay.text = "Point: " + Point.ToString();
    }
}
