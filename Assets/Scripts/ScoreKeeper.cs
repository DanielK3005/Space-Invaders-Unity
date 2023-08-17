using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    private SaveSystem _saveSystem;
    private int[] _bestScores = new int[3];
    private int _score;
    
    private void Awake()
    {
        // Ensure that only one instance of the ScoreKeeper exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }

        _saveSystem = GetComponent<SaveSystem>(); 
        LoadBestScores(); // Load best scores from save
    }
    
    // Save the best scores to the save system
    private void SaveBestScores()
    {
        _saveSystem.SaveBestScores(_bestScores);
    }

    // Load the best scores from the save system
    public void LoadBestScores()
    {
        _bestScores = _saveSystem.LoadBestScores();
    }
    
    public int[] GetBestScores()
    {
        return _bestScores;
    }

    // Update the best scores with the current score
    public void UpdateBestScores()
    {
        for (int i = 0; i < _bestScores.Length; i++)
        {
            if (_score > _bestScores[i])
            {
                for (int j = _bestScores.Length - 1; j > i; j--)
                {
                    _bestScores[j] = _bestScores[j - 1];
                }
                _bestScores[i] = _score;
                break;
            }
        }

        SaveBestScores(); // Save the updated best scores
    }

    public int GetScore()
    {
        return _score;
    }
    
    public void ChangeScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _score = Mathf.Clamp(_score, 0, int.MaxValue); // Ensure score doesn't go below 0
    }
    public void ResetScore()
    {
        _score = 0;
    }
}