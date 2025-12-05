using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GunLoader : MonoBehaviour
{
    public Transform spawnPoint; // où le gun va apparaître
    private GameObject currentGun;

    void Start()
    {
        string key = PlatformHelper.IsQuest() ? "FX_Quest/Gun" : "FX_PCVR/Gun";
        Debug.Log("Chargement du gun : " + key);

        Addressables.InstantiateAsync(key, spawnPoint.position, spawnPoint.rotation).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                currentGun = handle.Result;
                currentGun.transform.SetParent(spawnPoint); // optionnel : parenté au spawn
                Debug.Log("Gun instancié avec succès !");
            }
            else
            {
                Debug.LogError("Gun Addressable introuvable : " + key);
            }
        };
    }
}
