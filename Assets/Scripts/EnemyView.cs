using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Animator _anim;
    public void Initialize()
    {
        _anim = GetComponent<Animator>();
    }
    public void AnimatorEnable()
    {
        _anim.enabled = true;
    }
    public void AnimatorDisable()
    {
        _anim.enabled = false;
    }
}
