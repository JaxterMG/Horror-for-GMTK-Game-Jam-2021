using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] float _speed;
    Animator _anim;
    SpriteRenderer _playerRenderer;
    AudioSource _source;
    [SerializeField] AudioClip[] _clips;
    bool allowMove = true;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _anim = GetComponent<Animator>();
        _playerRenderer = GetComponent<SpriteRenderer>();
        //  _playerAudio.GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allowMove)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            transform.position += new Vector3(x, y, 0) * _speed * Time.deltaTime;
            _anim.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(y));
            Flip();
        }

    }
    public void ChangeAllowMove()
    {
        _anim.SetFloat("Speed", 0);
        allowMove = !allowMove;
    }
    public void Teleport()
    {
        transform.position = new Vector3(2.7f, -0.15f, 0);
    }

    void Flip()
    {
        if (x < 0)
        {
            _playerRenderer.flipX = true;
        }
        else if(x>0)
        {
            _playerRenderer.flipX = false;
        }
        
    }
}
