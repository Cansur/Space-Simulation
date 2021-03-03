using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VectorM : MonoBehaviour
{
    public Animator animatorA;
    public bool isCurrentAniAUp = false;
    public void OnButtonUpAni()
    {
        isCurrentAniAUp = isCurrentAniAUp == false ? true : false;
        animatorA.SetBool("UP", isCurrentAniAUp);
    }
}
