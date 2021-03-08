using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spreadsheet : MonoBehaviour
{
    
    const string URL = "https://docs.google.com/spreadsheets/d/14k4LTWg_DuaD1bp16y5OgKKL3FIWKdGJVTqujlQtnKI/export?fromat=tsv";
    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);
    }
}
