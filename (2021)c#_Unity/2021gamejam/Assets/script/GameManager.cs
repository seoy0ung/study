using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�ʿ买ǰ���� ����� 0�ϰ�� ����, 1�ϰ�� ����, 2�ϰ�� ������ �ǹ�
    public static int [] item = new int[11];
    public static int[] materials = new int[6];//0-����, 1-����, 2-��, 3-����,4-����,5-ö
    public static int TalkCount;
    public static int day=1, week=1, Gold = 0;
    public static int[] schedule = new int [7];
    public static GameObject player;
    public static new List<Dictionary<string, object>> data_Dialog = new List<Dictionary<string, object>>();
    Sprite[] Items;
    Sprite[] Materials;
    private string[] iteminfo = { "Sword", "Shield", "Arrow", "Stick","Armor", "Shoulder", "Necklace", "Ring", "Heal", "Mana", "Vital" };
    private string[] materialinfo = { "Fiber", "Gem", "Glass", "Herb", "Metal", "Wood" };
    public GameObject[] Item_Image = new GameObject[17];
    public TextMeshProUGUI GoldText;
    //public static new List<Dictionary<string, object>> sword = new List<Dictionary<string, object>>();
    //public static new List<Dictionary<string, object>> sword_bad = new List<Dictionary<string, object>>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("����");
        DontDestroyOnLoad(gameObject);

        //������ ����
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(iteminfo[i]) == false) PlayerPrefs.SetInt(iteminfo[i], 0);
        }
        for (int i = 0; i < 6; i++)
        {
            if (PlayerPrefs.HasKey(materialinfo[i]) == false) PlayerPrefs.SetInt(materialinfo[i], 0);
        }
        for(int i =0; i<item.Length;i++)
        {
            //0 - ��, 1 - ����, 2 - Ȱ, 3 - ������, 4 - ����, 5 - ����, 6 - �����, 7- ����, 8-ȸ������, 9-��������,10-Ȱ������
            //������ ������� 0�� �������, 1�� ��������, 2�� ���� ����
            item[i] = Random.Range(0, 3);
        }
        Items = Resources.LoadAll<Sprite>("Items");
        Materials = Resources.LoadAll<Sprite>("Materials");
        for(int i=0;i<11;i++)
        {
            Item_Image[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Items[i];
            Item_Image[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(iteminfo[i]).ToString() + "��";
        }
        for(int i=11;i<17; i++)
        {
            Item_Image[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Materials[i-11];
            Item_Image[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(materialinfo[i-11]).ToString() + "��";
        }
        GoldText.text = Gold.ToString() + " G";

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "gameScene" && GameObject.Find("MaterialInfo") != null){
            GameObject.Find("buttonManager").GetComponent<Button>().ExitButton();
            Destroy(GameObject.Find("MaterialInfo"));
        }
    }
}
