using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class carBehavior : MonoBehaviour
{
    public Sprite[] CarSprite;
    public int health;
    public float speed;

    SpriteRenderer _playerCar;

    void Start()
    {
        _playerCar = GetComponent<SpriteRenderer>();
        stateCarCarousell = Mathf.Clamp(PlayerPrefs.GetInt("CarClass", 0), 0, 2);
        carClassType = (CarClass)stateCarCarousell;
        InitStats(carClassType);
        carImage.sprite = CarSprite[stateCarCarousell];
    }
    public enum CarClass
    {
        Ambulance, Police, Damkar
    }

    public gameSettings _gs;
    public CarClass carClassType;

    private int stateCarCarousell;
    public Image carImage;


    public void InitStats(CarClass type)
    {
        switch (type)
        {
            case CarClass.Ambulance:
                health = 2;
                speed = 9f;
                _playerCar.sprite = CarSprite[0];
                break;

            case CarClass.Police:
                health = 1;
                speed = 12f;
                _playerCar.sprite = CarSprite[1];
                break;

            case CarClass.Damkar:
                health = 3;
                speed = 6f;
                _playerCar.sprite = CarSprite[2];
                break;
        }
    }

    public void Update()
    {
        if (health <= 0)
        {
            _gs.SetState(gameSettings.UIState.GameOver);
        }
    }

    public void SetCarCarousell(bool Forward)
    {
        if (Forward)
        {
            stateCarCarousell++;
        }

        else
        {
            stateCarCarousell--;
        }

        if(stateCarCarousell > 2)
        {
            stateCarCarousell = 0;
        }

        else if(stateCarCarousell < 0)
        {
            stateCarCarousell = 2;
        }

        carImage.sprite = CarSprite[stateCarCarousell];
        PlayerPrefs.SetInt("CarClass", stateCarCarousell);

        int carState;
        carClassType = (CarClass)PlayerPrefs.GetInt("CarClass", 0);
        InitStats(carClassType);
    }
}
