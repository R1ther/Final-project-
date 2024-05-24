using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Finish"))
        {
            int n = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(n++);
        }
    }
}