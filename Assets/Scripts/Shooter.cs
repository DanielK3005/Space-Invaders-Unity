using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;
    
    [Header("AI")]
    [SerializeField] private bool useAI;
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;
    private Sequence _firingSequence;

    private void Start()
    {
        if (useAI)  //the shooter is a enemy made in EnemySpawner
        {
            isFiring = true;
            baseFiringRate = Mathf.Max(baseFiringRate - firingRateVariance, minimumFiringRate);
        }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && _firingSequence == null)
        {
            float firingRate = useAI ? baseFiringRate + Random.Range(-firingRateVariance, firingRateVariance) : baseFiringRate;
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
        Vector3 shootingDirection = useAI ? -transform.up : transform.up; 
        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootingDirection * projectileSpeed;
        }
        Destroy(instance, projectileLifeTime);
    }
    
    private void OnDestroy()
    {
        if (_firingSequence != null)
        {
            _firingSequence.Kill();
            _firingSequence = null;
        }
    }
}
