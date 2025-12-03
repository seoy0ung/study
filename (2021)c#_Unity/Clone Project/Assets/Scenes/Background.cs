using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 10f;
    public Transform[] backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        if (gameObject.transform.position.y < -10)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
