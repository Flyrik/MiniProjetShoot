using UnityEngine;
using System.Collections;

public class AutoDisableFX : MonoBehaviour
{
    public float lifetime = 1f; // Durée de vie du FX avant désactivation

    void OnEnable()
    {
        StartCoroutine(DisableAfterDelay());
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false); // Désactivation automatique
    }
}
