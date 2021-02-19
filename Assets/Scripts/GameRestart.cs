using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    void OnMouseDown()
    {
        //scene restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
