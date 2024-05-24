using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Animator _anim;
    private BoxCollider EnemyCollider;
    public void Initialize()
    {
        _anim = GetComponent<Animator>();
        EnemyCollider = GetComponent<BoxCollider>();
    }
    public void AnimatorEnable()
    {
        _anim.enabled = true;
        EnemyCollider.enabled = true;
    }
    public void AnimatorDisable()
    {
        _anim.enabled = false;
        EnemyCollider.enabled = false;
    }
}
