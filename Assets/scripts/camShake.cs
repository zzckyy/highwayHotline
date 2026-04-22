using UnityEngine;
using System.Collections;

public class camShake : MonoBehaviour
{
    Vector3 originalPos;
    Coroutine currentShake;

    void Awake()
    {
        originalPos = transform.localPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        if (currentShake != null)
            StopCoroutine(currentShake);

        currentShake = StartCoroutine(DoShake(duration, magnitude));
    }

    IEnumerator DoShake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float damper = 1f - (elapsed / duration);

            float x = Random.Range(-1f, 1f) * magnitude * damper;
            float y = Random.Range(-1f, 1f) * magnitude * damper;

            transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime * 2f; // 🔥 ini bikin geter cepet (important!)
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
