using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public int currentScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        currentScore += points;
    }
    public int GetScore()
    {
        return currentScore;
    }
}
