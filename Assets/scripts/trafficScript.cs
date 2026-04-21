using UnityEngine;

public class trafficScript : MonoBehaviour
{
    Transform transform;

    public float moveSpeed = 17.0f;
    private carBehavior player;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<carBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y  - moveSpeed * Time.deltaTime, transform.position.z), moveSpeed * Time.deltaTime);
        transform.position = targetPosition;
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.health -= 1;
            
        }
        else if(other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
