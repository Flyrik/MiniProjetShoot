using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Pr�fabriqu� de la cible
    public float spawnInterval = 8f; // Temps entre les apparitions de cibles
    public float spawnRange = 10f; // Plage de spawn al�atoire

    private void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        // G�n�rer une position al�atoire pour la cible
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            3f, // Hauteur de spawn
            Random.Range(-spawnRange,8)
        );

        Instantiate(targetPrefab, spawnPosition,Quaternion.Euler(0f, 90f, 0f));
    }
}