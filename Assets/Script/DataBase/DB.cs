using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class DB : MonoBehaviour
{
    [SerializeField] long money;
    public long Money { get { return money; } set { money = value; } }
    [SerializeField] long per1sec;
    public long Per1sec { get { return per1sec; } set { per1sec = value; } }
    [SerializeField] long totalPerSec;
    public long TotalPerSec { get { return totalPerSec; } set { totalPerSec = value; } }
    [SerializeField] long pt;
    public long Pt { get { return pt; } set { pt = value; } }
    
    public void SumTotalPerSec() 
    { 
        int var = CountProduceAether(1); // 제 2에테르생산소
        int var1 = CountProduceAether(2); // 제 3에테르생산소
        int var2 = CountProduceAether(3); // 제 3에테르생산소
        int var3 = CountProduceAether(4); // 제 4에테르생산소
        int var4 = CountProduceAether(5); // 제 5에테르생산소
        //Debug.Log(var);
        long longvar = PerProduceAether(1, var) * PerProduceAether(2, var1) * PerProduceAether(3, var2) * PerProduceAether(4, var3) * PerProduceAether(5, var4);
        TotalPerSec = (Per1sec * longvar);
        //if
        //int var = CountProduceAether(1);
        //TotalPerSec = (Per1sec * PerProduceAether(1, var));
        //TotalPerSec = Per1sec;
    }

    #region 에테르 채집

    [SerializeField] bool[] isProduceAether = new bool[6]; // 10개 지만 테스트중
    public void IsProduceAether(int var, bool var1){isProduceAether[var] = var1;}
    public bool IsProduceAether(int var) {return isProduceAether[var];}
    public GameObject[] goProduceAether = new GameObject[6];

    public Text[] textCountProduceAether = new Text[6];
    public Text[] textEffectProduceAether = new Text[6];
    public Text[] textNeedMoneyBuyProduceAether = new Text[6];
    public GameObject[] goProduceAetherButton = new GameObject[6];
    [SerializeField] int[] countProduceAether = new int[6];
    public void CountProduceAether(int var, int var1) { countProduceAether[var] = var1;}

    public int CountProduceAether(int var) { return countProduceAether[var]; }
    [SerializeField] long[][] needMoneyBuyProduceAether = new long[6][];
    public void NeedMoneyBuyProduceAether(int var, int var1, long var2) { needMoneyBuyProduceAether[var][var1] = var2;}
    public long NeedMoneyBuyProduceAether(int var, int var1) { return needMoneyBuyProduceAether[var][var1];}
    [SerializeField] long[][] perProduceAether = new long[6][];
    public void PerProduceAether(int var, int var1, int var2) { perProduceAether[var][var1] = var2; }
    public long PerProduceAether(int var, int var1) { return perProduceAether[var][var1]; }

    public bool isAetherStop;

    #endregion

    public GameObject[] backGround;

    void Start()
    {
        needMoneyBuyProduceAether[0] = new long[100];
        needMoneyBuyProduceAether[1] = new long[100];
        needMoneyBuyProduceAether[2] = new long[100];
        needMoneyBuyProduceAether[3] = new long[100];
        needMoneyBuyProduceAether[4] = new long[100];
        needMoneyBuyProduceAether[5] = new long[100];
        //needMoneyBuyProduceAether[4] = new long[20];
        perProduceAether[0] = new long[100];
        perProduceAether[1] = new long[100];
        perProduceAether[2] = new long[100];
        perProduceAether[3] = new long[100];
        perProduceAether[4] = new long[100];
        perProduceAether[5] = new long[100];
        //perProduceAether[4] = new long[20];
        SumTotalPerSec();
        GameLoad();
    }

    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Home))
            {
                GameSave();
                Application.Quit();
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                GameSave();
                Application.Quit();
            }
        }
    }

    private void OnApplicationQuit()
    {
        GameSave();
        Debug.Log("money = " + PlayerPrefs.GetInt("money"));
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            GameSave();
        }
    }

    void GameSave()
    {
        PlayerPrefs.SetInt("money", (int)money);
    }
    
    void GameLoad()
    {
        if(PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
            Debug.Log("money = " + PlayerPrefs.GetInt("money"));
        }
        else { money = 100; }
    }
}
