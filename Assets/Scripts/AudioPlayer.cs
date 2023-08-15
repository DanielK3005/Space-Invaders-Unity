using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    [SerializeField] private AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] private float shootingVolume;
    
    [Header("Damage")] 
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip,shootingVolume);
    }
    
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    private void PlayClip(AudioClip clip,float volume)
    {
        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
