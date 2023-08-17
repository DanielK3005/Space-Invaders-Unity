using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // An array of TextMeshProUGUI components where you want to display the best scores
    [SerializeField] TextMeshProUGUI[] bestScoresText;
    ScoreKeeper _scoreKeeper;
    
    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = _scoreKeeper.GetScore().ToString();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Retrieve the best scores from the ScoreKeeper class
        int[] bestScores = _scoreKeeper.GetBestScores();
        var bestScoresLength = bestScores.Length;
        for (int i = 0; i < bestScoresLength; i++)
        {
            if (i < bestScoresText.Length)
            {
                bestScoresText[i].text = bestScores[i].ToString();
            }
        }
    }


}