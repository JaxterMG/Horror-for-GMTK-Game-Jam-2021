using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMonogues : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    public void Swap()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
