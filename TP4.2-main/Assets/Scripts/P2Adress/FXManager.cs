using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

public class FXManager : MonoBehaviour
{
    public static FXManager Instance;

    private string fxGroupPrefix;
    private Dictionary<string, GameObject> loadedFX = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        fxGroupPrefix = PlatformHelper.IsQuest() ? "FX_Quest/" : "FX_PCVR/";
    }

    // Charger un FX par son nom
    public void SpawnFX(string fxName, Vector3 position, Quaternion rotation)
    {
        string key = fxGroupPrefix + fxName;

        if (loadedFX.ContainsKey(key))
        {
            Instantiate(loadedFX[key], position, rotation);
        }
        else
        {
            Addressables.LoadAssetAsync<GameObject>(key).Completed += (AsyncOperationHandle<GameObject> handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject fxPrefab = handle.Result;
                    loadedFX[key] = fxPrefab;
                    Instantiate(fxPrefab, position, rotation);
                }
                else
                {
                    Debug.LogError("FX non trouvé : " + key);
                }
            };
        }
    }

    // Décharger un FX si plus nécessaire
    public void UnloadFX(string fxName)
    {
        string key = fxGroupPrefix + fxName;
        if (loadedFX.ContainsKey(key))
        {
            Addressables.Release(loadedFX[key]);
            loadedFX.Remove(key);
        }
    }

    // Décharger tous les FX
    public void UnloadAllFX()
    {
        foreach (var fx in loadedFX.Values)
        {
            Addressables.Release(fx);
        }
        loadedFX.Clear();
    }
}
