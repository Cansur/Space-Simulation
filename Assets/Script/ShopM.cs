using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopM : MonoBehaviour
{
    DB db;
    DValue dValue;
    [SerializeField]
    Image[] colorProduceAetherButton = new Image[6];
    Text[][] gStoneText = new Text[37][];
    public Image[] colorGStoneButton;
    public Image[] colorGStoneButtonOnOff;
    public Text[] gStoneOnOfftext;
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        dValue = GameObject.FindWithTag("DValue").GetComponent<DValue>();
        //TestD();  DValue ��ũ��Ʈ��
        //StartDownTextAether();
        //UpColorProduceAether();
        //DownTextCountProduceAether();
        //TextNeedMoneyBuyProduceAetherUpdate();
        GStoneUpgradeSet();
        GStoneTextGetComponent();
        UpdateText();
        StartCoroutine(UpdateGStoneColorButton());
        StartCoroutine(UpdateGStoneOnOff());
    }

    void Update()
    {
        UpColorProduceAether();
        //UpdateGStone();
    }

    #region ���׸�ä������

    public void OnCilck1(int var) // �� 2���׸� ����� : var = 1
    {
        int var1 = db.CountProduceAether(var); // var = 1 �̸� var1 �� 0
        if(db.NeedMoneyBuyProduceAether(var, var1) <= db.Money)
        {
            //if(var == 1){Debug.Log("��ȣ");}
            db.Money -= db.NeedMoneyBuyProduceAether(var, var1);
            db.CountProduceAether(var, db.CountProduceAether(var)+1); 
            db.Per1sec += db.PerProduceAether(var, var1); // ���ϱ�
            db.SumTotalPerSec();
            TextNeedMoneyBuyProduceAetherUpdate(var, var1);
            DownTextEffectProduceAether(var);
            DownColorProduceAether(var);
            DownTextCountProduceAether(var);
        }
    } 
    public void Oncilck2(int var)
    {
        int var1 = db.CountProduceAether(var); // var = 1 �̸� var1 �� 0
        if(db.NeedMoneyBuyProduceAether(var, var1) <= db.Money)
        {
            db.Money -= db.NeedMoneyBuyProduceAether(var, var1);
            db.CountProduceAether(var, db.CountProduceAether(var)+1); // 1, 1
            
            db.SumTotalPerSec();
            DownTextEffectProduceAether(var);
            TextNeedMoneyBuyProduceAetherUpdate(var, var1);
            DownColorProduceAether(var);
            DownTextCountProduceAether(var);
            One();
        }
    }


    void UpColorProduceAether()
    {
        for (int i = 0; i < 6; i++)
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
    void One()
    {
        if(db.Money >= db.NeedMoneyBuyProduceAether(0, db.CountProduceAether(0)))
        {
            colorProduceAetherButton[0].color = new Color(103/255f, 231/255f, 107/255f);
        }
        else if(db.Money < db.NeedMoneyBuyProduceAether(0, db.CountProduceAether(0)))
        {
            colorProduceAetherButton[0].color = new Color(231/255f, 115/255f, 103/255f);
        }
    }
    void DownColorProduceAether(int var)
    {
        if(db.Money < db.NeedMoneyBuyProduceAether(var, db.CountProduceAether(var)))
        {
            colorProduceAetherButton[var].color = new Color(231/255f, 115/255f, 103/255f);
        }
    }

    public void TestD()
    {
        for (int i = 0; i < 6; i++)
        {
            colorProduceAetherButton[i] = db.goProduceAetherButton[i].GetComponent<Image>();
        }
        //colorProduceAetherButton[0].color = new Color(231/255f, 115/255f, 103/255f);
        //colorProduceAetherButton[0] = new Color(1, 1, 1);
        StartDownTextAether();
        //dValue.ShopProduceAther();
        //TextNeedMoneyBuyProduceAetherUpdate();
    }

    // ���� �ְ�
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
            db.textEffectProduceAether[var].text = string.Format("+ " + db.PerProduceAether(var, var1) + "/sec");
        }
        else
        {
            db.textEffectProduceAether[var].text = string.Format("�� " + var + "���׸� ����� x " + db.PerProduceAether(var, var1));
        }
    }

    public void StartDownTextAether()
    {
        for (int i = 0; i < 6; i++)
        {
            int var = db.CountProduceAether(i);
            TextNeedMoneyBuyProduceAetherUpdate(i, var - 1);
            DownTextCountProduceAether(i);
            DownTextEffectProduceAether(i);
        }
        UpColorProduceAether();
    }

    #endregion

    void UpdateText()
    {
        float var = (float)db.gStoneUpgradeEffect[1][db.gStoneUpgradeCount[1]]/10;


        // 0�� �ʿ䵷, 1�� ȿ��
        gStoneText[0][0].text = string.Format("{0:#,###} Pt", db.gStoneUpgradePrice[0][db.gStoneUpgradeCount[0]]);
        gStoneText[0][1].text = "ȿ�� : ���׸� ���귮�� " + db.gStoneUpgradeEffect[0][db.gStoneUpgradeCount[0]] + "�谡 �ȴ�.";
        gStoneText[1][0].text = string.Format("{0:#,###} Pt", db.gStoneUpgradePrice[1][db.gStoneUpgradeCount[1]]);
        gStoneText[1][1].text = string.Format("ȿ�� : Pt�� {0:F1}�谡 �ȴ�", (1 + var));
        gStoneText[2][1].text = "ȿ�� : �� 1���׸� ���� �ڵ�ȭ(5��)";
        gStoneText[3][1].text = "ȿ�� : �� 2���׸� ���� �ڵ�ȭ(5��)";
        gStoneText[4][1].text = "ȿ�� : �� 3���׸� ���� �ڵ�ȭ(5��)";
        gStoneText[5][1].text = "ȿ�� : �� 4���׸� ���� �ڵ�ȭ(5��)";
        gStoneText[6][1].text = "ȿ�� : �� 5���׸� ���� �ڵ�ȭ(5��)";
        gStoneText[7][1].text = "ȿ�� : �� 6���׸� ���� �ڵ�ȭ(5��)";
        gStoneText[8][1].text = "ȿ�� : [Easy ȯ��] �ڵ�ȭ(10��)";
        gStoneText[9][1].text = "ȿ�� : ���׸� ���� �ӵ� ��� (��, 1�ʴ� 10000�̻� �̾���Ѵ�.)";
        //gStoneText[1][1].text = string.Format("ȿ�� : Pt�� {0}�谡 �ȴ�", db.gStoneUpgradeEffect[1][db.gStoneUpgradeCount[1]]);
        //"ȿ�� : Pt�� " + ((db.gStoneUpgradeEffect[1][db.gStoneUpgradeCount[1]]/10) + 1) + "�谡 �ȴ�.";
    }

    void GStoneTextGetComponent()
    {
        colorGStoneButton[0] = db.slotGStone[0].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButton[1] = db.slotGStone[1].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[0] = db.slotGStone[2].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[1] = db.slotGStone[3].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[2] = db.slotGStone[4].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[3] = db.slotGStone[5].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[4] = db.slotGStone[6].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[5] = db.slotGStone[7].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[6] = db.slotGStone[8].transform.GetChild(3).GetComponent<Image>();
        colorGStoneButtonOnOff[7] = db.slotGStone[9].transform.GetChild(3).GetComponent<Image>();
        gStoneOnOfftext[0] = colorGStoneButtonOnOff[0].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[1] = colorGStoneButtonOnOff[1].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[2] = colorGStoneButtonOnOff[2].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[3] = colorGStoneButtonOnOff[3].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[4] = colorGStoneButtonOnOff[4].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[5] = colorGStoneButtonOnOff[5].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[6] = colorGStoneButtonOnOff[6].transform.GetChild(0).GetComponent<Text>();
        gStoneOnOfftext[7] = colorGStoneButtonOnOff[7].transform.GetChild(0).GetComponent<Text>();
        for (int i = 0; i < 37; i++) { gStoneText[i] = new Text[2]; }
        for (int i = 0; i < 37; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                gStoneText[i][j] = db.slotGStone[i].transform.GetChild(j+1).GetComponent<Text>();
            }
        }
    }
    
    //
    //  [ DValue ---> ShopM ]
    //
    public void GStoneUpgradeSet()
    {
        // ���׷��̵� ������ ��ȣ��
        // 0�� - 1�ʴ� �����ϴ� ���׸��� ���� (2��)
        // 1�� - Pt��¾� ���� (1.2��)
        // 2�� - .....
        db.gStoneUpgradePrice[0][0] = 2;
        db.gStoneUpgradePrice[1][0] = 5;

        db.gStoneUpgradeEffect[0][0] = 2;
        db.gStoneUpgradeEffect[1][0] = 2; // 2 * 0.1
        for (int i = 1; i < 100; i++)
        {
            db.gStoneUpgradePrice[0][i] = db.gStoneUpgradePrice[0][i-1] * 3;
            db.gStoneUpgradePrice[1][i] = db.gStoneUpgradePrice[0][i-1] * 5;

            db.gStoneUpgradeEffect[0][i] = (i+1) * 2;
            db.gStoneUpgradeEffect[1][i] = (i+1) * 2;
        }
        //Debug.Log(db.gStoneUpgradePrice[0][0]);
    }
    public void OnClick3(int var)
    {
        // 0�� - 1�ʴ� �����ϴ� ���׸��� ���� (2��)
        // 1�� - Pt��¾� ���� (1.2��)
        int var1 = db.gStoneUpgradeCount[var];
        if(db.Pt >= db.gStoneUpgradePrice[var][var1])
        {
            db.Pt -= db.gStoneUpgradePrice[var][var1];
            db.gStoneUpgradeCount[var] = var1+1;
            db.SumTotalPerSec();
            UpdateText();
        }
    }

    public void OnClick4(int var)
    {
        // 0�� - �� 1���׸� �ڵ�
        // 1�� - �� 2���׸� �ڵ�
        // 2�� - �� 3���׸� �ڵ�
        // 3�� - �� 4���׸� �ڵ�
        // 4�� - �� 5���׸� �ڵ�
        // 5�� - �� 6���׸� �ڵ�
        // 6�� - [Easy ȯ��] �ڵ�
        // 7�� - ���׸� ���� �ӵ� ���
        db.gStoneOnOff[var] = db.gStoneOnOff[var] == true ? false : true;
    }

    IEnumerator UpdateGStoneColorButton()
    {
        for (int i = 0; i < 2; i++)
        {
            if(db.Pt >= db.gStoneUpgradePrice[i][db.gStoneUpgradeCount[i]])
            {
                colorGStoneButton[i].color = new Color(103/255f, 231/255f, 107/255f);
            }
            else if(db.Pt < db.gStoneUpgradePrice[i][db.gStoneUpgradeCount[i]])
            {
                colorGStoneButton[i].color = new Color(231/255f, 115/255f, 103/255f);
            }
        }
        
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(UpdateGStoneColorButton());
    }
    
    IEnumerator UpdateGStoneOnOff()
    {
        for (int i = 0; i < db.gStoneOnOff.Length; i++)
        {
            if(db.gStoneOnOff[i] == true) { colorGStoneButtonOnOff[i].color = new Color(152/255f, 152/255f, 152/255f); gStoneOnOfftext[i].text = "On"; }
            else { colorGStoneButtonOnOff[i].color = new Color(53/255f, 53/255f, 53/255f); gStoneOnOfftext[i].text = "Off";}
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(UpdateGStoneOnOff());
    }
}
