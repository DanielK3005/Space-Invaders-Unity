using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper _scoreKeeper;

    void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        _scoreKeeper.ResetScore();
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