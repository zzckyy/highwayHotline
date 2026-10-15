using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControlLane : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed = 5.0f;
    public float laneChangeSpeed = 10.0f;
    int currentLane = 1;
    [Header("Lane")]
    public float[] lanePositions = new float[2];
    [Header("Lane Change Feel")]
    [Range(0f, 0.2f)] public float laneBounceAmount = 0.08f;
    [Min(0.01f)] public float laneBounceDuration = 0.22f;

    scoreDistanceSystem _scoreDistanceSystem;

    public gameSettings _gs;
    
    // {-2.0f, 0.0f, 2.0f};

    Transform _tf;
    Vector3 _baseScale;
    Coroutine _bounceRoutine;

    void Start()
    {
        _tf = GetComponent<Transform>();
        _baseScale = _tf.localScale;
        _scoreDistanceSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<scoreDistanceSystem>();
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(-1);
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(1);
        }


        Vector3 targetPosition = new Vector3(lanePositions[currentLane], _tf.position.y, _tf.position.z);
        _tf.position = Vector3.Lerp(_tf.position, targetPosition, moveSpeed * Time.deltaTime * laneChangeSpeed);

        
    }

    void MoveLane(int direction)
    {
        if(_scoreDistanceSystem._gs.isPlay == false) return;

        int targetLane = currentLane + direction;
        if(targetLane >= 0 && targetLane < lanePositions.Length)
        {
            currentLane = targetLane;
            if (_bounceRoutine != null)
            {
                StopCoroutine(_bounceRoutine);
            }
            _bounceRoutine = StartCoroutine(BounceOnLaneChange());
        }
    }

    System.Collections.IEnumerator BounceOnLaneChange()
    {
        float elapsed = 0f;
        while (elapsed < laneBounceDuration)
        {
            float progress = elapsed / laneBounceDuration;
            float bounce = Mathf.Sin(progress * Mathf.PI * 2f) * (1f - progress) * laneBounceAmount;
            _tf.localScale = new Vector3(
                _baseScale.x * (1f - bounce * 0.65f),
                _baseScale.y * (1f + bounce),
                _baseScale.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _tf.localScale = _baseScale;
        _bounceRoutine = null;
    }

    public void MoveLeft()
    {
        MoveLane(-1);
    }

    public void MoveRight()
    {
        MoveLane(1);
    }
}
