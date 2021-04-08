using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spreadsheet : MonoBehaviour
{
    string URL;
    void Start()
    {
        URL = "https://docs.google.com/spreadsheets/d/14k4LTWg_DuaD1bp16y5OgKKL3FIWKdGJVTqujlQtnKI/export?fromat=tsv&range=B3:E15";

        StartCoroutine(CorStart());
    }
    IEnumerator CorStart()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        //www.downloadHandler.text
        Debug.Log(www.downloadHandler.text);
    }
}
