using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;  // Singleton
    public GameObject bulletPrefab;
    public int poolSize = 30;

    private List<GameObject> bulletPool = new List<GameObject>();

    void Awake()
    {
        Instance = this;  

        // Génération du pool au lancement
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
    }

    public GameObject GetBulletFromPool()
    {
        // Cherche une balle inactive disponible
        foreach(GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }

        // Si aucune balle dispo → création d'une nouvelle
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        bulletPool.Add(newBullet);
        return newBullet;
    }
}
