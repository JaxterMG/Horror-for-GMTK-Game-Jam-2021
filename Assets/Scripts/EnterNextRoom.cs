using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnterNextRoom : MonoBehaviour
{
    [SerializeField] Vector2 _destination;
    [SerializeField] RawImage _blackImage;
    [SerializeField] Vector2 _newCameraPos;
    [SerializeField] Vector2 _firstCameraPos;
    [SerializeField] Transform _player;
    private void Start()
    {
        
    }
    public void Teleport()
    {
       
        _blackImage.DOFade(1, 1).OnComplete(()=> { PlayerController.Instance.transform.position = _destination; _blackImage.DOFade(0, 1); ChangeCameraPos(); });
    }
    void ChangeCameraPos()
    {
        Camera.main.transform.position = new Vector3(_newCameraPos.x,_newCameraPos.y, Camera.main.transform.position.z);
    }
    public void TeleportBack()
    {
        
        _blackImage.DOFade(1, 1).OnComplete(() => {_blackImage.DOFade(0, 1); PlayerController.Instance.Teleport(); ChangeBack(); });
    }
    void ChangeBack()
    {
        Camera.main.transform.position = new Vector3(_firstCameraPos.x, _firstCameraPos.y, Camera.main.transform.position.z);
    }

}
