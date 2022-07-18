using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public Sprite _image;
    public string _itemNeeded;
    public AudioClip _audioClip;
    public UnityEvent _onInteract;
    SpriteRenderer _renderer;
    [SerializeField] Sprite _sprite;
    Sprite _defaultSprite;
    bool _changed = false;
    [SerializeField] bool _dontDestroy = false;
    [SerializeField] bool _needToChange = true;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _renderer.sprite;
    }

    public void ChangeSprite()
    {
        if (!_changed)
        {
            _renderer.sprite = _sprite;
        }
        else if(_changed && _needToChange)
            _renderer.sprite = _defaultSprite;
        _changed = !_changed;
    }
    public void ChangeToFalse()
    {
       _renderer.sprite = _defaultSprite;
        _changed = false;
    }
    public void Interact()
    {
        _onInteract.Invoke();
        ChangeToFalse();
        if (!_dontDestroy)
        {
            Destroy(this);
        }
    }

}
