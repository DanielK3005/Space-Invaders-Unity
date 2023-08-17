using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    private int _score;
    
    private void Awake()
    {
        // Ensure that only one instance of the ScoreKeeper exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameObject with the ScoreKeeper alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy any additional instances that may have been created
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void ChangeScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _score = Mathf.Clamp(_score, 0, int.MaxValue); 
    }

    public void ResetScore()
    {
        _score = 0;
    }
}