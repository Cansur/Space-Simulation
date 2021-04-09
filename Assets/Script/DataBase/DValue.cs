using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DValue : MonoBehaviour
{
    DB db;
    public ShopM shopM;

    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        ShopProduceAther();
        PriceGStone();
    }

    public void ShopProduceAther()
    {
        NeedMoneyBuyProduceAether();
        PerProduceAether();
        shopM.TestD();
        //Debug.Log(db.NeedMoneyBuyProduceAether(0, 50));
    }

    void NeedMoneyBuyProduceAether()
    {
        // 제 1에테르 생산소
        db.NeedMoneyBuyProduceAether(0, 0, 100);
        for (int i = 1; i < 100; i++)
        {
            db.NeedMoneyBuyProduceAether(0, i, db.NeedMoneyBuyProduceAether(0, i-1) * 3);
            //db.NeedMoneyBuyProduceAether(0, i, db.NeedMoneyBuyProduceAether(0, i-1) * 2 * (1 + (i/100)));

        }
        /* db.NeedMoneyBuyProduceAether(0, 0, 100);
        db.NeedMoneyBuyProduceAether(0, 1, 200);
        db.NeedMoneyBuyProduceAether(0, 2, 300);
        db.NeedMoneyBuyProduceAether(0, 3, 500);
        db.NeedMoneyBuyProduceAether(0, 4, 600);
        db.NeedMoneyBuyProduceAether(0, 5, 700);
        db.NeedMoneyBuyProduceAether(0, 6, 800);
        db.NeedMoneyBuyProduceAether(0, 7, 100000000); */

        // 제 2에테르 생산소
        db.NeedMoneyBuyProduceAether(1, 0, 200);
        for (int i = 1; i < 100; i++)
        {
            db.NeedMoneyBuyProduceAether(1, i, db.NeedMoneyBuyProduceAether(1, i-1) * 6);
            //db.NeedMoneyBuyProduceAether(1, i, db.NeedMoneyBuyProduceAether(1, i-1) * 3 * (1 + (i/80)));
        }
        /* db.NeedMoneyBuyProduceAether(1, 0, 200);
        db.NeedMoneyBuyProduceAether(1, 1, 300);
        db.NeedMoneyBuyProduceAether(1, 2, 400);
        db.NeedMoneyBuyProduceAether(1, 3, 100000000); */

        // 제 3에테르 생산소
        db.NeedMoneyBuyProduceAether(2, 0, 500);
        for (int i = 1; i < 100; i++)
        {
            db.NeedMoneyBuyProduceAether(2, i, db.NeedMoneyBuyProduceAether(2, i-1) * 9);
            //db.NeedMoneyBuyProduceAether(2, i, db.NeedMoneyBuyProduceAether(2, i-1) * 4 * (1 + (i/60)));
        }
        /* db.NeedMoneyBuyProduceAether(2, 0, 1000);
        db.NeedMoneyBuyProduceAether(2, 1, 10000);
        db.NeedMoneyBuyProduceAether(2, 1, 100000000); */

        // 제 4에테르 생산소
        db.NeedMoneyBuyProduceAether(3, 0, 1000);
        for (int i = 1; i < 100; i++)
        {
            db.NeedMoneyBuyProduceAether(3, i, db.NeedMoneyBuyProduceAether(3, i-1) * 12);
            //db.NeedMoneyBuyProduceAether(3, i, db.NeedMoneyBuyProduceAether(3, i-1) * 5 * (1 + (i/40)));
        }
        /* db.NeedMoneyBuyProduceAether(3, 0, 10000);
        db.NeedMoneyBuyProduceAether(3, 1, 100000000); */

        // 제 5에테르 생산소
        db.NeedMoneyBuyProduceAether(4, 0, 10000000);
        for (int i = 1; i < 100; i++)
        {
            db.NeedMoneyBuyProduceAether(4, i, db.NeedMoneyBuyProduceAether(4, i-1) * 15);
            //db.NeedMoneyBuyProduceAether(3, i, db.NeedMoneyBuyProduceAether(3, i-1) * 5 * (1 + (i/40)));
        }
        // 제 6에테르 생산소
        db.NeedMoneyBuyProduceAether(5, 0, 500000000);
        for (int i = 1; i < 100; i++)
        {
            db.NeedMoneyBuyProduceAether(5, i, db.NeedMoneyBuyProduceAether(5, i-1) * 20);
            //db.NeedMoneyBuyProduceAether(3, i, db.NeedMoneyBuyProduceAether(3, i-1) * 5 * (1 + (i/40)));
        }
    }

    void PerProduceAether()
    {
        // 제 1에테르 생산소  더하기
        for (int i = 0; i < 100; i++)
        {
            db.PerProduceAether(0, i, 10);
        }
        /* db.PerProduceAether(0, 0, 10); // 더하기
        db.PerProduceAether(0, 1, 10);
        db.PerProduceAether(0, 2, 10);
        db.PerProduceAether(0, 3, 10);
        db.PerProduceAether(0, 4, 10);
        db.PerProduceAether(0, 5, 10);
        db.PerProduceAether(0, 6, 10);
        db.PerProduceAether(0, 7, 10); */

        // 제 2에테르 생산소  곱하기
        for (int i = 0; i < 100; i++)
        {
            db.PerProduceAether(1, i, i+1);
        }
        /* db.PerProduceAether(1, 0, 1); // 곱하기
        db.PerProduceAether(1, 1, 2);
        db.PerProduceAether(1, 2, 3);
        db.PerProduceAether(1, 3, 4);
        db.PerProduceAether(1, 4, 5); */

        // 제 3에테르 생산소
        for (int i = 0; i < 100; i++)
        {
            db.PerProduceAether(2, i, i+1);
        }
        /* db.PerProduceAether(2, 0, 1);
        db.PerProduceAether(2, 1, 2);
        db.PerProduceAether(2, 2, 3); */

        // 제 4에테르 생산소
        for (int i = 0; i < 100; i++)
        {
            db.PerProduceAether(3, i, i+1);
        }
        /* db.PerProduceAether(3, 0, 1);
        db.PerProduceAether(3, 1, 2);
        db.PerProduceAether(3, 1, 3); */

        // 제 5에테르 생산소
        for (int i = 0; i < 100; i++)
        {
            db.PerProduceAether(4, i, i+1);
        }

        // 제 6에테르 생산소
        for (int i = 0; i < 100; i++)
        {
            db.PerProduceAether(5, i, i+1);
        }
    }
    
    void PriceGStone()
    {
        db.PriceGStone(0, 1);
        db.PriceGStone(1, 4);
        db.PriceGStone(2, 10);
        db.PriceGStone(3, 30);
        db.PriceGStone(4, 80);
        db.PriceGStone(5, 160);
        db.PriceGStone(6, 300);
        db.PriceGStone(7, 500);
        db.PriceGStone(8, 1000);
    }
}
