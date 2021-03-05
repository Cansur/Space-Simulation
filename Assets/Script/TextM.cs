using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextM : MonoBehaviour
{
    DB db;
    public Text textMoney;
    public Text textPerSec;
    //bool starting = true;
    bool isPerSec0 = false;
    //int fakeMoney;
    Coroutine verCount;
    void Start()
    {
        //verCount = StartCoroutine(Count((float)(money + per1sec), (float)money));
        //StartCoroutine(Count((float)(money + per1sec), (float)money));
        //perSec.text = string.Format(per1sec.ToString() +"<color=#C3C1BD>"+ "/sec" + "</color>");
        //perSec.text = string.Format("{0:#,###}", per1sec.ToString());
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        db.Money += 1;
        verCount = StartCoroutine(Count((float)(db.Money + db.Per1sec), (float)db.Money));
        textMoney.text = string.Format("{0:#,###}", db.Money);
        //Parsing();
    } 
    void Update()
    {
        if(db.Per1sec != 0) 
        { 
            textPerSec.text = string.Format("{0:#,###}"+"<color=#C3C1BD>"+ "/sec" + "</color>", db.TotalPerSec);
        }
        else { textPerSec.text = "0" + "<color=#C3C1BD>"+ "/sec" + "</color>";}

        /* if(db.Per1sec != 0 && starting)
        {
            verCount = StartCoroutine(Count((float)(db.Money + db.Per1sec), (float)db.Money));
            starting = false;
        }
        else { moneyText.text = "0";} */
        //if(Input.GetKeyDown(KeyCode.R)) { Parsing(); }
        //if( isPerSec0 == true && db.Per1sec != 0) { StopAllCoroutines(); isPerSec0 = false; verCount = StartCoroutine(Count((float)(db.Money + (int)(db.TotalPerSec*0.5)), (float)db.Money)); }
        if( isPerSec0 == true && db.Per1sec != 0) { StopAllCoroutines(); isPerSec0 = false; verCount = StartCoroutine(Count((float)(db.Money + db.TotalPerSec), (float)db.Money)); }
        //if(db.Money == 0) { moneyText.text = "0"; }
    }

    IEnumerator Count(float target, float current)
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
    }

    void Parsing()
    {
        //money = db.Money;
        //per1sec = db.Per1sec;
    }
}
