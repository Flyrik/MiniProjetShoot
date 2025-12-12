using UnityEngine;
using System.Collections;
public class Target : MonoBehaviour
{
    public GameObject particleEffectPrefab;  // Prefab de l'effet de particules (explosion, fum�e, etc.)
    public float destroyDelay = 0.2f;        // D�lai avant de d�truire la cible (en secondes)
    public AudioSource explosionSound;     // Son d'explosion
    void OnCollisionEnter(Collision collision)
    {
        // V�rifier si l'objet entrant est une balle
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // D�clencher l'effet de particules � l'endroit o� la cible a �t� touch�e
            //Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            FXManager.Instance.SpawnFX("Explosion", transform.position, Quaternion.identity);


            // Jouer le son d'explosion
            if (explosionSound != null)
            {
                explosionSound.Play();
                explosionSound.volume = 3f;
            }
            GameplayManager.Instance.AddScore(10); 
                 

            
            StartCoroutine(DeactivateAfterDelay(0.1f));
        }
    }
    
IEnumerator DeactivateAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    gameObject.SetActive(false);
}

void OnDisable()
    {
        // IMPORTANT : informer le GameplayManager qu'une cible disparaît
        if (GameplayManager.Instance != null)
            GameplayManager.Instance.RegisterTargetDespawn();
    }
}
