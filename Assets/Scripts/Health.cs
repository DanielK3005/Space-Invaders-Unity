using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeMagnitude = 0.1f;
    
    private AudioPlayer _audioPlayer;

    private void Awake()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }

        if (_audioPlayer != null)
        {
            _audioPlayer.PlayDamageClip();
        }
        
        // Trigger camera shake when taking damage - will apply on player 
        if (cameraShake != null)
        {
            cameraShake.ShakeCamera(shakeDuration, shakeMagnitude);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
