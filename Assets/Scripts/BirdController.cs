using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Sprite birdJump, birdFall;
    public float gravityScale, velocity;
    public GameObject canvas, pipe1, pipe2, menuButton, pauseButton, touchScreen;
    public Text txt, htxt;
    private int score;
    private string hScore;

    void GameOver()
    {
        if(PlayerPrefs.GetInt("HighScore") < score)
        PlayerPrefs.SetInt("HighScore", score);
        canvas.GetComponent<MainScene>().gamePause = true;
        pipe1.GetComponent<PipeMove>().pipeMove = false;
        pipe2.GetComponent<PipeMove>().pipeMove = false;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0f, 0f);
        menuButton.transform.position = new Vector3(0f, -3f, -9.5f);
        pauseButton.transform.position = new Vector3(-10f, 9f, -9.5f);
        pauseButton.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        txt.transform.position = new Vector3(txt.transform.position.x, 0f, txt.transform.position.z);
        htxt.transform.position = new Vector3(htxt.transform.position.x, -7f, htxt.transform.position.z);
        score = PlayerPrefs.GetInt("HighScore");
        hScore = score.ToString();
        htxt.text = ("Highscore: " + hScore);
        touchScreen.GetComponent<GameStart>().isGamePaused = true;
    }
    void Start()
    {
        rb.gravityScale = 0f;
    }
    void FixedUpdate()
    {
        if (rb.velocity.y > 0f)
        {
            sr.sprite = birdJump;
        }
        else
        {
            sr.sprite = birdFall;
        }
        if (transform.position.y < -11f)
        {
            GameOver();
        }
        if (pipe1.GetComponent<Transform>().position.x < transform.position.x && !pipe1.GetComponent<PipeMove>().pipePassed)
        {
            if (touchScreen.GetComponent<GameStart>().isGameOn == true)
            {
                score = int.Parse(txt.text);
                score++;
                txt.text = score.ToString();
                pipe1.GetComponent<PipeMove>().pipePassed = true;
            }
        }
        if (pipe2.GetComponent<Transform>().position.x < transform.position.x && !pipe2.GetComponent<PipeMove>().pipePassed)
        {
            if (touchScreen.GetComponent<GameStart>().isGameOn == true)
            {
                score = int.Parse(txt.text);
                score++;
                txt.text = score.ToString();
                pipe2.GetComponent<PipeMove>().pipePassed = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" && touchScreen.GetComponent<GameStart>().isGameOn == true)
        {
            GameOver();
        }
    }
}
