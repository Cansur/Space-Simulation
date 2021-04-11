using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockM : MonoBehaviour
{
    DB db;

    bool isSlotGStone;
    
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        for (int i = 0; i < 6; i++) { db.goProduceAether[i].SetActive(false); }
        for (int i = 0; i < 3; i++) { db.unlockRebirthBack[i].SetActive(true); }
        db.panelSlotGStone.SetActive(false);
        isSlotGStone = false;
        StartCoroutine(UpdateLock());
    }
    
    /* void Update()
    {
        if(db.Money >= 100 && db.IsProduceAether(0) == false){ db.IsProduceAether(0, true); }
        if(db.Money >= 150 && db.IsProduceAether(1) == false){ db.IsProduceAether(1, true); }
        if(db.Money >= 500 && db.IsProduceAether(2) == false){ db.IsProduceAether(2, true); }
        if(db.Money >= 1000 && db.IsProduceAether(3) == false){ db.IsProduceAether(3, true); }
        if(db.Money >= 5000000 && db.IsProduceAether(4) == false){ db.IsProduceAether(4, true); }
        if(db.Money >= 100000000 && db.IsProduceAether(5) == false){ db.IsProduceAether(5, true); }

        if(db.TotalPerSec >= 10000 && db.isUnlockRebirthBack[1] == false) { db.isUnlockRebirthBack[1] = true; }
        if(db.Pt >= 1 && db.isUnlockRebirthBack[0] == false) { db.isUnlockRebirthBack[0] = true; }

        if(db.gStoneCount >= 1 && isSlotGStone == false) { isSlotGStone = true; }
        
        for (int i = 0; i < 6; i++)
        {
            if(db.IsProduceAether(i) == true && db.goProduceAether[i].activeSelf == false)
            {
                db.goProduceAether[i].SetActive(true);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if(db.isUnlockRebirthBack[i] == true && db.unlockRebirthBack[i].activeSelf == true)
            {
                db.unlockRebirthBack[i].SetActive(false);
            }
        }
        for (int i = 0; i < db.gStone.Length; i++)
        {
            if(db.gStone[i] == true && db.slotGStone[i].activeSelf == false) { db.slotGStone[i].SetActive(true); }
        }

        if(isSlotGStone == true && db.panelSlotGStone.activeSelf == false){ db.panelSlotGStone.SetActive(true); }
    } */

    IEnumerator UpdateLock()
    {
        if(db.Money >= 100 && db.IsProduceAether(0) == false){ db.IsProduceAether(0, true); }
        if(db.Money >= 150 && db.IsProduceAether(1) == false){ db.IsProduceAether(1, true); }
        if(db.Money >= 500 && db.IsProduceAether(2) == false){ db.IsProduceAether(2, true); }
        if(db.Money >= 1000 && db.IsProduceAether(3) == false){ db.IsProduceAether(3, true); }
        if(db.Money >= 5000000 && db.IsProduceAether(4) == false){ db.IsProduceAether(4, true); }
        if(db.Money >= 100000000 && db.IsProduceAether(5) == false){ db.IsProduceAether(5, true); }

        if(db.TotalPerSec >= 10000 && db.isUnlockRebirthBack[1] == false) { db.isUnlockRebirthBack[1] = true; }
        if(db.Pt >= 1 && db.isUnlockRebirthBack[0] == false) { db.isUnlockRebirthBack[0] = true; }

        if(db.gStoneCount >= 1 && isSlotGStone == false) { isSlotGStone = true; }
        
        for (int i = 0; i < 6; i++)
        {
            if(db.IsProduceAether(i) == true && db.goProduceAether[i].activeSelf == false)
            {
                db.goProduceAether[i].SetActive(true);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if(db.isUnlockRebirthBack[i] == true && db.unlockRebirthBack[i].activeSelf == true)
            {
                db.unlockRebirthBack[i].SetActive(false);
            }
        }
        for (int i = 0; i < db.gStone.Length; i++)
        {
            if(db.gStone[i] == true && db.slotGStone[i].activeSelf == false) { db.slotGStone[i].SetActive(true); }
        }

        if(isSlotGStone == true && db.panelSlotGStone.activeSelf == false){ db.panelSlotGStone.SetActive(true); }
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(UpdateLock());
    }
    
}
