using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextM : MonoBehaviour
{
    DB db;
    public Text textMoney;
    public Text textPerSec;
    //bool isPerSec0 = false;
    //Coroutine verCount;
    Coroutine verCoroutiune;

    //float timer;
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        //db.Money = 100;
        //verCount = StartCoroutine(Count((float)(db.Money + db.Per1sec), (float)db.Money));
        StartCoroutine(CountA(db.Money+db.TotalPerSec, db.Money));
    } 
    void Update()
    {
        if(db.Per1sec != 0) 
        { 
            textPerSec.text = string.Format("{0:#,###}"+"<color=#C3C1BD>"+ "/sec" + "</color>", db.TotalPerSec);
        }
        else { textPerSec.text = "0" + "<color=#C3C1BD>"+ "/sec" + "</color>";}
        //if(db.Money == 0) { textMoney.text = "0"; }
        //if( isPerSec0 == true && db.Per1sec != 0) { StopAllCoroutines(); isPerSec0 = false; verCount = StartCoroutine(Count((float)(db.Money + db.TotalPerSec), (float)db.Money)); }
        //timer += Time.deltaTime;
    }

    /* IEnumerator Count(float target, float current)
    {
        if(db.Per1sec == 0) { isPerSec0 = true; yield break; }
        //int sumAB = db.Money + db.TotalPerSec;
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정.
        //if(db.TotalPerSec < 6) { duration = 1f; }
        float offset = (target - current) / duration; //
        while (current < target)
        {
            current += offset * Time.deltaTime;
            textMoney.text = string.Format("{0:#,###}", (int)(current));
            if(db.Money == 0) { textMoney.text = "0"; }
            //if(var > db)
            yield return null;
        }
        current = target;
        //Debug.Log(db.TotalPerSec);
        db.Money += db.TotalPerSec;
        StartCoroutine(Count((int)(db.Money + db.TotalPerSec), (int)db.Money));
    } */
    IEnumerator CountA(long target, long current)
    {
        if(target == current) 
        {
            textMoney.text = string.Format("{0:#,###}", db.Money);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(CountA(db.Money+db.TotalPerSec, db.Money));
            //Debug.Log(timer + "리셋");
            //timer = 0;
        }
        else
        {
            long var = (target - current) / 10;
            for (int i = 0; i < 10; i++)
            {
                current += var;
                db.Money += var;
                textMoney.text = string.Format("{0:#,###}", db.Money);
                yield return new WaitForSeconds(0.08f);
            }
            current = target;
            //if(db.Money != target) { Debug.Log("어,, 다르네");}
            StartCoroutine(CountA(db.Money+db.TotalPerSec, db.Money));
            /* long var = (target - current) / 100; // totalpersec 1000 이상
            for (int i = 0; i < 100; i++)
            {
                current += var;
                db.Money += var;
                textMoney.text = string.Format("{0:#,###}", db.Money);
                yield return new WaitForSeconds(0.0001f);
            } */
            //Debug.Log(timer + "리셋");
            //timer = 0;
            
        }
    }

    void Restart()
    {
        //StartCoroutine(verCoroutiune);
    }
}
