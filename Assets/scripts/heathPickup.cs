using UnityEngine;

public class heathPickup : MonoBehaviour
{
    public float heathAmount;
    public carController car;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collider other)
    {
        if(other.tag == "Player")
        {
            // car.
        }
    }
}
