using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Item : MonoBehaviour
{
    public GameObject cam;
    private GameObject clickedbtn;
    private GameObject materialobj;
    public GameObject info;
    private string[] materialinfo = {"Fiber", "Gem", "Glass", "Herb", "Metal", "Wood"};
    private int[] materials = new int[6];
    Dictionary <string, int> neededmat;
    private int price;
    public int[,] iteminfos = new int[10, 6];
    int k;

    private void Start(){
        for(int i=0;i<10;i++){
            for(int j=0;j<6;j++) cam.GetComponent<ItemLoad>().ItemInfos[i, j] = iteminfos[i, j]; 
        }
    }

    private void Update() {
        Debug.Log(PlayerPrefs.GetInt("Sword"));    
    }

    public void BtnClick()
    {
        clickedbtn= EventSystem.current.currentSelectedGameObject;
        transform.Find("BG").gameObject.SetActive(true);
        transform.Find(clickedbtn.name+"Detail").gameObject.SetActive(true);
    }
    
    public void BgClick()
    {
        transform.Find("BG").gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
    }

    public void ItemClick()
    {
        clickedbtn= EventSystem.current.currentSelectedGameObject;
        neededmat = new Dictionary<string, int> ();
        int nl = 0;
        for(k=0;k<clickedbtn.transform.childCount-1;k++){
            materialobj = clickedbtn.transform.GetChild(k).gameObject;
            price = int.Parse(materialobj.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
            neededmat.Add(materialobj.name, price);
            if(PlayerPrefs.GetInt(materialobj.name) >= price) nl++;            
        }
        if(k == nl){
            foreach (var item in neededmat)
            {
                PlayerPrefs.SetInt(item.Key, PlayerPrefs.GetInt(item.Key)- item.Value);
            }
            PlayerPrefs.SetInt(clickedbtn.name, PlayerPrefs.GetInt(clickedbtn.name)+1);
            clickedbtn.transform.Find("NUM").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(clickedbtn.name).ToString();
        }
        
    }

    public void EClick()
    {
        //for(int j = 0;j<6;j++){
        //    getmaterials[j] = info.GetComponent<Info>().gotmaterials[j];
        //}
        SceneManager.LoadScene("gameScene");
        DontDestroyOnLoad(info);
        GameManager.day++;
    }

}
