using UnityEngine;
using TMPro;

public class Health_Player : MonoBehaviour
{
    public int Health;
    public TMP_Text health;
    public int damage;
    public void Update()
    {
        health.text = Health.ToString();
        if(Health < 0)
        {
            Health = 0;
        }
    }
    public void HealthDown()
    {
        Health -= damage;
    }
}
