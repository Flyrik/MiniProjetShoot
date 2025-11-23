using UnityEngine;

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
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

            // Jouer le son d'explosion
            if (explosionSound != null)
            {
                explosionSound.Play();
            }


            // D�truire la cible avec un d�lai pour permettre aux particules de se jouer
            Destroy(gameObject, destroyDelay);
        }
    }
}
