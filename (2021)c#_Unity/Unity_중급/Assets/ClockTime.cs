using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockTime : MonoBehaviour
{
    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = string.Format("<size=24>{0:tt}</size> {1:h:m:s}", DateTime.Now, DateTime);
    }
}
