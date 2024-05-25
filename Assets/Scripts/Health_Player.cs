using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Lose");
        }
    }
    public void HealthDown()
    {
        Health -= damage;
    }
}
