using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthM : MonoBehaviour
{
    DB db;
    ShopM shopM;


    public GameObject panelRebirth;
    public Text textTotalPt;
    float var;
    float var1;
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        shopM = GameObject.FindWithTag("ShopM").GetComponent<ShopM>();
    }

    public void OnClickEasy()
    {
        var = Mathf.Floor(db.TotalPerSec / 10000);
        var1 = (float)db.gStoneUpgradeEffect[1][db.gStoneUpgradeCount[1]]/10;
        bool ispanelRebirth = panelRebirth.activeSelf == false ? true : false;
        panelRebirth.SetActive(ispanelRebirth);
        if(var == 0) { textTotalPt.text = string.Format("총 " + "<color=#DBD560>" + "0" + "Pt" + "</color>" + "를 획득합니다."); }
        else
        {
            textTotalPt.text = string.Format("총 " + "<color=#DBD560>" + "{0:#,###}" + "Pt" + "</color>" + "를 획득합니다.", var*(1+var1));
        }
    }

    public void OnClickEasyYes()
    {
        RebirhEasy();
        panelRebirth.SetActive(false);
        db.backGround[2].SetActive(false);
        db.Pt += (long)(var*(1+var1));
    }

    void RebirhEasy()
    {
        db.Per1sec = 0;
        db.TotalPerSec = 0;
        db.isAetherStop = true;
        db.SumTotalPerSec();
        for (int i = 0; i < 6; i++)
        {
            db.IsProduceAether(i, false);
            db.CountProduceAether(i, 0);
            db.goProduceAether[i].SetActive(false);
        }
        shopM.StartDownTextAether();
        for (int i = 0; i < 3; i++) 
        { 
            db.isUnlockRebirthBack[i] = false;
            db.unlockRebirthBack[i].SetActive(true);
        }
        db.Money = 10000000;
    }
}
