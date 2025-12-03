using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    float _distance = 14.25f;
    int _count = 2;
    int _index = 2;

    public GameObject[] grounds;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition += new Vector3(-0.01f, 0, 0);

        _count = 2 + (int)(-gameObject.transform.localPosition.x / 14.25f);

        if (_index != _count)
        {
            grounds[(_index - 2) % 3].transform.localPosition = new Vector3(_distance * _count, -4, 0);
            _index = _count;
        }
    }
}
