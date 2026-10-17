using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float[] lanePositions = { -2f, 2f };
    public float spawnY = 8f;
    public float spawnInterval = 2f;
    public gameSettings gameState;

    private void Start()
    {
        if (gameState == null) gameState = FindObjectOfType<gameSettings>();
        InvokeRepeating(nameof(SpawnCoin), 2f, spawnInterval);
    }

    private void SpawnCoin()
    {
        if (!gameState.isPlay) return;
        int laneIndex = Random.Range(0, lanePositions.Length);
        Instantiate(coinPrefab, new Vector3(lanePositions[laneIndex], spawnY, 0f), Quaternion.identity);
        Debug.Log("Coin Muncul");
    }
}
