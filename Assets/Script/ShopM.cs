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
        //StartDownTextAether();
        //UpColorProduceAether();
        //DownTextCountProduceAether();
        //TextNeedMoneyBuyProduceAetherUpdate();
    }

    void Update()
    {
        UpColorProduceAether();
    }

    #region 에테르채집상점

    public void OnCilck1(int var) // 제 2에테르 생산소 : var = 1
    {
        int var1 = db.CountProduceAether(var); // var = 1 이면 var1 은 0
        if(db.NeedMoneyBuyProduceAether(var, var1) <= db.Money)

        {
            //if(var == 1){Debug.Log("야호");}
            db.Money -= db.NeedMoneyBuyProduceAether(var, var1);
            db.CountProduceAether(var, db.CountProduceAether(var)+1); 
            db.Per1sec += db.PerProduceAether(var, var1); // 더하기
            db.SumTotalPerSec();
            TextNeedMoneyBuyProduceAetherUpdate(var, var1);
            DownTextEffectProduceAether(var);
            DownColorProduceAether(var);
            DownTextCountProduceAether(var);
        }
    } 
    public void Oncilck2(int var)
    {
        int var1 = db.CountProduceAether(var); // var = 1 이면 var1 은 0
        if(db.NeedMoneyBuyProduceAether(var, var1) <= db.Money)
        {
            db.Money -= db.NeedMoneyBuyProduceAether(var, var1);
            db.CountProduceAether(var, db.CountProduceAether(var)+1); // 1, 1
            
            db.SumTotalPerSec();
            DownTextEffectProduceAether(var);
            TextNeedMoneyBuyProduceAetherUpdate(var, var1);
            DownColorProduceAether(var);
            DownTextCountProduceAether(var);
        }
    }
   

    void UpColorProduceAether()
    {
        for (int i = 0; i < 3; i++)
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
        db.NeedMoneyBuyProduceAether(0, 0, 100);
        db.NeedMoneyBuyProduceAether(0, 1, 200);
        db.NeedMoneyBuyProduceAether(0, 2, 300);
        db.NeedMoneyBuyProduceAether(0, 3, 500);
        db.NeedMoneyBuyProduceAether(0, 4, 600);
        db.NeedMoneyBuyProduceAether(0, 5, 700);
        db.NeedMoneyBuyProduceAether(0, 6, 800);
        db.NeedMoneyBuyProduceAether(0, 7, 100000000);
        db.NeedMoneyBuyProduceAether(1, 0, 200);
        db.NeedMoneyBuyProduceAether(1, 1, 300);
        db.NeedMoneyBuyProduceAether(1, 2, 400);
        db.NeedMoneyBuyProduceAether(1, 3, 100000000);
        db.NeedMoneyBuyProduceAether(2, 0, 1000);
        db.NeedMoneyBuyProduceAether(2, 1, 10000);
        db.NeedMoneyBuyProduceAether(2, 1, 100000000);
        db.PerProduceAether(0, 0, 10); // 더하기
        db.PerProduceAether(0, 1, 10);
        db.PerProduceAether(0, 2, 10);
        db.PerProduceAether(0, 3, 10);
        db.PerProduceAether(0, 4, 10);
        db.PerProduceAether(0, 5, 10);
        db.PerProduceAether(0, 6, 10);
        db.PerProduceAether(0, 7, 10);
        db.PerProduceAether(1, 0, 1); // 곱하기
        db.PerProduceAether(1, 1, 2);
        db.PerProduceAether(1, 2, 3);
        db.PerProduceAether(1, 3, 4);
        db.PerProduceAether(1, 4, 5);
        db.PerProduceAether(2, 0, 1);
        db.PerProduceAether(2, 1, 2);
        db.PerProduceAether(2, 2, 3);
        StartDownTextAether();
        //TextNeedMoneyBuyProduceAetherUpdate();
    }
    // 문제 있고
    void TextNeedMoneyBuyProduceAetherUpdate(int var, int var1) 
    { 
        db.textNeedMoneyBuyProduceAether[var].text = string.Format("{0:#,###}", db.NeedMoneyBuyProduceAether(var, var1+1));
    }
    /* void TextNeedMoneyBuyProduceAetherUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            int var = db.CountProduceAether(i);
            //db.textNeedMoneyBuyProduceAether[i].text = db.NeedMoneyBuyProduceAether(i, var).ToString();
            db.textNeedMoneyBuyProduceAether[i].text = string.Format("{0:#,###}", db.NeedMoneyBuyProduceAether(i, var));
        }
    } */
    void DownTextCountProduceAether(int var)
    {
        if(db.CountProduceAether(var) == 0) { db.textCountProduceAether[var].text = ""; }
        else 
        {
            db.textCountProduceAether[var].text = string.Format("("+"{0:#,###}"+")", db.CountProduceAether(var));
        }
    }
    /* void DownTextCountProduceAether()
    {
        for (int i = 0; i < 3; i++)
        {
            if(db.CountProduceAether(i) == 0) { db.textCountProduceAether[i].text = ""; }
            else { db.textCountProduceAether[i].text = string.Format("("+"{0:#,###}"+")", db.CountProduceAether(i)); }
        }
    } */
    void DownTextEffectProduceAether(int var)
    {
        int var1 = db.CountProduceAether(var);
        if(var == 0) 
        {
            db.textEffectProduceAether[var].text = string.Format("+ " + db.PerProduceAether(var, var1 + 1) + "/sec");
        }
        else
        {
            db.textEffectProduceAether[var].text = string.Format("제 " + var + "에테르 생산소 x " + db.PerProduceAether(var, var1 + 1));
        }
    }

    void StartDownTextAether()
    {
        for (int i = 0; i < 3; i++)
        {
            int var = db.CountProduceAether(i);
            TextNeedMoneyBuyProduceAetherUpdate(i, var - 1);
            DownTextCountProduceAether(i);
            DownTextEffectProduceAether(i);
        }
        UpColorProduceAether();
    }

    #endregion

}
