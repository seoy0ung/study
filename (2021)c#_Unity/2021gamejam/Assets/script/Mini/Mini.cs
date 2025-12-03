using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mini : MonoBehaviour
{
    public bool isgameend;
    private Vector3 pos;
    private string[] materialinfo = {"Fiber", "Gem", "Glass", "Herb", "Metal", "Wood"};
    private GameObject[] materials = new GameObject[6];
    public int[] getmaterials = new int[6];
    public GameObject canvasend;
    private int time;
    
    // Start is called before the first frame update
    void Start()
    {
        //isgameend = true;
        materials[0] = Resources.Load("Prefabs/Fiber") as GameObject;
        materials[1] = Resources.Load("Prefabs/Gem") as GameObject;
        materials[2] = Resources.Load("Prefabs/Glass") as GameObject;
        materials[3] = Resources.Load("Prefabs/Herb") as GameObject;
        materials[4] = Resources.Load("Prefabs/Metal") as GameObject;
        materials[5] = Resources.Load("Prefabs/Wood") as GameObject;
        for(int i = 0;i<6;i++) getmaterials[i] = 0;
        StartCoroutine(MCreate());
        time = 0;
    }

    void OnEnable(){
        isgameend = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isgameend){
            //Debug.Log(123456);
            pos = transform.position;
            if(pos.x <= -8.5){
                if(Input.GetKey(KeyCode.RightArrow)) transform.position += new Vector3(0.5f, 0, 0);
            } else if(pos.x >= 8.5){
                if(Input.GetKey(KeyCode.LeftArrow)) transform.position += new Vector3(-0.5f, 0, 0);
            } else{
                if(Input.GetKey(KeyCode.RightArrow)) transform.position += new Vector3(0.5f, 0, 0);
                if(Input.GetKey(KeyCode.LeftArrow)) transform.position += new Vector3(-0.5f, 0, 0);
            }
        }
    }

    IEnumerator MCreate()
    {
        while(time<5){
            yield return new WaitForSeconds(1f);
            int num = Random.Range(0,6);
            Instantiate(materials[num], new Vector3(Random.Range(-8.5f, 8.5f), 5f, 0f), new Quaternion(0,0,0,0));
            time++;
        }
        time = 0;
        isgameend = true;
        canvasend.SetActive(true);
        canvasend.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = 
        "Fiber: "+ getmaterials[0] + " Gem: " + getmaterials[1] + " Glass: " + getmaterials[2] + " Herb: " + getmaterials[3] +  " Metal: " + getmaterials[4] + " Wood: " + getmaterials[5];
        for(int k = 0;k<6;k++){
            PlayerPrefs.SetInt(materialinfo[k], PlayerPrefs.GetInt(materialinfo[k], getmaterials[k]));
        }
    }

    public void EClick()
    {
        // GameManager.day += 1;
        // if (GameManager.schedule[GameManager.day] == 1)//마을
        //     {
        //         SceneManager.LoadScene("gameScene");
        //         DontDestroyOnLoad(info);
        //         //InfoText.GetComponent<Text>().text = "";
        //     }
        //     else if (GameManager.schedule[GameManager.day] == 2)//채집������ ���� ä��
        //     {
        //         SceneManager.LoadScene("MinigameScene");
        //         DontDestroyOnLoad(info);
        //     }
        //     else if (GameManager.schedule[GameManager.day] == 3)//제작
        //     {
        //         SceneManager.LoadScene("ManufacScene");
        //         DontDestroyOnLoad(info);
        //     }
        //     else if(GameManager.schedule[GameManager.day] == 4)//판매
        //     {
                    
        //     }
            
        
    }
}
