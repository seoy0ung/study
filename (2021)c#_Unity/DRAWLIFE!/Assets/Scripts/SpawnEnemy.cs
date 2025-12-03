using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    //public float Spawntime = 2f;//스폰타임도 랜덤으로 해서 계속 변화를 줘야할듯...
    void Start()
    {
        StartCoroutine(SpawnE());
        StartCoroutine(SpawnI());
    }


    IEnumerator SpawnE() //장애물 생성 코루틴
    {
        yield return new WaitForSeconds(2);

        while(true)
        {
            int WhatEnemy=0;
            int WhereY = Random.Range(1, 3);//장애물이 어디있는가?(위쪽 아래쪽)
            int WhatItem = Random.Range(0, 2);//어떤 아이템을 스폰할것인가?(GameManager.GM.Items에서 받음)
            int SpawnItem = Random.Range(0, 2);//아이템 생성확률(일단 50%로 잡음)
          

            float Spawntime = Random.Range(0.8f, 1.5f);//근데 통과할 수 있게 장애물이 나와야하긴하는데..

            int onlyItem = Random.Range(0, 5);
            switch(GameManager.GM.nstate){
                case 0: // 유아기
                    if(GameManager.GM.age<3){ // 1~2살일 때 장애물 패턴 
                    WhatEnemy = Random.Range(0, 2);
                    }
                    else if(GameManager.GM.age>=3 && GameManager.GM.age<=5){ // 3~5살일 때 장애물 패턴 
                        WhatEnemy = Random.Range(0, 4);
                    }
                    else if(GameManager.GM.age>=6){ // 6~7살일 때 장애물 패턴 
                        WhatEnemy = Random.Range(0, 7);
                    }            

                    if(GameManager.GM.age < 4 && onlyItem < 2){ // 3살 이하일때 40%로 장애물 없이 아이템만 나오게
                        continue;
                    }
                    else{ // 장애물+아이템으로 나오게 
                        if (WhatEnemy == 2||WhatEnemy == 4) // 3번, 5번 장애물은 위에 나오도록 고정
                        {
                            WhereY = 1;
                        }
                        else if (WhatEnemy == 5) // eneny6은 spawntime 조금 길게
                        {
                            Spawntime += 0.6f;
                        }
                        else if(WhatEnemy == 6){ // eneny7은 spawntime 조금 길게
                            Spawntime += 0.9f;
                        }
                        else if(WhatEnemy == 3){
                            Spawntime += 0.2f;
                        }

                        if (WhereY == 1)//위에 생성
                        {
                            Instantiate(GameManager.GM.hurdles[WhatEnemy], new Vector3(10, 1.8f, 0), new Quaternion(0, 0, 0, 0));
                        }
                        else//아래에 생성
                        {
                            Instantiate(GameManager.GM.hurdles[WhatEnemy], new Vector3(10, -3.6f, 0), Quaternion.Euler(180, 0, 0));
                            if(GameManager.GM.nstate==0){ // 유아기때는 아이템이 한개
                                WhatItem = 0;
                            }
                        }   
                    }
                    break;

                case 1: // 유년기
                    yield return new WaitForSeconds(GameManager.GM.child.time + 5f);
                    break;

                case 2: // 학생기
                    WhatEnemy = Random.Range(0, 7);
                    if (WhatEnemy == 2||WhatEnemy == 4) // 3번, 5번 장애물은 위에 나오도록 고정
                            WhereY = 1;
                    else if (WhatEnemy == 5) // eneny6은 spawntime 조금 길게
                            Spawntime += 0.6f;
                    else if(WhatEnemy == 6) // eneny7은 spawntime 조금 길게
                            Spawntime += 0.9f;
                    else if(WhatEnemy == 3)
                            Spawntime += 0.2f;

                    if (WhereY == 1)//위에 생성
                    {
                        float nu;
                        GameObject ene = Instantiate(GameManager.GM.hurdles[WhatEnemy], new Vector3(10, 1.8f, 0), new Quaternion(0, 0, 0, 0));
                        if(WhatEnemy == 6 || WhatEnemy == 3) nu = 0;
                        else nu = Random.Range(0f, 2.2f); // 높이 랜덤
                        if(ene.transform.childCount == 0){ // 장애물에 자식 없으면,
                            int n = Random.Range(0,4);
                            // 높이 랜덤
                            ene.transform.position += new Vector3(0, nu, 0);
                            // sprite 지정
                            ene.GetComponent<SpriteRenderer>().sprite = GameManager.GM.realItems_stag3[n].img;
                            // 프리팹에 수치 넘겨주기
                            ene.GetComponent<ItemSetting>().SSetting(GameManager.GM.realItems_stag3[n].state);
                            // tag 지정
                            if(GameManager.GM.realItems_stag3[n].state > 0) ene.tag = "ITEMPLUS";
                            else ene.tag = "ITEMMINUS";
                            // n.setting()
                        } else{
                            for(int i = 0; i < ene.transform.childCount ; i++){
                                if(WhatEnemy == 6 || WhatEnemy == 3) nu = 0;
                                else nu = Random.Range(0f, 2.2f); // 높이 랜덤
                                int n = Random.Range(0,4);
                                ene.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = GameManager.GM.realItems_stag3[n].img;
                                ene.transform.GetChild(i).GetComponent<ItemSetting>().SSetting(GameManager.GM.realItems_stag3[n].state);
                                ene.transform.GetChild(i).transform.position += new Vector3(0, nu, 0);
                                if(GameManager.GM.realItems_stag3[n].state > 0) ene.transform.GetChild(i).tag = "ITEMPLUS";
                                else ene.transform.GetChild(i).tag = "ITEMMINUS";
                                // n.setting()
                            }
                        }
                        Debug.Log(ene.transform.childCount);
                    }
                    else//아래에 생성
                    {
                        GameObject ene = Instantiate(GameManager.GM.hurdles[WhatEnemy], new Vector3(10, -3.6f, 0), Quaternion.Euler(180, 0, 0));
                        if(ene.transform.childCount == 0){ // 장애물에 자식 없으면,
                            int n = Random.Range(0,4);
                            ene.GetComponent<SpriteRenderer>().sprite = GameManager.GM.realItems_stag3[n].img;
                            ene.GetComponent<ItemSetting>().SSetting(GameManager.GM.realItems_stag3[n].state);
                            if(GameManager.GM.realItems_stag3[n].state > 0) ene.tag = "ITEMPLUS";
                            else ene.tag = "ITEMMINUS";
                            // n.setting()
                        } else{
                            for(int i = 0; i < ene.transform.childCount ; i++){
                                int n = Random.Range(0,4);
                                ene.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = GameManager.GM.realItems_stag3[n].img;
                                ene.transform.GetChild(i).GetComponent<ItemSetting>().SSetting(GameManager.GM.realItems_stag3[n].state);
                                if(GameManager.GM.realItems_stag3[n].state > 0) ene.transform.GetChild(i).tag = "ITEMPLUS";
                                else ene.transform.GetChild(i).tag = "ITEMMINUS";
                                // n.setting()
                            }
                        }
                    }
                    break;
                case 3:
                    WhatEnemy = Random.Range(0, 7);

                    if (WhatEnemy == 2 || WhatEnemy == 4) // 3번, 5번 장애물은 위에 나오도록 고정
                    {
                        WhereY = 1;
                    }
                    else if (WhatEnemy == 5) // eneny6은 spawntime 조금 길게
                    {
                        Spawntime += 0.6f;
                    }
                    else if (WhatEnemy == 6) // eneny7은 spawntime 조금 길게
                    { 
                        Spawntime += 0.9f;
                    }
                    else if (WhatEnemy == 3)
                    {
                        Spawntime += 0.2f;
                    }

                    if (WhereY == 1) //위에 생성
                    {
                        GameObject ene = Instantiate(GameManager.GM.hurdles[WhatEnemy], new Vector3(10, 1.8f, 0), new Quaternion(0, 0, 0, 0));
                        if(ene.transform.childCount == 0){ // 장애물에 자식 없으면,
                            // sprite 지정
                            // tag 지정
                            ene.tag = "ENEMYADULT";
                        } else{
                            for(int i = 0; i < ene.transform.childCount ; i++){
                                // sprite 지정
                                // tag 지정
                                ene.transform.GetChild(i).tag = "ENEMYADULT";
                            }
                        }
                    }
                    else //아래에 생성
                    {
                        GameObject ene = Instantiate(GameManager.GM.hurdles[WhatEnemy], new Vector3(10, -3.6f, 0), Quaternion.Euler(180, 0, 0));
                        if(ene.transform.childCount == 0){ // 장애물에 자식 없으면,
                            // sprite 지정
                            // tag 지정
                            ene.tag = "ENEMYADULT";
                        } else{
                            for(int i = 0; i < ene.transform.childCount ; i++){
                                // sprite 지정
                                // tag 지정
                                ene.transform.GetChild(i).tag = "ENEMYADULT";
                            }
                        }
                    }
                    break;

            }

            yield return new WaitForSeconds(Spawntime);//일정시간이 아닌 랜덤한 주기로 소환
            
            if(GameManager.GM.stage_end){
                yield return new WaitForSeconds(4);
            }
        }

        //yield return null;
    }

    IEnumerator SpawnI(){ // 아이템 생성 코루틴 
        yield return new WaitForSeconds(2);

        while(true){

            int WhatItem = Random.Range(0, 2); //어떤 아이템을 스폰할것인가?(GameManager.GM.Items에서 받음)
            int SpawnItem = Random.Range(0, 2); //아이템 생성확률(일단 50%로 잡음)
            float Spawntime = Random.Range(0.4f, 0.8f); 

            if(GameManager.GM.nstate == 0){ // 유아기때는 아이템 종류가 한개
                WhatItem = 0;
            } else if(GameManager.GM.nstate == 1){ // 유년기때는 아이템 종류가 6개
                WhatItem = Random.Range(0, 4);
            } else if(GameManager.GM.nstate == 2){ // 학생기때는 감정 아이템만 나옴 
                WhatItem = 0;
                Spawntime = 5; // 5초 간격 
            } else if(GameManager.GM.nstate == 3){ // 성인기 때 감정 아이템 5초 간격, 성취도 아이템 4초 간격
                WhatItem = 0;
                Spawntime = 4;
                StartCoroutine(SpawnAdult());
            }
            SpawnWhere(WhatItem, SpawnItem);

            yield return new WaitForSeconds(Spawntime);//일정시간이 아닌 랜덤한 주기로 소환(장애물보다 생성 주기 짧게)
            
            if(GameManager.GM.stage_end){
                yield return new WaitForSeconds(4);
            }
        }
    }

    // IEnumerator SpawnEmotionI(){ // 감정아이템 생성 코루틴 
    //     while(true){
    //         float Spawntime = 5;
    //         int SpawnItem = Random.Range(0, 2); //아이템 생성확률(일단 50%로 잡음)
    //         SpawnWhere(0, SpawnItem);

    //        yield return new WaitForSeconds(Spawntime);//일정시간이 아닌 랜덤한 주기로 소환(장애물보다 생성 주기 짧게)
            
    //         if(GameManager.GM.stage_end){
    //             yield return new WaitForSeconds(4);
    //         }
    //     }
        
    // }

    /*
    void SpawnItemup(int what, int chance)//어떤 아이템을, 50%확률로 위에 소환
    {
        if (chance == 0)//0 or 1중에 0이 나오면
        {
            Instantiate(GameManager.GM.Items_stage1[what], new Vector3(10, 1, 0), new Quaternion(0, 0, 0, 0));
            //게임매니저에 저장되어 있는 아이템 목록중에 랜덤으로 뽑힌 숫자번째의 항목을 생성
        }
    }
    void SpawnItemdown(int what, int chance)
    {
        if (chance == 0)//0 or 1중에 0이 나오면
        {
            Instantiate(GameManager.GM.Items_stage1[what], new Vector3(10, -2, 0), new Quaternion(0, 0, 0, 0));
            //게임매니저에 저장되어 있는 아이템 목록중에 랜덤으로 뽑힌 숫자번째의 항목을 생성
        }
    }
    */
    void SpawnWhere(int what, int chance)//랜덤으로 아이템 소환
    {

            float WhereItem = Random.Range(-2f, 0.6f);
            switch(GameManager.GM.nstate){
                case 0: // 유아기 ~ 감정 + 
                    Instantiate(GameManager.GM.Items_stage1[what], new Vector3(10, WhereItem, 0), new Quaternion(0, 0, 0, 0));
                    break;
                case 1: // 유년기 ~ 성취도 +-
                    Instantiate(GameManager.GM.realItems_stage2[what], new Vector3(10, WhereItem, 0), new Quaternion(0, 0, 0, 0));
                    break;
                case 2: // 학생기 ~ 감정 +
                    Instantiate(GameManager.GM.EmotionItem, new Vector3(10, WhereItem, 0), new Quaternion(0, 0, 0, 0));
                    break;
                case 3: // 성인기 ~ 감정 + & 성취도 +
                    Instantiate(GameManager.GM.Item_adult, new Vector3(10, WhereItem, 0), new Quaternion(0, 0, 0, 0));
                    break;

            }

    }

    IEnumerator SpawnAdult()
    {
        float WhereItem = Random.Range(-2f, 0.6f);
        yield return new WaitForSeconds(1f);
        Instantiate(GameManager.GM.EmotionItem, new Vector3(10, WhereItem, 0), new Quaternion(0, 0, 0, 0));
    }
}
