using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestA : MonoBehaviour
{
    public Text qqwe;
    public Text textTimer;
    [SerializeField] long var = 1000;
    [SerializeField] long var1 = 99;
    [SerializeField] long varpersec = 100;
    float timer;
    //bool var3 = true;
    
    void Start()
    {
        //StartCoroutine(Count(var, var1));
        StartCoroutine(CountA(var1+varpersec, var1));
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
        StartCoroutine(Count(var, var1));
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            //var3 = true;
        StartCoroutine(CountA(var1+varpersec, var1));
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
        timer = 0;
        }
        Timer();
    }
    IEnumerator Count(float target, float current)
    {
        float duration = 0.5f; // 카운팅에 걸리는 시간 설정.
        float offset = (target - current) / duration; //
        while (current < target)
        {
            current += offset * Time.deltaTime;
            qqwe.text = string.Format("{0:#,###}", (long)(Mathf.Round(current)));
            yield return null;
        }
        current = target;
        //StartCoroutine(Count());
    }

    // 
    IEnumerator CountA(long target, long current)
    {
        timer = 0;
        long var2 = (target - current) / 10;
        for (int i = 0; i < 10; i++)
        {
            current += var2;
            var1 += var2;
            qqwe.text = var1.ToString();
            yield return new WaitForSeconds(0.08f);
        }
        current = target;
        textTimer.text = timer.ToString();
        //Debug.Log(timer);
        //StartCoroutine(CountA(var1+varpersec, var1));
    }

    void Timer()
    {
        timer += Time.deltaTime;
        //if(var3 == true)
        //textTimer.text = timer.ToString();
    }
    public void OnClick1()
    {
        StartCoroutine(CountA(900, 0));
    }
}
