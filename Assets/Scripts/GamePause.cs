using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject canvas, pipe1, pipe2, menuButton, bird, touchScreen;
    private bool gameStatus = true;
    private float birdGrav, birdSpd;
    void Start()
    {
        birdGrav = bird.GetComponent<BirdController>().gravityScale;
        birdSpd = bird.GetComponent<BirdController>().velocity;
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
            menuButton.transform.position = new Vector3(0f, -3f, -9.5f);
            bird.GetComponent<Rigidbody2D>().gravityScale = 0f;
            bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            touchScreen.GetComponent<GameStart>().isGamePaused = true;
            gameStatus = false;
        }
        else
        {
            canvas.GetComponent<MainScene>().gamePause = false;
            pipe1.GetComponent<PipeMove>().pipeMove = true;
            pipe2.GetComponent<PipeMove>().pipeMove = true;
            transform.position = new Vector3(-3.5f, 9f, -9.5f);
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            menuButton.transform.position = new Vector3(-6.5f, 6f, -9.5f);
            bird.GetComponent<Rigidbody2D>().gravityScale = birdGrav;
            bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            touchScreen.GetComponent<GameStart>().isGamePaused = false;
            gameStatus = true;
        }
    }
}
