using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MaterialLoader : MonoBehaviour
{
    public Renderer targetRenderer; // <- tu glisses le MeshRenderer du sol ici

    private string materialKey;

    private void Start()
    {
        // Détermine automatiquement quel material charger
        materialKey = PlatformHelper.IsQuest() ? "FX_Quest/herbe" : "FX_PCVR/herbe";

        LoadMaterial();
    }

    private void LoadMaterial()
    {
        Addressables.LoadAssetAsync<Material>(materialKey).Completed += (AsyncOperationHandle<Material> handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                targetRenderer.material = handle.Result; // applique le bon matériau
                Debug.Log("✔ Material chargé : " + materialKey);
            }
            else
            {
                Debug.LogError("❌ Material introuvable : " + materialKey);
            }
        };
    }
}
