using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

# region 표
/* 1 : 10000 = pt : psec

1pt - 1
4pt - 2
10pt - 3
30pt - 4
80pt - 5
160pt - 6
300pt - 7
500pt - 8
1000pt - 9..

수호석
0~9번 - 까지 1셋트
10~19번 - 까지 2셋트
20번 3셋트



0. Psec 배수증가 x2
1. Pt 배수증가 x 1.2
2. 에테르 1 생산 자동화
3. 에테르 2 생산 자동화
4. 에테르 3 생산 자동화
5. 에테르 4 생산 자동화
6. 에테르 5 생산 자동화
7. 에테르 6 생산 자동화
8. 초기화 자동화
9. 속도 상승(persec 10000이상)
10. 시련 1 잠금해제
11. 시련 2 잠금해제
12. 시련 3 잠금해제
13. 시련 4 잠금해제
14. 시련 5 잠금해제
15. 시련 6 잠금해제
16. 시련 7 잠금해제
17. 시련 8 잠금해제
18. 시련 9 잠금해제
19. 시련 10 잠금해제
20. Pt 


시련 1 잠금 - 1 생산 수호석 비례 증가
시련 2 잠금 - 2 생산 수호석 비례 증가
시련 3 잠금 - 3 생산 수호석 비례 증가
시련 4 잠금 - 4 생산 수호석 비례 증가
시련 5 잠금 - 5 생산 수호석 비례 증가
시련 6 잠금 - 6 생산 수호석 비례 증가
시련 7 잠금 - 1~2 생산 비용 감소
시련 8 잠금 - 3~4 생산 비용 감소
시련 9 잠금 - 5~6 생산 비용 감소
시련 10 잠금 - 대량 구매 가능 */

#endregion

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
        StartCoroutine(UpdateC());
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
            else if(1 <= db.gStoneCount && 9 >= db.gStoneCount) 
            {
                int var1 = Random.Range(1, 10); // 수호석 1번쨰는 인덱스 번호 0임
                if(db.gStone[var1] == false)
                {
                    db.gStone[var1] = true;
                    db.Pt -= db.PriceGStone(db.gStoneCount);
                    panelGStone.SetActive(false);
                }
                else { OnClickEasyYes(); }
            }
            else if(9 <= db.gStoneCount && 19 >= db.gStoneCount)
            {
                int var1 = Random.Range(11, 20); // 수호석 1번쨰는 인덱스 번호 0임
                if(db.gStone[var1] == false)
                {
                    db.gStone[var1] = true;
                    db.Pt -= db.PriceGStone(db.gStoneCount);
                    panelGStone.SetActive(false);
                }
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

    IEnumerator UpdateC()
    {
        UpdateText();
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(UpdateC());
    }
}
