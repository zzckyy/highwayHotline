using UnityEngine;

public class trafficScript : MonoBehaviour
{
    Transform transform;

    public float moveSpeed = 17.0f;
    public GameObject ledakan;
    private carBehavior player;
    private camShake cam;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<carBehavior>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camShake>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(ledakan, transform.position, Quaternion.identity);
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
