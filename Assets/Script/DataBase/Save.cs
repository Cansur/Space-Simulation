using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class Save : MonoBehaviour
{
    DB db;

    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
        //Debug.Log(Application.persistentDataPath);
        JLoad();
    }
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Home))
            {
                JSave();
                Application.Quit();
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                JSave();
                Application.Quit();
            }
        }
    }
    private void OnApplicationQuit() { JSave(); }

    Dictionary<string, bool> dataBool = new Dictionary<string, bool>();
    Dictionary<string, long> dataLong = new Dictionary<string, long>();
    Dictionary<string, int> dataInt = new Dictionary<string, int>();

    void Bool()
    {
        for (int i = 0; i < db.gStone.Length; i++) { dataBool["gStone" + i] = db.gStone[i]; }
        for (int i = 0; i < 6; i++) { dataBool["produceAether" + i] = db.IsProduceAether(i); }
    }
    void Long()
    {
        dataLong["money"] = db.Money;
        dataLong["per1sec"] = db.Per1sec;
        dataLong["totalPerSec"] = db.TotalPerSec;
        dataLong["Pt"] = db.Pt;
    }
    void Int()
    {
        for (int i = 0; i < 6; i++) { dataInt["countProduceAether" + i] = db.CountProduceAether(i); }
    }
    
    public void JSave()
    {
        Bool();
        string jdataBool = JsonConvert.SerializeObject(dataBool);
        File.WriteAllText(Application.persistentDataPath + "/Bool.txt", jdataBool);

        Long();
        string jdataLong = JsonConvert.SerializeObject(dataLong);
        File.WriteAllText(Application.persistentDataPath + "/Long.txt", jdataLong);

        Int();
        string jdataInt = JsonConvert.SerializeObject(dataInt);
        File.WriteAllText(Application.persistentDataPath + "/Int.txt", jdataInt);
    }
    public void JLoad()
    {
        FileInfo fi = new FileInfo(Application.persistentDataPath + "/Long.txt");
        if(fi.Exists) 
        { 
            //Debug.Log("있넹");
            string jdataBool = File.ReadAllText(Application.persistentDataPath + "/Bool.txt");
            dataBool = JsonConvert.DeserializeObject<Dictionary<string, bool>>(jdataBool);
            for (int i = 0; i < db.gStone.Length; i++) { db.gStone[i] = dataBool["gStone" + i]; }
            for (int i = 0; i < 6; i++) { db.IsProduceAether(i, dataBool["produceAether" + i]); }

            string jdataLong = File.ReadAllText(Application.persistentDataPath + "/Long.txt");
            dataLong = JsonConvert.DeserializeObject<Dictionary<string, long>>(jdataLong);
            db.Money = dataLong["money"];
            db.Per1sec = dataLong["per1sec"];
            db.TotalPerSec = dataLong["totalPerSec"];
            db.Pt = dataLong["Pt"];

            string jdataInt = File.ReadAllText(Application.persistentDataPath + "/Int.txt");
            dataInt = JsonConvert.DeserializeObject<Dictionary<string, int>>(jdataInt);
            for (int i = 0; i < 6; i++) { db.CountProduceAether(i, dataInt["countProduceAether" + i]); }

        }
        else { db.Money = 100; }
    }
}
