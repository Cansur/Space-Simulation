using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopM : MonoBehaviour
{
    DB db;
    [SerializeField]
    Image[] colorProduceAetherButton = new Image[4];
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        TestD();
        UpColorProduceAether();
        //TextNeedMoneyBuyProduceAetherUpdate();
    }

    public void OnCilck1(int var) // 제 2에테르 생산소 : var = 1
    {
        int var1 = db.CountProduceAether(var); // var = 1 이면 var1 은 0
        if(db.NeedMoneyBuyProduceAether(var, var1) <= db.Money)
        {
            //if(var == 1){Debug.Log("야호");}
            db.Money -= db.NeedMoneyBuyProduceAether(var, var1);
            db.CountProduceAether(var, db.CountProduceAether(var)+1); // 1, 1
            db.Per1sec += db.PerProduceAether(0, 0);
            db.SumTotalPerSec();
            TextNeedMoneyBuyProduceAetherUpdate(var, var1);
            DownColorProduceAether(var);
        }
    } 
    void Update()
    {
        UpColorProduceAether();
    }

    void UpColorProduceAether()
    {
        for (int i = 0; i < 2; i++)
        {
            if(db.Money >= db.NeedMoneyBuyProduceAether(i, db.CountProduceAether(i))) 
            {
                if(colorProduceAetherButton[i].color == new Color(231/255f, 115/255f, 103/255f))
                {
                    colorProduceAetherButton[i].color = new Color(103/255f, 231/255f, 107/255f);
                }
            }
            else if(db.Money < db.NeedMoneyBuyProduceAether(i, db.CountProduceAether(i)))
            {
                if(colorProduceAetherButton[i].color == new Color(103/255f, 231/255f, 107/255f))
                {
                    colorProduceAetherButton[i].color = new Color(231/255f, 115/255f, 103/255f);
                }
            }
        }
    }
    void DownColorProduceAether(int var)
    {
        if(db.Money < db.NeedMoneyBuyProduceAether(var, db.CountProduceAether(var)))
        {
            colorProduceAetherButton[var].color = new Color(231/255f, 115/255f, 103/255f);
        }
    }

    void TestD()
    {
        for (int i = 0; i < 4; i++)
        {
            colorProduceAetherButton[i] = db.goProduceAetherButton[i].GetComponent<Image>();
        }
        //colorProduceAetherButton[0].color = new Color(231/255f, 115/255f, 103/255f);
        //colorProduceAetherButton[0] = new Color(1, 1, 1); 
        
        db.NeedMoneyBuyProduceAether(0, 0, 1);
        db.NeedMoneyBuyProduceAether(0, 1, 5);
        db.NeedMoneyBuyProduceAether(0, 2, 10);
        db.NeedMoneyBuyProduceAether(0, 3, 20);
        db.NeedMoneyBuyProduceAether(0, 4, 100);
        db.NeedMoneyBuyProduceAether(0, 5, 1000);
        db.NeedMoneyBuyProduceAether(1, 0, 20);
        db.NeedMoneyBuyProduceAether(1, 1, 10000);
        db.PerProduceAether(0, 0, 1);
        db.PerProduceAether(0, 1, 1);
        db.PerProduceAether(0, 2, 1);
        db.PerProduceAether(0, 3, 1);
        db.PerProduceAether(0, 4, 1);
        db.PerProduceAether(0, 5, 1);
        db.PerProduceAether(1, 0, 2);
        db.PerProduceAether(1, 1, 4);
        TextNeedMoneyBuyProduceAetherUpdate();
    }
    // 문제 있고
    void TextNeedMoneyBuyProduceAetherUpdate(int var, int var1) { db.textNeedMoneyBuyProduceAether[var].text = db.NeedMoneyBuyProduceAether(var, var1+1).ToString(); }
    void TextNeedMoneyBuyProduceAetherUpdate()
    {
        for (int i = 0; i < 2; i++)
        {
            int var = db.CountProduceAether(i);
            db.textNeedMoneyBuyProduceAether[i].text = db.NeedMoneyBuyProduceAether(i, var).ToString();
        }
    }
}
