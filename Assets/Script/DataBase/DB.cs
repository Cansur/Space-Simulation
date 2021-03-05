// ClFilp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class DB : MonoBehaviour
{
    [SerializeField] int money;
    public int Money { get { return money; } set { money = value; } }
    [SerializeField] int per1sec;
    public int Per1sec { get { return per1sec; } set { per1sec = value; } }
    [SerializeField] int totalPerSec;
    public int TotalPerSec { get { return totalPerSec; } set { totalPerSec = value; } }
    public void SumTotalPerSec() 
    { 
        int var = CountProduceAether(1);
        TotalPerSec = (Per1sec * PerProduceAether(1, var));
        //if
        //int var = CountProduceAether(1);
        //TotalPerSec = (Per1sec * PerProduceAether(1, var));
        //TotalPerSec = Per1sec;
    }

    #region 에테르 채집

    [SerializeField] bool[] isProduceAether = new bool[4]; // 10개 지만 테스트중
    public void IsProduceAether(int var, bool var1){isProduceAether[var] = var1;}
    public bool IsProduceAether(int var) {return isProduceAether[var];}
    public GameObject[] goProduceAether = new GameObject[4];

    public Text[] textCountProduceAether = new Text[4];
    public Text[] textNeedMoneyBuyProduceAether = new Text[4];
    public GameObject[] goProduceAetherButton = new GameObject[4];
    [SerializeField] int[] countProduceAether = new int[4];
    public void CountProduceAether(int var, int var1) { countProduceAether[var] = var1;}
    public int CountProduceAether(int var) { return countProduceAether[var];}
    [SerializeField] int[][] needMoneyBuyProduceAether = new int[4][];
    public void NeedMoneyBuyProduceAether(int var, int var1, int var2) { needMoneyBuyProduceAether[var][var1] = var2;}
    public int NeedMoneyBuyProduceAether(int var, int var1) { return needMoneyBuyProduceAether[var][var1];}
    [SerializeField] int[][] perProduceAether = new int[4][];
    public void PerProduceAether(int var, int var1, int var2) { perProduceAether[var][var1] = var2; }
    public int PerProduceAether(int var, int var1) { return perProduceAether[var][var1]; }

    #endregion

    void Start()
    {
        needMoneyBuyProduceAether[0] = new int[10];
        needMoneyBuyProduceAether[1] = new int[10];
        perProduceAether[0] = new int[10];
        perProduceAether[1] = new int[10];
        SumTotalPerSec();
    }
}
