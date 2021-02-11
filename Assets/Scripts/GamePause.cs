using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject canvas, pipe1, pipe2;
    private bool gameStatus = true;
    void Start()
    {
        // -3.5, 9, -9.5
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (gameStatus == true)
        {
            canvas.GetComponent<MainScene>().gamePause = true;
            pipe1.GetComponent<PipeMove>().pipeMove = false;
            pipe2.GetComponent<PipeMove>().pipeMove = false;
            transform.position = new Vector3(0f, 0f, -9.5f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            gameStatus = false;
        }
        else
        {
            canvas.GetComponent<MainScene>().gamePause = false;
            pipe1.GetComponent<PipeMove>().pipeMove = true;
            pipe2.GetComponent<PipeMove>().pipeMove = true;
            transform.position = new Vector3(-3.5f, 9f, -9.5f);
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            gameStatus = true;
        }
    }
}
