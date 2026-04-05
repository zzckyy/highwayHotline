using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float speed = 5f;

    float mobileInput = 0f;
    float inputCar = 0f;

    Transform _pos;
    // Start is called before the first frame update
    void Start()
    {
        _pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float KeyboardInput = Input.GetAxis("Horizontal");
        float crossPlatformInput = KeyboardInput + mobileInput;
        inputCar = Mathf.Lerp(inputCar, crossPlatformInput, Time.deltaTime * 7);


        float finalInput = Mathf.Clamp(inputCar, -1, 1);

        _pos.Translate(Vector3.right * finalInput * speed * Time.deltaTime);

        Debug.Log("Input: " + crossPlatformInput);
    }

    public void MobileInputLeft()
    {
        mobileInput = -1f;
    }

    public void MobileInputRight()
    {
        mobileInput = 1f;
    }

    public void MobileInputIdle()
    {
        mobileInput = 0f;
    }
}
