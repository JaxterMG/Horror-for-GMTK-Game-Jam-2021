using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PickupController : MonoBehaviour
{
    [SerializeField] RawImage _itemImage;
    [SerializeField] RawImage _darkScreen;
    [SerializeField] RawImage _darkScreen2;
    [SerializeField] TextMeshProUGUI _pickupText;
    [SerializeField] Transform _uiGridGroup;

    List<string> _itemList = new List<string>();

    public static PickupController Instance;

    void Start()
    {
        Instance = this;
        _darkScreen2.DOFade(0, 2);
    }
  

    public void PickItem(Sprite _itemSprite, string _itemName, AudioClip _pickupSound)
    {
        _pickupText.text = _itemName;
        _itemList.Add(_itemName);
        _itemImage.texture = _itemSprite.texture;
        StartCoroutine(Wait());
        _darkScreen.DOFade(1, 1)
            .OnComplete(()=> _itemImage.DOFade(1,1)
                .OnComplete(()=> { _itemImage.DOFade(0, 1); _darkScreen.DOFade(0, 1); }));
        GameObject _panel = new GameObject();
        _panel.name = _itemName;
        _panel.transform.SetParent(_uiGridGroup);
        _panel.AddComponent<RawImage>();
        _panel.GetComponent<RawImage>().texture = _itemSprite.texture;
        if(_pickupSound!=null)
            SoundManager.Instance.PlaySound(_pickupSound);


    }

    public bool CheckForItem(string _itemName, AudioClip _interactSound)
    {
        if (_itemList.Contains(_itemName))
        {
            SoundManager.Instance.PlaySound(_interactSound);
            _itemList.Remove(_itemName);
            for(int i = 0; i<_uiGridGroup.childCount; i++)
            {
                if(_uiGridGroup.GetChild(i).name == _itemName)
                {
                    Destroy(_uiGridGroup.GetChild(i).gameObject);
                }
            }

            return true;
        }
        else
            return false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        _pickupText.DOFade(1, 1).OnComplete(() => _pickupText.DOFade(0, 1));
    }

}
