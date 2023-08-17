using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;
    [SerializeField] private int health = 50;
    [SerializeField] private int _score = 50;
    
    private CameraShake cameraShake;
    private const float ShakeDuration = 0.2f;
    private const float ShakeMagnitude = 0.1f;
    
    private AudioPlayer _audioPlayer;
    private ScoreKeeper _scoreKeeper;
    private LevelManager _levelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            _audioPlayer.PlayDamageClip();
            cameraShake.ShakeCamera(ShakeDuration, ShakeMagnitude);
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isPlayer)
        {
            _levelManager.LoadGameOver();
        }
        else
        {
            _scoreKeeper.ChangeScore(_score);
        }
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
}
