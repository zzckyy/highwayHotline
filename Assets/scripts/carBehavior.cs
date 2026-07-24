using UnityEngine;
using System.Collections.Generic;

public class carBehavior : MonoBehaviour
{
    public Sprite[] CarSprite;
    public int health;
    public float speed;

    SpriteRenderer _playerCar;

    void Start()
    {
        _playerCar = GetComponent<SpriteRenderer>();
    }
    public enum CarClass
    {
        Ambulance, Police, Damkar
    }

    public gameSettings _gs;
    public CarClass carClassType;

    

    public void InitStats(CarClass type)
    {
        switch (type)
        {
            case CarClass.Ambulance:
                health = 2;
                speed = 1.5f;
                _playerCar.sprite = CarSprite[0];
                break;

            case CarClass.Police:
                health = 1;
                speed = 2f;
                _playerCar.sprite = CarSprite[1];
                break;

            case CarClass.Damkar:
                health = 3;
                speed = 1f;
                _playerCar.sprite = CarSprite[2];
                break;
        }
    }

    public void SetClassCar(int state)
    {
        carClassType = (CarClass)state;
        InitStats(carClassType);
    }

    public void Update()
    {
        if(health <= 0)
        {
            _gs.SetState(gameSettings.UIState.GameOver);
        }
    }
}
