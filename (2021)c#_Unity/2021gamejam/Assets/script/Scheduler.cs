using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


public class Scheduler : MonoBehaviour
{
    public Canvas gathering;
    public TextMeshProUGUI WeekTxt;
    private int todo;
    public int[] sc = new int [7];
    public GameObject[] BtnArray = new GameObject[7];
    Color colorChange;

    // Start is called before the first frame update
    void Start()
    {
        todo = 0;
        //���ΰ� ������ ����
        GameManager.player = GameObject.Find("주인공");
        GameManager.player.gameObject.SetActive(true);
        
    }
    private void OnEnable()
    {
        WeekTxt.text = "Week " + GameManager.week.ToString();
        for (int i = 0; i < 7; i++)
            BtnArray[i].GetComponent<Image>().color = Color.white;
    }

    public void SchedulerClick()
    {        
        switch (todo)
        {
            case 1:
                colorChange = new Color(0, 1f, 0, 1f);
                break;
            case 2:
                colorChange = new Color(0, 1, 1, 1f);
                break;
            case 3:
                colorChange = new Color(1, 0.5f, 0, 1f);
                break;
            case 4:
                colorChange = new Color(1, 1, 0, 1f);
                break;
            default:
                colorChange = Color.white;
                break;
        }
        GameObject btn= EventSystem.current.currentSelectedGameObject;
        btn.GetComponent<Image>().color = colorChange;
        sc[int.Parse(btn.name)] = todo;
        //Debug.Log(sc[0]);

    }

    public void SClick()//����
    {
        todo = 1;
    }

    public void GClick()//ä��
    {
        todo = 2;
    }

    public void MClick()//����
    {
        todo = 3;
    }
    public void SeClick()//�Ǹ�
    {
        todo = 4;
    }

    public void NClick()
    {
        int i;
        for(i = 0;i<7;i++){
            if(sc[i] == 0) break;
        }
        if(i == 7) {
            for(i=0;i<7;i++){
                GameManager.schedule[i] = sc[i];
            }
             if(sc[0] == 1)
             {
                gameObject.SetActive(false);
                gameObject.GetComponent<Scheduler>().enabled = false;
                GameManager.player.gameObject.SetActive(true);
            }
               
            else if(sc[0] == 2)
            {
                gameObject.SetActive(false);
                gathering.gameObject.SetActive(true);
            }
            else if(sc[0] == 3)
            {
                SceneManager.LoadScene("ManufacScene");
                DontDestroyOnLoad(gameObject);
            }
            else if (sc[0] == 4)
            {
                
            }
        }
    }
}
