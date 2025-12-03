using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time < 60f)
        {
            time += Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
