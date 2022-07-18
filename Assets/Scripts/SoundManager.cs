using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource _source;
    [SerializeField] AudioClip[] _whisperSound;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _clip)
    {
        _source.PlayOneShot(_clip);
    }
    public void PlayWhisperSound()
    {

        _source.PlayOneShot(_whisperSound[Random.Range(0,2)]);
    }
}
