using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> playlist;
    private AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = playlist[Random.Range(0, playlist.Count)];
    }

    private void Start()
    {
        audiosource.Play();
    }

    void Update()
    {
        if (audiosource.isPlaying)
        {
            return;
        }
        else
        {
            audiosource.clip = playlist[Random.Range(0, playlist.Count)];
            audiosource.Play();
        }
    }
}


