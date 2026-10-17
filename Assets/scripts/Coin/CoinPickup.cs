using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class CoinPickup : MonoBehaviour
{
    public int value = 1;
    public float speed = 8f;
    public float despawnY = -8f;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        if (transform.position.y < despawnY) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        CoinSystem.Instance.AddCoins(value);
        Destroy(gameObject);
    }
}
