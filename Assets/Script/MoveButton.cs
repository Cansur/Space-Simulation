using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    DB db;
    public GStoneM gStoneM;
    public Image[] imageButton;

    void Start()
    {
        db = GameObject.FindWithTag("DataBase").GetComponent<DB>();
    }

    public void OnClick(int var)
    {
        /* if(var == 0) 
        { 
            ResetColor();
            imageButton[0].color = new Color(231/255f, 231/255f, 231/255f);
            ResetBG();
            db.backGround[0].SetActive(true);
        }
        if(var == 1) 
        { 
            ResetColor();
            imageButton[1].color = new Color(231/255f, 231/255f, 231/255f);
            ResetBG();
            db.backGround[1].SetActive(true);
        }
        if(var == 2) 
        { 
            ResetColor();
            imageButton[2].color = new Color(231/255f, 231/255f, 231/255f);
            ResetBG();
            db.backGround[2].SetActive(true);
        }
        if(var == 3) 
        { 
            ResetColor();
            imageButton[3].color = new Color(231/255f, 231/255f, 231/255f);
            ResetBG();
            db.backGround[3].SetActive(true);
        } */

        ResetColor();
        imageButton[var].color = new Color(231/255f, 231/255f, 231/255f);
        ResetBG();
        db.backGround[var].SetActive(true);
        if(var == 1)
        {
            gStoneM.UpdateText();
        }
    }

    void ResetColor()
    {
        imageButton[0].color = new Color(194/255f, 192/255f, 188/255f);
        imageButton[1].color = new Color(194/255f, 192/255f, 188/255f);
        imageButton[2].color = new Color(194/255f, 192/255f, 188/255f);
        imageButton[3].color = new Color(194/255f, 192/255f, 188/255f);
    }

    void ResetBG()
    {
        //db.backGround[0].SetActive(false);
        db.backGround[1].SetActive(false);
        db.backGround[2].SetActive(false);
        db.backGround[3].SetActive(false);
    }
}
