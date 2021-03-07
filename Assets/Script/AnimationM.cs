using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationM : MonoBehaviour
{
    public Animator animatorA;
    public bool isCurrentAniAUp = false;
    public void OnButtonUpAni()
    {
        isCurrentAniAUp = isCurrentAniAUp == false ? true : false;
        animatorA.SetBool("UP", isCurrentAniAUp);
    }
}
