using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> playlist;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource.loop = true;
        audioSource.clip = playlist[Random.Range(0, playlist.Count)];
    }

    private void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        else
        {
            audioSource.clip = playlist[Random.Range(0, playlist.Count)];
            audioSource.Play();
        }
    }
}


