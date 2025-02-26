using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    private AudioSource bgmAudioSource;

    public AudioClip bgmClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();
        if (bgmAudioSource == null)
        {
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        bgmAudioSource.clip = bgmClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.playOnAwake = false;
        bgmAudioSource.volume = 0.5f; 

        if (!bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Play();
        }
    }
}
