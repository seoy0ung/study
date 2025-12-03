using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRMove : MonoBehaviour
{
    Vector3 objpos = new Vector3(10f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {
        for(int i = 0; i < 120; i++)
        {
            transform.position = Vector3.Lerp(transform.position, objpos, 0.025f);
            yield return null;
        }
    }
}
