using System.Collections.Generic;
using UnityEngine;

public class TargetPoolManager : MonoBehaviour
{
    public static TargetPoolManager Instance;

    public GameObject targetPrefab;
    public int poolSize = 10; // nombre de cibles pré-créées

    private List<GameObject> targetPool = new List<GameObject>();

    void Awake()
    {
        Instance = this;

        // Créer les cibles désactivées
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(targetPrefab);
            obj.SetActive(false);
            targetPool.Add(obj);
        }
    }

    // Récupérer une cible inactive
    public GameObject GetTargetFromPool()
    {
        foreach (GameObject target in targetPool)
        {
            if (!target.activeInHierarchy)
                return target;
        }

        // Si toutes les cibles sont utilisées, en créer une nouvelle
        GameObject newTarget = Instantiate(targetPrefab);
        newTarget.SetActive(false);
        targetPool.Add(newTarget);
        return newTarget;
    }
}
