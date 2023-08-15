using UnityEngine;
using DG.Tweening;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float firingRate = 0.2f;

    public bool isFiring;
    private Sequence _firingSequence;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && _firingSequence == null)
        {
            _firingSequence = DOTween.Sequence()
                .AppendCallback(FireProjectile) // Fire the first projectile immediately
                .AppendInterval(firingRate) // Initial delay
                .AppendCallback(FireProjectile) // Fire projectiles at intervals
                .AppendInterval(firingRate) // Delay between shots
                .SetLoops(-1); // Loop indefinitely
        }
        else if (!isFiring && _firingSequence != null)
        {
            _firingSequence.Kill();
            _firingSequence = null;
        }
    }

    private void FireProjectile()
    {
        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * projectileSpeed;
        }
        Destroy(instance, projectileLifeTime);
    }
}
