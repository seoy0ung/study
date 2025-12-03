using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScript : MonoBehaviour
{
    private string[] materialinfo = {"Fiber(Clone)", "Gem(Clone)", "Glass(Clone)", "Herb(Clone)", "Metal(Clone)", "Wood(Clone)"};
    private int getma;

    private void Update() {
        if(transform.position.y < -6) Destroy(gameObject);    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("BASKET")){
            getma = System.Array.IndexOf(materialinfo, this.gameObject.name);
            Debug.Log(this.gameObject.name);
            GameObject.Find("Player").GetComponent<Mini>().getmaterials[getma] += 1;
            Destroy(gameObject);
        }
    }
}
