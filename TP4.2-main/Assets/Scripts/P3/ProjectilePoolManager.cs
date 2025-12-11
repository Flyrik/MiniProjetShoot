using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{
    public static ProjectilePoolManager Instance;

    public List<GameObject> activeProjectiles = new List<GameObject>();
    public float maxDistance = 40f;

    private Transform referencePoint;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        referencePoint = Camera.main.transform;

        StartCoroutine(CleanupRoutine());
    }

    public void RegisterProjectile(GameObject projectile)
    {
        activeProjectiles.Add(projectile);
    }

    public void UnregisterProjectile(GameObject projectile)
    {
        activeProjectiles.Remove(projectile);
    }

    IEnumerator CleanupRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            for (int i = activeProjectiles.Count - 1; i >= 0; i--)
            {
                GameObject proj = activeProjectiles[i];

                if (!proj.activeSelf)
                {
                    activeProjectiles.RemoveAt(i);
                    continue;
                }

                float dist = Vector3.Distance(referencePoint.position, proj.transform.position);

                if (dist > maxDistance)
                {
                    proj.SetActive(false);
                    activeProjectiles.RemoveAt(i);
                }
            }
        }
    }
}
