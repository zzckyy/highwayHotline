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
    [Header("Game Object Link")]

    public Animator _animator;

    bool isIntro;

    scoreDistanceSystem _scoreDistanceSystem;

    public gameSettings _gs;
    
    // {-2.0f, 0.0f, 2.0f};

    Transform _tf;

    void Start()
    {
        _tf = GetComponent<Transform>();
        isIntro = true;
        _scoreDistanceSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<scoreDistanceSystem>();
        
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            _gs.SetState(gameSettings.UIState.Gameplay);
        }

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
        }
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
