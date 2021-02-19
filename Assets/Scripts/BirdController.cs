using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    //canvas, pipes, menu button, pause button and touchscreen references
    public GameObject canvas, pipe1, pipe2, menuButton, pauseButton, touchScreen;
    //bird rigidbody2d reference
    public Rigidbody2D rb;
    //bird spriterenderer reference
    public SpriteRenderer sr;
    //bird sprites reference
    public Sprite birdJump, birdFall;
    //start game text reference | highscore text reference
    public Text txt, htxt;
    //bird gravity | bird velocity
    public float gravityScale, velocity;
    //score
    private int score;
    //highscore
    private string hScore;

    //game over
    void GameOver()
    {
        //saving highscore in memory
        if(PlayerPrefs.GetInt("HighScore") < score) PlayerPrefs.SetInt("HighScore", score);
        //setting another scripts variables
        canvas.GetComponent<MainScene>().gamePause = true;
        pipe1.GetComponent<PipeMove>().pipeMove = false;
        pipe2.GetComponent<PipeMove>().pipeMove = false;
        touchScreen.GetComponent<GameStart>().isGamePaused = true;
        //setting gravity to 0
        rb.gravityScale = 0f;
        //setting velocity to 0
        rb.velocity = new Vector2(0f, 0f);
        //moving menu button to the screen
        menuButton.transform.position = new Vector3(0f, -3f, -9.5f);
        //moving pause button outside the camera
        pauseButton.transform.position = new Vector3(-10f, 9f, -9.5f);
        //scaling pause button
        pauseButton.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        //moving start game and highscore texts
        txt.transform.position = new Vector3(txt.transform.position.x, 0f, txt.transform.position.z);
        htxt.transform.position = new Vector3(htxt.transform.position.x, -7f, htxt.transform.position.z);
        //getting highscore from the memory
        score = PlayerPrefs.GetInt("HighScore");
        hScore = score.ToString();
        //displaying highscore
        htxt.text = ("Highscore: " + hScore);
    }
    void Start()
    {
        //setting bird gravity to 0
        rb.gravityScale = 0f;
    }
    void FixedUpdate()
    {
        //switching bird sprite
        if (rb.velocity.y > 0f) sr.sprite = birdJump;
        else sr.sprite = birdFall;
        //game over
        if (transform.position.y < -11f) GameOver();
        //increasing score
        if (pipe1.GetComponent<Transform>().position.x < transform.position.x && !pipe1.GetComponent<PipeMove>().pipePassed)
        {
            if (touchScreen.GetComponent<GameStart>().isGameOn == true)
            {
                //getting score from the text
                score = int.Parse(txt.text);
                //increasig score
                score++;
                //setting new score
                txt.text = score.ToString();
                //was pipe passed
                pipe1.GetComponent<PipeMove>().pipePassed = true;
            }
        }
        //increasing score
        if (pipe2.GetComponent<Transform>().position.x < transform.position.x && !pipe2.GetComponent<PipeMove>().pipePassed)
        {
            if (touchScreen.GetComponent<GameStart>().isGameOn == true)
            {
                //getting score from the text
                score = int.Parse(txt.text);
                //increasig score
                score++;
                //setting new score
                txt.text = score.ToString();
                //was pipe passed
                pipe2.GetComponent<PipeMove>().pipePassed = true;
            }
        }
    }
    //collision with pipes
    void OnCollisionEnter2D(Collision2D collision)
    {
        //game over
        if(collision.gameObject.tag == "Wall" && touchScreen.GetComponent<GameStart>().isGameOn == true) GameOver();
    }
}
