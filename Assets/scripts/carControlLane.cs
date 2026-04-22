using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControlLane : MonoBehaviour
{

    // public float laneDistance = 2.0f;
    public float moveSpeed = 5.0f;
    public float laneChangeSpeed = 10.0f;

    bool isMoving = false;
    int currentLane = 1;
    public float[] lanePositions = new float[2];

    public Animator _animator;

    bool isIntro;
    
    // {-2.0f, 0.0f, 2.0f};

    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        isIntro = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isIntro) return;

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(-1);
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(1);
        }

        Vector3 targetPosition = new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime * laneChangeSpeed);

        
    }

    void MoveLane(int direction)
    {
        if(isMoving) return;

        int targetLane = currentLane + direction;
        if(targetLane >= 0 && targetLane < lanePositions.Length)
        {
            currentLane = targetLane;
        }

        // Debug.Log("Current Lane: " + currentLane + "direction: " + direction);
    }

    public void MoveLeft()
    {
        MoveLane(-1);
    }

    public void MoveRight()
    {
        MoveLane(1);
    }

    public void end_intro()
    {
        _animator.enabled = false;
        isIntro = false;
    }
}
