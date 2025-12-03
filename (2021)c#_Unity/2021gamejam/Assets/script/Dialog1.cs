using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog1 : MonoBehaviour
{
    public int rand, newsnum, talknum;
    public bool TalkEnd;
    public TextMeshProUGUI GainInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TalkEnd == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject.Find("NPC1").GetComponent<NPC>().enabled = true;
            GameObject.Find("NPC2").GetComponent<NPC>().enabled = true;
            GameObject.Find("NPC3").GetComponent<NPC>().enabled = true;
            GameObject.Find("NPC4").GetComponent<NPC>().enabled = true;
            GameObject.Find("NPC5").GetComponent<NPC>().enabled = true;
            GameObject.Find("대화캔버스").SetActive(false);
            TalkEnd = false;
        }
        if (gameObject.activeSelf == true)
        {
            if(Input.GetKeyDown("1")&& TalkEnd == false)
            {
                talknum = Random.Range(0, 45);
                GameManager.data_Dialog = CSVReader.Read("일상대화");
                Debug.Log(GameManager.data_Dialog[talknum]["Text"].ToString());
                gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[talknum]["Text"].ToString();
                TalkEnd = true;
            }
            if(GameManager.TalkCount<3 && Input.GetKeyDown("2"))
            {
                rand = Random.Range(0, 6);
                newsnum = Random.Range(0, 15);
                GameManager.TalkCount++;
                Debug.Log(GameManager.TalkCount);
                switch (rand)
                {
                    case 0://검에대한 정보제공
                        if(GameManager.item[rand] == 0)
                        {
                            GameManager.data_Dialog = CSVReader.Read("검나쁜뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if(GameManager.item[rand] == 1)
                        {
                            GameManager.data_Dialog = CSVReader.Read("검뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if(GameManager.item[rand] == 2)
                        {
                            GameManager.data_Dialog = CSVReader.Read("검좋은뉴스");
                            GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString()+"\n";
                            TalkEnd = true;
                        }
                        break;
                    case 1://방패에 대한 정보제공
                        if (GameManager.item[rand] == 0)
                        {
                            GameManager.data_Dialog = CSVReader.Read("방패뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 1)
                        {
                            GameManager.data_Dialog = CSVReader.Read("방패뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 3)
                        {
                            GameManager.data_Dialog = CSVReader.Read("방패좋은뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        break;
                    case 2://활에대한 정보제공
                        if (GameManager.item[rand] == 0)
                        {
                            GameManager.data_Dialog = CSVReader.Read("검나쁜뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 1)
                        {
                            GameManager.data_Dialog = CSVReader.Read("검뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 3)
                        {
                            GameManager.data_Dialog = CSVReader.Read("검좋은뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        break;
                    case 3://포션에대한 정보제공
                        if (GameManager.item[rand] == 0)
                        {
                            GameManager.data_Dialog = CSVReader.Read("포션나쁜뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 1)
                        {
                            GameManager.data_Dialog = CSVReader.Read("포션뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 3)
                        {
                            GameManager.data_Dialog = CSVReader.Read("포션좋은뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        break;
                    case 4:// 지팡이에 대한 정보제공
                        if (GameManager.item[rand] == 0)
                        {
                            GameManager.data_Dialog = CSVReader.Read("방패나쁜뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 1)
                        {
                            GameManager.data_Dialog = CSVReader.Read("방패나쁜뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 3)
                        {

                        }
                        GameManager.data_Dialog = CSVReader.Read("방패좋은뉴스");
                        gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                        GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                        TalkEnd = true;
                        break;
                    case 5://장신구에대한 정보제공
                        if (GameManager.item[rand] == 0)
                        {
                            GameManager.data_Dialog = CSVReader.Read("장신구나쁜뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 1)
                        {
                            GameManager.data_Dialog = CSVReader.Read("장신구뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        else if (GameManager.item[rand] == 3)
                        {
                            GameManager.data_Dialog = CSVReader.Read("장신구좋은뉴스");
                            gameObject.transform.GetComponent<Text>().text = GameManager.data_Dialog[newsnum]["Text"].ToString();
                            GainInfo.GetComponent<TextMeshProUGUI>().text += GameManager.data_Dialog[newsnum]["Text"].ToString() + "\n";
                            TalkEnd = true;
                        }
                        break;

                }

                //if(GameManager.item[1,rand] == )
            }
        }
        

    }
}
