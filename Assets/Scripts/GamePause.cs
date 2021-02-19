using UnityEngine;

public class GamePause : MonoBehaviour
{
    // canvas, pipes, menu button, bird and touchscreen references
    public GameObject canvas, pipe1, pipe2, menuButton, bird, touchScreen;
    //is game paused
    private bool gameStatus = true;
    //bird garvity and speed
    private float birdGrav, birdSpd;
    //pause button sprite renderer
    public SpriteRenderer sr;
    //pause button sprites
    public Sprite pauseSr, playSr;
    void Start()
    {
        //setting bird gravity and speed
        birdGrav = bird.GetComponent<BirdController>().gravityScale;
        birdSpd = bird.GetComponent<BirdController>().velocity;
        //setting pause button sprirte
        sr.sprite = pauseSr;
    }
    void OnMouseDown()
    {
        //if game isn't paused
        if (gameStatus == true)
        {
            //setting pause button sprite
            sr.sprite = playSr;
            //setting another scripts variables
            canvas.GetComponent<MainScene>().gamePause = true;
            pipe1.GetComponent<PipeMove>().pipeMove = false;
            pipe2.GetComponent<PipeMove>().pipeMove = false;
            touchScreen.GetComponent<GameStart>().isGamePaused = true;
            //moving pause button
            transform.position = new Vector3(0f, 0f, -9.5f);
            //scaling the pause button
            transform.localScale = new Vector3(1f, 1f, 1f);
            //moving menu button to the camera
            menuButton.transform.position = new Vector3(0f, -3f, -9.5f);
            //setting bird's garvity and velocity to 0
            bird.GetComponent<Rigidbody2D>().gravityScale = 0f;
            bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            gameStatus = false;
        }
        else
        {
            //setting pause button sprite
            sr.sprite = pauseSr;
            //setting another scripts variables
            canvas.GetComponent<MainScene>().gamePause = false;
            pipe1.GetComponent<PipeMove>().pipeMove = true;
            pipe2.GetComponent<PipeMove>().pipeMove = true;
            touchScreen.GetComponent<GameStart>().isGamePaused = false;
            //moving pause button
            transform.position = new Vector3(-3.5f, 9f, -9.5f);
            //scaling the pause button
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            //moving menu button outside the camera
            menuButton.transform.position = new Vector3(-10f, 6f, -9.5f);
            //setting bird's garvity and velocity
            bird.GetComponent<Rigidbody2D>().gravityScale = birdGrav;
            bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            gameStatus = true;
        }
    }
}
