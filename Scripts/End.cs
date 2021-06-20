using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class End : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tmpro;
    [SerializeField] RawImage _black;
    // Start is called before the first frame update
    public void EndGame()
    {
        _black.DOFade(1, 2).OnComplete(() => _tmpro.DOFade(1, 2));
        PlayerController.Instance.ChangeAllowMove();
    }
}
