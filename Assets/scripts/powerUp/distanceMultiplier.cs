using UnityEngine;
using UnityEngine.Audio;

public class distanceMultiplier : MonoBehaviour
{
    private carBehavior _player;
    private SpriteRenderer _render;
    private AudioSource _sfx;

    public float multiplierValue;
    public float timerDuration;
    private float speedUp;
    private float currentTimer;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<carBehavior>();
        speedUp = _player.speed * multiplierValue;
        _render = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _render.sprite = null;
            currentTimer += 1 * Time.deltaTime;
            _sfx.Play();

            if (currentTimer >= timerDuration)
            {
                _player.speed = _player.speed;
                Destroy(gameObject);
            }

            else
            {
                _player.speed = speedUp;
            }
        }
    }
}
