using UnityEngine;

public class carBehavior : MonoBehaviour
{
    public int health = 1;
    public int maxHealth = 1;

    public gameSettings gameSettings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = (health >= maxHealth) ? health = maxHealth : health;

        // Debug.Log("health: " + health + "max health: " + maxHealth);

        if(health <= 0)
        {
            gameSettings.SetState(gameSettings.UIState.GameOver);
        }
    }
}
