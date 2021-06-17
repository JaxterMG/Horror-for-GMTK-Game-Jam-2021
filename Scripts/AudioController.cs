using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource _audiosource;
    [SerializeField] AudioClip[] _footstepsAudio;
    [SerializeField] float _waitTime;
    float timer;

    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        timer = _waitTime;
    }

    public void PlayFootsteps()
    {
       // timer -= Time.deltaTime;
      //  if (timer <= 0)
      // {
            _audiosource.PlayOneShot(_footstepsAudio[Random.Range(0, _footstepsAudio.Length - 1)]);
            timer = _waitTime;
     //   }
    }
}

