using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    [SerializeField] RawImage _blackSprite;
    [SerializeField] Sprite _codePadSprite;
    [SerializeField] Transform _codePadImage;
    [SerializeField] string _codePass;
    [SerializeField] UnityEvent _onOpen;
    [SerializeField] AudioClip _clip;
    string _currentString;

    public void EnterNumber(string num)
    {
        _currentString += num;
        Debug.LogError(_currentString);
        if(_currentString.Length == _codePass.Length)
        {
            if(_currentString.Contains(_codePass))
            {
                _codePadImage.gameObject.SetActive(false);
                _blackSprite.DOFade(0, 1).OnComplete(()=>Destroy(this));
                SoundManager.Instance.PlaySound(_clip);
                _onOpen.Invoke();
                Debug.LogError("Opened");

            }
            else
            {
                _currentString = string.Empty;
                //звук неправильного ответа;
                Debug.LogError("False");
            }
        }
        
    }
    public void OnInteraction()
    {
        _blackSprite.DOFade(1, 1).OnComplete(()=> { _codePadImage.gameObject.SetActive(true); StartCoroutine(Wait()); });


    }
    IEnumerator Wait()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        _codePadImage.gameObject.SetActive(false);
        _blackSprite.DOFade(0, 1);
        _currentString = string.Empty;

    }
}
