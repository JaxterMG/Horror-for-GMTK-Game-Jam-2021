using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] SpriteRenderer _blackImage;
    public void OpenDoorEvent()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1);
        _blackImage.DOFade(0, 1).OnComplete(() => Destroy(this.gameObject));
        
    }
}
