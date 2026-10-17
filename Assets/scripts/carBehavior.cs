using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class carBehavior : MonoBehaviour
{
    public Sprite[] CarSprite;
    public int health;
    public float speed;

    public int healthLevel;
    public int speedLevel;

    private const int MaxUpgradeLevel = 3;
    private const int UpgradeCostStep = 500;

    SpriteRenderer _playerCar;

    void Start()
    {
        _playerCar = GetComponent<SpriteRenderer>();
        healthLevel = PlayerPrefs.GetInt("HealthLevel", 0);
        speedLevel = PlayerPrefs.GetInt("SpeedLevel", 0);
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
                health = 2 + healthLevel;
                speed = 9f + speedLevel;
                _playerCar.sprite = CarSprite[0];
                break;

            case CarClass.Police:
                health = 1 + healthLevel;
                speed = 12f + speedLevel;
                _playerCar.sprite = CarSprite[1];
                break;

            case CarClass.Damkar:
                health = 3 + healthLevel;
                speed = 6f + speedLevel;
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

    public void UpgradeHealth()
    {
        if (healthLevel >= MaxUpgradeLevel) return;

        int cost = (healthLevel + 1) * UpgradeCostStep;
        if (CoinSystem.Instance == null || !CoinSystem.Instance.SpendCoins(cost)) return;

        healthLevel++;
        PlayerPrefs.SetInt("HealthLevel", healthLevel);
        PlayerPrefs.Save();
        InitStats(carClassType);
    }

    public void UpgradeSpeed()
    {
        if (speedLevel >= MaxUpgradeLevel) return;

        int cost = (speedLevel + 1) * UpgradeCostStep;
        if (CoinSystem.Instance == null || !CoinSystem.Instance.SpendCoins(cost)) return;

        speedLevel++;
        PlayerPrefs.SetInt("SpeedLevel", speedLevel);
        PlayerPrefs.Save();
        InitStats(carClassType);
    }
}
