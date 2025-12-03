using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public static List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
    // public AgeInfo infancy = new AgeInfo(7, 5.0f);
    // public AgeInfo child = new AgeInfo(6, 5.0f);
    // public AgeInfo student = new AgeInfo(6, 30.0f);
    // public AgeInfo adult = new AgeInfo(6, 5.0f);
    public AgeInfo infancy = new AgeInfo(7, 30.0f);
    public AgeInfo child = new AgeInfo(6, 42.0f);
    public AgeInfo student = new AgeInfo(6, 78.0f);
    public AgeInfo adult = new AgeInfo(6, 90.0f);

    public string Name;//이름
    public bool Ismale;//남자인지 여부
    public int age = 0; // 나이
    public bool stage_end = false;

    public Sprite MaleImage; //남자 이미지
    public Sprite FemaleImage; //여자 이미지

    public int nstate = 0; // 0: 유아기, 1: 유년기, 2: 학생기, 3: 성인기
    public string[] jobs; //직업 가짓수 배열
    public string[,] job_category; // 직업 카테고리 for quiz
    public string njob; // 현재 직업
    public int jobIdx; // 직업의 인덱스 
    public Gauge2Info ncharacter; // 현재 캐릭터 수치 정보
    public float decrease_speed = 0.5f; // 감정게이지 감소 속도

    public GameObject player; // 플레이어
    public GameObject emotion_gaugeBar; // 감정 게이지
    Image egauge, agauge;
    public GameObject achieve_gaugeBar; // 성취도 게이지
    public GameObject ending_g; // good ending
    public GameObject ending_s; // soso ending
    public GameObject ending_b; // bad ending
    public GameObject ending_f; // fail ending
    public GameObject ending_t; // ending text
    public GameObject ShowAge; // 나이 표시 텍스트

    public GameObject LoadingCanvas; //스테이지 넘어갈때 화면 검게 해줄 캔버스
    public GameObject BlackScreen; //로딩캔버스내에 있는 검은 이미지
    public GameObject Go123; //3,2,1숫자를 센후 시작
    public GameObject StartText; // 게임시작시 Start!글자
    public GameObject QuizCanvas; // 직업 퀴즈 캔버스
    public Text[] QuizBtnText; // 2지선다 버튼 텍스트
    public int CorF; // 퀴즈 정답 여부(0: 선택 안함, 1: 정답, 2: 오답)
    public Text QuizText; // 퀴즈 텍스트
    public GameObject[] hurdles; //장애물 배열
    public GameObject[] Items_stage1; // 유아기 아이템 배열
    public GameObject[] Items_stage2; // 유년기 아이템 배열
    public Sprite[] Items_stage3; // 학생기 아이템 배열
    public GameObject[] realItems_stage2; // 유년기 때 나오는 아이템 배열
    public List<Stage3> realItems_stag3 = new List<Stage3>(); // 학생기 때 나오는 아이템 배열
    public GameObject Item_adult;
    public GameObject EmotionItem; // 감정 아이템
    public Sprite[] arrow_sprite; // 화살표 이미지들
    public List<GameObject> minigame_sprite = new List<GameObject>(); // 미니게임 창에 나오는 이미지들
    List<int> minigame_arrow_list = new List<int>(); // 미니게임 창에 나온 화살표 번호 배열 
    public int minigame_arrrow_index = 0; // 클릭된 화살표와 비교해야하는 화살표의 인덱스 
    public int clicked_arrow; // 클릭된 화살표 번호 
    public bool minigameFailed = false;
    public bool minigameEnd = false;
    public GameObject minigameCanvas;
    public GameObject successMessage;
    public GameObject failMessage;
    public GameObject minigameTimeText;
    public int minigametime=5;

    public bool isPause = false; // 일시정지
    public GameObject pauseButton; // 버튼
    public Sprite pauseSprite; // 일시정지 이미지
    public Sprite playSprite; // 플레이 이미지
    public GameObject pauseMessage; // 일시정지 글자 

    public GameObject tutorialCanvas; // 설명 캔버스
    public string player_name; // 사용자 이름
    public GameObject jumpButton;
    public GameObject slideButton;

    private void Awake()
    {
        GM = this;
        data = CSVReader.Read("AgaugeInfo");
        Ismale = System.Convert.ToBoolean(PlayerPrefs.GetInt("IsMale")); //성별 불러와 저장

        jobs = new string[8] { "의사", "판사", "개발자", "회사원", "스트리머", "화가", "운동선수", "용사" };
        job_category = new string[,] { { "의사", "판사", "개발자", "회사원" }, { "스트리머", "화가", "운동선수", "화가" } };
        jobIdx = Random.Range(0, 7);
        njob = jobs[jobIdx];
        ncharacter = new Gauge2Info(njob);
        Debug.Log(njob);
        Debug.Log(ncharacter.childGauge[0]);
        Debug.Log(ncharacter.studentGauge[0]);
        for (int i = 0; i < ncharacter.childGauge.Count; i++) Items_stage2[i].GetComponent<ItemSetting>().CSetting(i);
    }

    void Start()
    {
        Time.timeScale = 1;
        // 이름 불러와 저장
        if(PlayerPrefs.HasKey("PName"))
            player_name = PlayerPrefs.GetString("PName");
        else if(PlayerPrefs.GetString("PName") == "")
            player_name = "아무개";
        else
            player_name = "아무개";
            
        StartCoroutine(LifeCycle());
        egauge = emotion_gaugeBar.GetComponent<Image>();
        agauge = achieve_gaugeBar.GetComponent<Image>();

        realItems_stage2 = new GameObject[4];
        RandomItemChoice(Items_stage2);

        // 학생기 아이템 + 2개 - 2개 뽑기
        int rn1, rn2, rn3, rn4;
        List<int> plusItem = new List<int>();
        List<int> minusItem = new List<int>();

        // + 아이템, - 아이템 분류
        for (int i = 0; i < ncharacter.studentGauge.Count; i++)
        {
            if (ncharacter.studentGauge[i] > 0)
            {
                plusItem.Add(i);
            }
            else
            {
                minusItem.Add(i);
            }
        }

        // real 배열에 넣기
        rn1 = Random.Range(0, plusItem.Count);
        realItems_stag3.Add(new Stage3(Items_stage3[plusItem[rn1]], ncharacter.studentGauge[plusItem[rn1]]));
        rn2 = Random.Range(0, plusItem.Count);
        while (rn1 == rn2)
        {
            rn2 = Random.Range(0, plusItem.Count);
        }
        realItems_stag3.Add(new Stage3(Items_stage3[plusItem[rn2]], ncharacter.studentGauge[plusItem[rn2]]));
        rn3 = Random.Range(0, minusItem.Count);
        realItems_stag3.Add(new Stage3(Items_stage3[minusItem[rn3]], ncharacter.studentGauge[minusItem[rn3]]));
        rn4 = Random.Range(0, minusItem.Count);
        while (rn3 == rn4)
        {
            rn4 = Random.Range(0, minusItem.Count);
        }
        realItems_stag3.Add(new Stage3(Items_stage3[minusItem[rn4]], ncharacter.studentGauge[minusItem[rn4]]));
        Debug.Log(realItems_stage2[3]);
        Debug.Log("도감 정보: "+ CollectionManager.CM.collectiondata.collectionList[0]);
    }


    void RandomItemChoice(GameObject[] stage) // + 아이템 2개 - 아이템 2개 뽑기
    {
        int rn1, rn2, rn3, rn4;
        List<int> plusItem = new List<int>();
        List<int> minusItem = new List<int>();

        // + 아이템, - 아이템 분류
        for (int i = 0; i < stage.Length; i++)
        {
            if (stage[i].tag == "ITEMPLUS")
            {
                plusItem.Add(i);
            }
            else
            {
                minusItem.Add(i);
            }
        }

        // real 배열에 넣기
        rn1 = Random.Range(0, plusItem.Count);
        realItems_stage2[0] = stage[plusItem[rn1]];
        rn2 = Random.Range(0, plusItem.Count);
        while (rn1 == rn2)
        {
            rn2 = Random.Range(0, plusItem.Count);
        }
        realItems_stage2[1] = stage[plusItem[rn2]];

        rn3 = Random.Range(0, minusItem.Count);
        realItems_stage2[2] = stage[minusItem[rn3]];
        rn4 = Random.Range(0, minusItem.Count);
        while (rn3 == rn4)
        {
            rn4 = Random.Range(0, minusItem.Count);
        }
        realItems_stage2[3] = stage[minusItem[rn4]];
    }
    IEnumerator StageIntervalRun() // 한 스테이지 끝나고 달려나가는..
    {
        yield return new WaitForSeconds(2f); //2초뒤에
        while (player.transform.position.x < 10)
        {
            player.transform.position += new Vector3(1, 0, 0);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator AgePlus(AgeInfo a) // 나이 및 시간 증가
    {
        for (int i = 0; i < a.period; i++)
        {
            age++;
            ShowAge.GetComponent<Text>().text = "" + age + "살";
            //Debug.Log(age);
            yield return new WaitForSeconds(a.time / a.period);
        }
    }


    IEnumerator Decrease_emotion_gauge()
    { // 감정게이지 지속적으로 감소(학생기때부터 적용)
        Gauge gauge = GameObject.Find("Player").GetComponent<Gauge>();

        while (GameManager.GM.nstate >= 2 && gauge.emotion_gauge > 0)
        {
            if(GameManager.GM.nstate == 2)
                gauge.emotion_gauge -= 2;
            if(GameManager.GM.nstate == 3)
                gauge.emotion_gauge -= 3;
            yield return new WaitForSeconds(decrease_speed);
        }
    }

    IEnumerator Minigame_Delay() // 미니게임 끝나고 3초 딜레이 
    {
        yield return new WaitForSecondsRealtime(3);
        minigameCanvas.SetActive(false);
        Time.timeScale = 1;
        jumpButton.GetComponent<Button>().interactable = true; // 점프 버튼 활성화
        slideButton.GetComponent<Button>().interactable = true; // 슬라이드 버튼 활성화 
        pauseButton.GetComponent<Button>().interactable = true; // 일시정지 버튼 활성화 
    }

    IEnumerator Minigame_timecheck()
    { // 미니게임 남은 시간 체크 
        while (minigametime >= 0 && !minigameEnd)
        { // 시간이 남아있을때 && 미니게임이 끝나지 않았을 때 
            yield return new WaitForSecondsRealtime(1);
            minigameTimeText.GetComponent<Text>().text = "남은 시간: " + minigametime;
            minigametime--;
        }

        if (minigameEnd && !minigameFailed) // 시간 내에 미니게임 성공 
        {
            yield return null;
        }
        else if(minigameEnd && minigameFailed){ // 시간 내에 미니게임 실패 
            yield return null;
        }
        else // 시간초과 
        {
            Gauge gauge = GameObject.Find("Player").GetComponent<Gauge>();
            if(gauge.achieve_gauge<20) gauge.achieve_gauge = 0;
            else gauge.achieve_gauge -= 20;
            failMessage.SetActive(true);
            minigameEnd = true;
            minigameFailed = true;
            StartCoroutine(Minigame_Delay());
            yield return null;
        }
    }

    IEnumerator StageInterval() // 스테이지 사이에 일어나는 일
    {
        stage_end = true; // 한 스테이지 끝 
        Debug.Log("스테이지 끝");
        yield return StartCoroutine(StageIntervalRun());
        Time.timeScale = 0; //->로딩시작
        LoadingCanvas.SetActive(true); //UI활성화 후
        BlackScreen.SetActive(true); //화면 검게 만듬

        if(nstate == 3){ // 학생기 ~ 성인기 퀴즈
            QuizCanvas.SetActive(true);
            int answer_num = Random.Range(0, 2); // 0 or 1
            int dif = 0; // 오답의 카테고리
            QuizBtnText[answer_num].text = njob; // 정답
            for (int l = 0; l < 4; l++)
            {
                if (job_category[0, l] == njob) dif = 1;
            }
            QuizBtnText[1 - answer_num].text = job_category[dif, Random.Range(0, 3)]; // 오답
            CorF = 0;
            yield return new WaitUntil(() => CorF != 0);
            if (CorF == 2)
            { // 오답
                QuizCanvas.SetActive(false);
                ending_t.SetActive(true);
                ending_f.SetActive(true);
                ending_t.GetComponent<Text>().text = "저런... " + player_name + "의 운명을 찾지 못하였구나";
            }
            else if (CorF == 1)
            { // 정답
                QuizText.text = "훌륭하구나.. 정답이란다..";
            }
            yield return new WaitForSecondsRealtime(1f);
            QuizCanvas.SetActive(false);
        }

        yield return new WaitForSecondsRealtime(2f); //2초뒤에
        player.transform.position = new Vector3(-5.5f, -1.572573f, 0);
        Color Black = BlackScreen.GetComponent<Image>().color;//직접 getcomponent로는 수정이 안됨 일단 color저장
        Black.a = 0.5f; //투명도 50%
        BlackScreen.GetComponent<Image>().color = Black;//다시 이미지에 반영
        Go123.SetActive(true); //숫자를 화면에 띄움
        Go123.GetComponent<Text>().text = "3";
        yield return new WaitForSecondsRealtime(1f);
        Go123.GetComponent<Text>().text = "2";
        yield return new WaitForSecondsRealtime(1f);
        Go123.GetComponent<Text>().text = "1";
        yield return new WaitForSecondsRealtime(1f);
        Black.a = 1f;
        BlackScreen.GetComponent<Image>().color = Black;
        BlackScreen.SetActive(false);
        Go123.SetActive(false); // 검은화면과 숫자를 비활성화
        StartText.SetActive(true); // Start!라는 텍스트를 화면에 띄움
        Time.timeScale = 1; //게임 이어서 시작
        start_tutorial(); // 튜토리얼
        yield return new WaitForSeconds(2f);
        stage_end = false;
        yield return new WaitForSecondsRealtime(1f);//1초이후에
        StartText.SetActive(false);
        LoadingCanvas.SetActive(false); //Start텍스트와 캔버스를 비활성화
    }

    public void close_tutorial(){ // 설명 창 끄기
        tutorialCanvas.SetActive(false);
        jumpButton.GetComponent<Button>().interactable = true; // 점프 버튼 활성화
        slideButton.GetComponent<Button>().interactable = true; // 슬라이드 버튼 활성화 
        pauseButton.GetComponent<Button>().interactable = true; // 일시정지 버튼 활성화 
        Time.timeScale = 1;
    }

    public void start_tutorial(){
        if(!TutorialControl.skip_tutorial){ // 설명 함 
            Time.timeScale = 0;
            tutorialCanvas.SetActive(true);
            tutorialCanvas.transform.GetChild(nstate).gameObject.SetActive(true); // 각 스테이지마다 설명
            jumpButton.GetComponent<Button>().interactable = false; // 점프 버튼 비활성화
            slideButton.GetComponent<Button>().interactable = false; // 슬라이드 버튼 비활성화 
            pauseButton.GetComponent<Button>().interactable = false; // 일시정지 버튼 비활성화 
            
        }
        else{
            tutorialCanvas.SetActive(false);
        }
    }

    IEnumerator LifeCycle() // 중간 분기 및 엔딩 관리
    {

        // 유아기
        Debug.Log("유아기");
        start_tutorial();
        yield return StartCoroutine(AgePlus(infancy));

        nstate++;

        yield return StartCoroutine(StageInterval());

        // 유년기
        Debug.Log("유년기");

        yield return StartCoroutine(AgePlus(child));

        // 유년기 ~ 학생기 탈락 결정
        float fa = agauge.fillAmount;
        // if(fa < 0.2){
        //    Time.timeScale = 0;
        //    ending_t.SetActive(true);
        //    ending_f.SetActive(true);
        //    ending_t.GetComponent<Text>().text = player_name + "은(는) 학생이 되지 못했다!";
        // }
        nstate++;
        yield return StartCoroutine(StageInterval());

        // 학생기
        Debug.Log("학생기");
        StartCoroutine(Decrease_emotion_gauge());


        yield return StartCoroutine(AgePlus(student));

        // 학생기 ~ 성인 탈락 결정
        fa = agauge.fillAmount;
        //if(fa < 0.5){
        //    Time.timeScale = 0;
        //    ending_t.SetActive(true);
        //    ending_f.SetActive(true);
        //    ending_t.GetComponent<Text>().text = player_name + "은(는) 어른이 되지 못했다!";
        //}
        nstate++;

        // 직업 맞추는 퀴즈
        
        yield return StartCoroutine(StageInterval());
        
        // 성인기
        Debug.Log("성인기");
        
        // 미니게임 나오게 하려고 성취도 80으로 바꾼거..
        Gauge gauge = GameObject.Find("Player").GetComponent<Gauge>();
        gauge.achieve_gauge = 80;
        yield return StartCoroutine(AgePlus(adult));

        //start_minigame();

        Time.timeScale = 0;
        //엔딩
        Debug.Log("엔딩");
        fa = agauge.fillAmount;
        ending_t.SetActive(true);
        Text t = ending_t.GetComponent<Text>();
        if (fa <= 0.6f)
        {
            ending_b.SetActive(true);
            t.text = player_name + "은(는) 쩌리 인생을 살았다!"; // 좀 더 좋은 워딩이 있으면.. 바꿔주시면...
            if (CollectionManager.CM.collectiondata.collectionList[jobIdx] < 1)
            {
                CollectionManager.CM.collectiondata.collectionList[jobIdx] = 1; // 배드엔딩 
                CollectionManager.CM.SaveCollection();
            }

        }
        else if (fa <= 0.8f)
        {
            ending_s.SetActive(true);
            t.text = player_name + "은(는) 그럭저럭한 인생을 살았다!";
            if (CollectionManager.CM.collectiondata.collectionList[jobIdx] < 2)
            {
                CollectionManager.CM.collectiondata.collectionList[jobIdx] = 2; // 노말엔딩
                CollectionManager.CM.SaveCollection();
            }


        }
        else
        {
            ending_g.SetActive(true);
            t.text = player_name + "은(는) 완벽한 인생을 살았다!";
            if (CollectionManager.CM.collectiondata.collectionList[jobIdx] < 3)
            {
                CollectionManager.CM.collectiondata.collectionList[jobIdx] = 3; // 해피엔딩
                CollectionManager.CM.SaveCollection();
            }

        }

    }

    public void left_arrow()
    { // 왼쪽 버튼 클릭
        clicked_arrow = 0;
        if (!minigameEnd) minigame_check();
    }
    public void down_arrow()
    { // 아래 버튼 클릭
        clicked_arrow = 1;
        if (!minigameEnd) minigame_check();
    }
    public void up_arrow()
    { // 위 버튼 클릭
        clicked_arrow = 2;
        if (!minigameEnd) minigame_check();
    }
    public void right_arrow()
    { // 오른쪽 버튼 클릭
        clicked_arrow = 3;
        if (!minigameEnd) minigame_check();
    }

    public void minigame_check()
    { // 맞게 입력됐는지 체크 
        if (minigame_arrow_list[minigame_arrrow_index] == clicked_arrow)
        { // 맞게 입력됨 && 미니게임이 끝나지 않았을 때 
            Debug.Log("OK");
            minigame_sprite[minigame_arrrow_index].GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            if (minigame_arrrow_index == 7)
            { // 8번 모두 성공
                minigameEnd = true; // 미니게임 끝
                successMessage.SetActive(true); // 성공 메세지 
                Gauge gauge = GameObject.Find("Player").GetComponent<Gauge>();
                if(gauge.achieve_gauge>=80) gauge.achieve_gauge = 100;
                else gauge.achieve_gauge += 20;
                StartCoroutine(Minigame_Delay());

            }
            else if (minigame_arrrow_index < 7)
            {
                minigame_arrrow_index++; // 다음 순서 진행 
            }
        }
        else
        { // 틀리게 입력됨 
            minigameEnd = true; // 미니게임 끝
            minigameFailed = true; // 미니게임 실패 
            failMessage.SetActive(true); // 실패 메세지  
            Gauge gauge = GameObject.Find("Player").GetComponent<Gauge>();
            if(gauge.achieve_gauge<20) gauge.achieve_gauge = 0;
            else gauge.achieve_gauge -= 20;
            StartCoroutine(Minigame_Delay());

        }
    }

    public void start_minigame() // 미니게임 시작 
    {
        minigameCanvas.SetActive(true);
        jumpButton.GetComponent<Button>().interactable = false; // 점프 버튼 비활성화
        slideButton.GetComponent<Button>().interactable = false; // 슬라이드 버튼 비활성화 
        pauseButton.GetComponent<Button>().interactable = false; // 일시정지 버튼 비활성화 
        Time.timeScale = 0;
        StartCoroutine(Minigame_timecheck()); // 초 세기 시작 
        for (int i = 0; i < 8; i++)
        {
            // 0: 왼쪽 1: 아래 2:위 3: 오른쪽 
            int arrow = Random.Range(0, 4);
            minigame_arrow_list.Add(arrow); // 0 ~ 3 랜덤으로 배열에 넣기
            minigame_sprite[i].GetComponent<Image>().sprite = arrow_sprite[arrow]; // 미니게임 창의 화살표 이미지도 바꾸기
        }
    }

    public void pause()
    {// 일시정지
        if (!isPause)
        {
            pauseButton.GetComponent<Image>().sprite = playSprite; // 이미지 변경
            jumpButton.GetComponent<Button>().interactable = false; // 점프 버튼 비활성화
            slideButton.GetComponent<Button>().interactable = false; // 슬라이드 버튼 비활성화 
            pauseMessage.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        else
        { // 다시 누르면 시작 
            pauseButton.GetComponent<Image>().sprite = pauseSprite;
            jumpButton.GetComponent<Button>().interactable = true;
            slideButton.GetComponent<Button>().interactable = true;
            pauseMessage.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
    }
}

// 각 스테이지 길이에 대한 정보를 담는 class
public class AgeInfo
{
    public int period; // 각 스테이지 별 나이
    public float time; // 각 스테이지 별 시간
    public AgeInfo(int p, float t)
    {
        period = p;
        time = t;
    }
}

public class Stage3
{
    public Sprite img;
    public int state;
    public Stage3(Sprite i, int s)
    {
        img = i;
        state = s;
    }
}

[System.Serializable]
// 각 직업에 대한 수치 정보를 담는 class
public class Gauge2Info
{
    // 0: 창의력, 1: 논리력, 2: 암기력, 3: 지구력, 4: 집중력, 5: 주도력
    public List<int> childGauge = new List<int>();

    // 0: 예술, 1: 이과 공부, 2: 문과 공부, 3: 컴퓨터, 4: 운동, 5: 발표, 6: 사회성
    public List<int> studentGauge = new List<int>();
    public string job;
    public bool get; // 이 직업 해금 여부
    public Gauge2Info(string inputjob)
    {
        job = inputjob;
        get = false;
        for (int i = 0; i <= 5; i++)
        {
            childGauge.Add(int.Parse(GameManager.data[i][inputjob].ToString()));
        }
        for (int i = 6; i < 13; i++)
        {
            studentGauge.Add(int.Parse(GameManager.data[i][inputjob].ToString()));
        }
    }
}



