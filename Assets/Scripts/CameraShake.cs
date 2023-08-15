using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform _cameraTransform;
    private Vector3 _originalPosition;
    private float _shakeDuration;
    private float _shakeMagnitude;
    private const float DampingSpeed = 1.0f;

    private void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _originalPosition = _cameraTransform.localPosition;
    }

    private void Update()
    {
        if (_shakeDuration > 0)
        {
            _cameraTransform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeMagnitude;
            _shakeDuration -= Time.deltaTime * DampingSpeed;
        }
        else
        {
            _shakeDuration = 0f;
            _cameraTransform.localPosition = _originalPosition;
        }
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        _shakeDuration = duration;
        _shakeMagnitude = magnitude;
    }
}