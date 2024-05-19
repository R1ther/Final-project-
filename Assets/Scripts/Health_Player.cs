using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health_Player : MonoBehaviour
{
    public int Health;
    [SerializeField] private TMP_Text health;
    void Update()
    {
        health.text = Health.ToString();
        if(Health < 0)
        {
            Health = 0;
            Debug.Log("You Lose");
        }
    }
}
