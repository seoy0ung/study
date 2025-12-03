using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject WeaponUpgrade;
    public GameObject WeaponSprite;
    public TextMeshProUGUI WeaponPoint;
    public Sprite[] sprites = new Sprite[5];


    void Start()
    {
        PlayerPrefs.SetInt("WeaponPoint", 0);
        
        WeaponPoint.text = "Lv." + PlayerPrefs.GetInt("WeaponPoint").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponPoint.text = PlayerPrefs.GetInt("WeaponPoint").ToString();

        WeaponSprite.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("WeaponPoint")];
    }

    public void WeaponPointplus()
    {
        if (PlayerPrefs.GetInt("WeaponPoint") >= 4)
        {
            return;
        }
        PlayerPrefs.SetInt("WeaponPoint", PlayerPrefs.GetInt("WeaponPoint") + 1);
    }
}

