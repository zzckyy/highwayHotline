using UnityEngine;

public class trafficScript : MonoBehaviour
{
    Transform _transform;

    private float moveSpeed;
    public GameObject ledakan;
    private carBehavior player;
    private camShake cam;

    public enum trafficCarType
    {
        lightCar, heavyCar
    }

    public trafficCarType carType;

    public void InitStats(trafficCarType type)
    {
        switch (type)
        {
            case trafficCarType.lightCar:
                moveSpeed = 12f;
                break;

            case trafficCarType.heavyCar:
                moveSpeed = 8f;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<carBehavior>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShake>();
        InitStats(carType);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _transform.Translate(Vector3.down * moveSpeed * Time.fixedDeltaTime);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(ledakan, _transform.position, Quaternion.identity);
            cam.Shake(0.3f, 0.2f);
            player.health -= 1;
            Destroy(gameObject);
            
        }
        else if(other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
