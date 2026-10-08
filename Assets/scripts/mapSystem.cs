using UnityEngine;

public class mapSystem : MonoBehaviour
{
    public SpriteRenderer road;
    public Sprite[] Maps;
    private int currentIndex = 0;

    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("mapState", 0);

        if (Maps.Length > 0 && road != null && currentIndex < Maps.Length)
        {
            road.sprite = Maps[currentIndex];
        }
    }

    public void NextMap()
    {
        currentIndex++;
        
        // Looping ke awal jika sudah lewat dari batas maksimal
        if (currentIndex >= Maps.Length)
        {
            currentIndex = 0;
        }

        if (Maps.Length > 0 && road != null)
        {
            PlayerPrefs.SetInt("mapState", currentIndex);
            PlayerPrefs.Save(); 
            road.sprite = Maps[currentIndex];
        }
    }
}