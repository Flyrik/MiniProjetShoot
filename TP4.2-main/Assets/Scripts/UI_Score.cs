using UnityEngine;
using TMPro;
using System.Collections;

public class UI_Score : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        // Lance la coroutine au démarrage
        StartCoroutine(UpdateScoreRoutine());
    }

    private IEnumerator UpdateScoreRoutine()
    {
        while (true) // Boucle infinie
        {
            // Met à jour le texte du score toutes les 0.1 secondes
            scoreText.text = "Score: " + GameplayManager.Instance.GetScore().ToString();

            yield return new WaitForSeconds(0.1f); // rafraîchissement toutes les 0.1s
        }
    }
}
