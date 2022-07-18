using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] float _defaultDelay;
    float _delay;
    [SerializeField] string[] _dialogueTexts;

    [SerializeField] string[] _secondDialogueTexts;
    [SerializeField] TextMeshProUGUI _textComponent;
    [SerializeField] Transform _face;
    [SerializeField] RawImage _darkImage;
    [SerializeField] UnityEvent _onInteract;
    [SerializeField] UnityEvent _onEndMono;
    float y;
    SpriteRenderer _renderer;
    [SerializeField] Sprite _sprite;
    Sprite _defaultSprite;
    bool _changed = false;
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
    private void Awake()
    {
        y = _face.position.y - 900;
        Debug.LogError(y);
        _delay = _defaultDelay;
    }
    public void PlayMonologue()
    {
        _onInteract.Invoke();
        StartCoroutine(WaitDialog());
    }
   
    IEnumerator WaitDialog()
    {
        PlayerController.Instance.ChangeAllowMove();
        _darkImage.DOFade(1, 1).OnComplete(() => _face.DOLocalMoveY(0, 1));
        _face.DOLocalMoveY(0, 1);
        yield return new WaitForSeconds(2);
        for (int i = 0; i < _dialogueTexts.Length; i++)
        {
            for (int j = 0; j < _dialogueTexts[i].Length; j++)
            {
            

                if (_dialogueTexts[i][j].ToString().Contains("<"))
                {
                    while (!_dialogueTexts[i][j].ToString().Contains(">"))
                    {
                        _textComponent.text += _dialogueTexts[i][j];
                        j++;
                    }
                }
                if (_dialogueTexts[i][j].ToString().Contains(" "))
                {
                    while (_dialogueTexts[i][j].ToString().Contains(" "))
                    {
                        _textComponent.text += _dialogueTexts[i][j];
                        j++;
                        yield return new WaitForSeconds(_delay);
                    }
                }


                
                    _textComponent.text += _dialogueTexts[i][j];
                    SoundManager.Instance.PlayWhisperSound();
                    yield return new WaitForSeconds(_delay);
               
                
            }

          

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            _textComponent.text = "";
        }
            _face.DOLocalMoveY(y, 1.6f).OnComplete(() => _darkImage.DOFade(0, 1));
            yield return new WaitForSeconds(3);
            PlayerController.Instance.ChangeAllowMove();
            _onEndMono.Invoke();
            Destroy(this);

        

    }
}
