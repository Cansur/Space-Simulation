using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour
{
    DB db;

    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if( db.Money >= 1 ) { db.Money -=1; db.Per1sec += 1; }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if( db.Money >= 10 ) { db.Money -= 10; db.Per1sec += 2;}
        }
    }
}
