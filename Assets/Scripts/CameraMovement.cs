using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool _inSecondRoom= false;
    Transform _cam;
    [SerializeField]Transform _player;
    [SerializeField] Vector2 _boundsX;
    [SerializeField] Vector2 _boundsY;
    private void Start()
    {
        _cam = Camera.main.transform;
     
    }
    // Update is called once per frame
    void Update()
    {
       // _cam.transform.position = new Vector3(0, 0, -10);
        if (_inSecondRoom)
        {
            _cam.position = new Vector3(_cam.position.x, Mathf.Clamp(_player.position.y, _boundsY.x, _boundsY.y), -10);
        }
    }
    public void ChangeBool()
    {
        _inSecondRoom = !_inSecondRoom;
    }
}
