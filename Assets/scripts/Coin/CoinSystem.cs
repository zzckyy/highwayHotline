using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance { get; private set; }

    public TMP_Text balanceText;
    public int Balance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Balance = PlayerPrefs.GetInt("CoinBalance", 0);
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        Balance += amount;
        Save();
    }

    public bool SpendCoins(int amount)
    {
        if (amount > Balance) return false;

        Balance -= amount;
        Save();
        return true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("CoinBalance", Balance);
        PlayerPrefs.Save();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (balanceText != null) balanceText.text = Balance.ToString();
    }
}
