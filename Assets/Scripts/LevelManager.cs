using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper _scoreKeeper;
    [SerializeField] TMP_InputField playerName;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        _scoreKeeper.ResetScore();
        if(playerName != null)
        {
        _scoreKeeper.SetName(playerName.text);
        }
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        // Use DoTween to delay scene loading
        DOTween.Sequence()
            .AppendInterval(sceneLoadDelay)
            .OnComplete(() => SceneManager.LoadScene("GameOver"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}