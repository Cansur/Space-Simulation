﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GStoneM : MonoBehaviour
{
    DB db;
    public GameObject panelGStone;
    public Text textCount;
    public Text textPt;
    public Text textPricePt;
    public Text textPricePt2;
    int var = 0;
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
    }
    void Update()
    {
        TextPt();
    }

    public void OnClickEasy()
    {
        bool var1 = panelGStone.activeSelf == true ? false : true;
        panelGStone.SetActive(var1);
        UpdateText();
    }

    public void OnClickEasyYes()
    {
        if(db.Pt >= db.PriceGStone(db.gStoneCount))
        {
            if(db.gStoneCount == 0)
            {
                db.gStone[0] = true;
                db.Pt -= db.PriceGStone(db.gStoneCount);
                panelGStone.SetActive(false);
            }
            else if(1 <= db.gStoneCount && 10 >= db.gStoneCount)
            {
                int var1 = Random.Range(1, 9); // 수호석 1번쨰는 인덱스 번호 0임
                Debug.Log(var1);
                if(db.gStone[var1] == false)
                {
                    db.gStone[var1] = true;
                    db.Pt -= db.PriceGStone(db.gStoneCount);
                    panelGStone.SetActive(false);
                }
                else { OnClickEasyYes(); }
            }
            else if(11 <= db.gStoneCount && 20 >= db.gStoneCount)
            {
                int var1 = Random.Range(10, 19); // 수호석 1번쨰는 인덱스 번호 0임
                db.gStone[var1] = true;
                db.Pt -= db.PriceGStone(db.gStoneCount);
                panelGStone.SetActive(false);
            }
            UpdateText();
        }
    }

    public void UpdateText()
    {
        for (int i = 0; i < db.gStone.Length; i++) // 수호석 몇개인지 확인
        {
            if(db.gStone[i] == true) { var++; }
        }
        db.gStoneCount = var;
        TextCount();
        //TextPt();
        TextPricePt();
        var = 0;
    }

    void TextCount()
    {
        textCount.text = string.Format("수호석 [" + var + "/" + db.gStone.Length + "]");
    }
    void TextPt()
    {
        if(db.Pt == 0) { textPt.text = string.Format("0" + " Pt"); }
        else
        {
            textPt.text = string.Format("{0:#,###}" + " Pt", db.Pt);
        }
    }
    void TextPricePt()
    {
        textPricePt.text = string.Format("비용 : " + "<color=#DBD560>" + "{0:#,###}" + " Pt" + "</color>", db.PriceGStone(var));
        textPricePt2.text = string.Format("비용 : " + "<color=#DBD560>" + "{0:#,###}" + " Pt" + "</color>", db.PriceGStone(var));
    }
}
