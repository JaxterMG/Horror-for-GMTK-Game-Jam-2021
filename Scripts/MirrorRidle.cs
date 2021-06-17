using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MirrorRidle : MonoBehaviour
{
    [SerializeField] RawImage _blackSprite;
    [SerializeField] Sprite _mirrorSprite;
    [SerializeField] RawImage _mirrorImage;
    public void OnInteraction()
    {
        _mirrorImage.texture = _mirrorSprite.texture;
        _blackSprite.DOFade(1, 1).OnComplete(() => { _mirrorImage.DOFade(1, 0); StartCoroutine(Wait()); });
       
    }
    IEnumerator Wait()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        _mirrorImage.DOFade(0, 1).OnComplete(() => _blackSprite.DOFade(0, 1));

    }
}
