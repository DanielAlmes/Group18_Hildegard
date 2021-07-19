using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource SoundEffectSource;
    public AudioSource BackgroundMusicSource;

    // Singleton Instance
    public static SoundManager Instance = null;
    
    // Initialize the singleton instance
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip audioClip)
    {
        SoundEffectSource.clip = audioClip;
        SoundEffectSource.Play();
    }

    public void PlayBackgroundMusic(AudioClip audioClip)
    {
        BackgroundMusicSource.clip = audioClip;
        BackgroundMusicSource.Play();
    }
    
}
