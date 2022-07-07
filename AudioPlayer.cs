using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource, _effectsSource;

    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    [Header("Music")]
    [SerializeField] AudioClip musicClip;
    [SerializeField] [Range(0f, 1f)] float musicVolume = 1f;

    public static AudioPlayer instance;
    //public bool toggleMusic;

    void Awake()
    {
        ManageSingleton();
    }

    public void ToggleEffects() {
        _effectsSource.mute = !_effectsSource.mute;
    }

    public void ToggleMusic(bool muted) {
        _musicSource.mute = muted;
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusicClip()
    {
        PlayClip(_musicSource, musicClip, musicVolume);
    }

    public void PlayShootingClip()
    {
        PlayClip(_effectsSource, shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(_effectsSource, damageClip, damageVolume);
    }

    void PlayClip(AudioSource audioSource, AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
