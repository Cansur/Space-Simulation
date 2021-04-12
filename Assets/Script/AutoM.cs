using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoM : MonoBehaviour
{
    DB db;
    ShopM shopM;
    public GStoneM gStoneM;

    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        shopM = GameObject.FindWithTag("ShopM").GetComponent<ShopM>();
    }

    IEnumerator UpdateOnOff()
    {
        if(db.gStoneOnOff[0] == true) { StartCoroutine(Auto0()); }
        yield return new WaitForSeconds(5f);
        StartCoroutine(UpdateOnOff());
    }

    IEnumerator Auto0()
    {
        yield return new WaitForSeconds(5f);
        if(db.gStoneOnOff[0] == true) { }
    }
}
