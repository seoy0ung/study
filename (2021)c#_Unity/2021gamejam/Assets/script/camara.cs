using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("주인공");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("주인공") == null) transform.position = new Vector3(0,0,-10);
        else{
        transform.position = new Vector3( character.transform.position.x,character.transform.position.y,-10 );
        }
    }
}
