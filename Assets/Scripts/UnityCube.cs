using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCube : MonoBehaviour
{
    public List<AudioClip> playlist;
    private AudioSource _audiosource;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
        _audiosource.clip = playlist[Random.Range(0, playlist.Count)];
    }

    private void Start()
    {
        _audiosource.Play();
    }

    void FixedUpdate()
    {
        transform.Rotate(0.2f, -0.2f, -0.2f);
        if(_audiosource.isPlaying)
        {
            return;
        }
        else
        {
            _audiosource.clip = playlist[Random.Range(0, playlist.Count)];
            _audiosource.Play();
        }
    }
}
