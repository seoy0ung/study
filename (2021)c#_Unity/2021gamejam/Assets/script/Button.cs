using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Canvas InfoCanvas, Gathering, InvenCanvas, SchehuleCanvas;
    public GameObject canvasend;
    public GameObject info;
    public Text DayText;
    public Text InfoText;
    public GameObject miniplayer;
    public GameObject minibg;
    public GameObject village;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InfoButton()
    {
        InfoCanvas.gameObject.SetActive(true);
    }

    public void ExitButton()
    {
        if(GameManager.day%7 == 0)//������ ������ ������
        {
            GameManager.week += 1;
            GameManager.day += 1;
            
            SchehuleCanvas.gameObject.SetActive(true);
            SchehuleCanvas.GetComponent<Scheduler>().enabled = true;

        }
        else//���� �ȳ���
        {
            GameManager.player.SetActive(false);
            minibg.SetActive(false);
            canvasend.SetActive(false);
            miniplayer.SetActive(false);
            village.SetActive(false);
            Debug.Log(789);
            if (GameManager.schedule[GameManager.day] == 1)
            {
                Debug.Log(456);
                if (GameManager.TalkCount == 3)//마을
                {
                    Debug.Log(123);
                    SchehuleCanvas.gameObject.SetActive(false);
                    GameManager.player.SetActive(true);
                    village.SetActive(true);
                    GameManager.player.transform.position = new Vector2(0, 0);
                    GameManager.TalkCount = 0;
                    //InfoText.GetComponent<Text>().text = "";
                }
            }
            if (GameManager.schedule[GameManager.day] == 2)//채집������ ���� ä��
                {
                    SchehuleCanvas.gameObject.SetActive(false);
                    Gathering.gameObject.SetActive(true);
                    GameManager.player.SetActive(false);
                }
            else if (GameManager.schedule[GameManager.day] == 3)//제작
                {
                    SceneManager.LoadScene("ManufacScene");
                    DontDestroyOnLoad(SchehuleCanvas);
                }
            else if(GameManager.schedule[GameManager.day] == 4)//판매
                {
                    
                }        
            GameManager.day += 1;
            DayText.GetComponent<Text>().text = "DAY" + GameManager.day;
        }
        
    }
    public void InvenButton()
    {
        InvenCanvas.gameObject.SetActive(true);
        Debug.Log("�κ�Ŵ");
        GameObject.Find("GameManager").SendMessage("Start");
    }
}
