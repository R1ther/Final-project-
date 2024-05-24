using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
