using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockM : MonoBehaviour
{
    DB db;
    
    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        for (int i = 0; i < 4; i++) { db.goProduceAether[i].SetActive(false); }
    }
    
    void Update()
    {
        if(db.Money >= 100 && db.IsProduceAether(0) == false){ db.IsProduceAether(0, true); }
        if(db.Money >= 150 && db.IsProduceAether(1) == false){ db.IsProduceAether(1, true); }
        if(db.Money >= 500 && db.IsProduceAether(2) == false){ db.IsProduceAether(2, true); }
        for (int i = 0; i < 4; i++)
        {
            if(db.IsProduceAether(i) == true && db.goProduceAether[i].activeSelf == false)
            {
                db.goProduceAether[i].SetActive(true);
            }
        }
    }
}
