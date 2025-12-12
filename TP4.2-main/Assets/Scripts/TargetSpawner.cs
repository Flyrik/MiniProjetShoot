using UnityEngine;
using System.Collections;
public class TargetSpawner : MonoBehaviour
{
    public float spawnInterval = 3f;
    public float spawnRange = 10f;
    public Vector3 fixedSpawnPosition = Vector3.zero; // option pour spawn fixe
    public bool useRandomPosition = true;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    void SpawnTarget()
    {
        GameObject target = TargetPoolManager.Instance.GetTargetFromPool();

        // Remise à zéro de l'état de la cible
        ResetTarget(target);

        // Position
        if (useRandomPosition)
        {
            target.transform.position = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                3f,
                Random.Range(-spawnRange, 8f)
            );
        }
        else
        {
            target.transform.position = fixedSpawnPosition;
        }

        // Orientation
        target.transform.rotation = Quaternion.Euler(0f, 90f, 0f);

        // Activer la cible
        target.SetActive(true);
        GameplayManager.Instance.RegisterTargetSpawn();
        
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Vérifie si on peut spawn une cible
            if (GameplayManager.Instance.currentTargets < GameplayManager.Instance.maxTargets)
            {
                SpawnTarget();
            }
        }
    }

    void ResetTarget(GameObject target)
    {
        // Remettre les animations, matériaux, collisions...
        target.SetActive(false); // on désactive temporairement pour reset
        target.SetActive(true);

        // Ex : remettre Rigidbody à zéro si utilisé
        Rigidbody rb = target.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }   

        // Ex : réinitialiser Animator
        Animator anim = target.GetComponent<Animator>();
        if (anim != null)
        {
            anim.Rebind();
            anim.Update(0f);
        }

        // Ex : réinitialiser matériau ou couleur
        Renderer rend = target.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.white; // par défaut
        }

        // Collider actif
        Collider col = target.GetComponent<Collider>();
        if (col != null)
            col.enabled = true;
    }
}
