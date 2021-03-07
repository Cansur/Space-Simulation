using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    public void Onclick1()
    {
        SceneManager.LoadScene("Test");
    }
}
