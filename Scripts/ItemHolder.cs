using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHolder : MonoBehaviour
{
    public Sprite _image;
    public string _itemName;
    public AudioClip _audioClip;
    SpriteRenderer _renderer;
    [SerializeField] Sprite _sprite;
    Sprite _defaultSprite;
    bool _changed = false;
    [SerializeField] UnityEvent _onInteract;
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
        else
            _renderer.sprite = _defaultSprite;
        _changed = !_changed;
    }
    public void Destruct()
    {
        _onInteract.Invoke();
        Destroy(this);
    }
  

}
