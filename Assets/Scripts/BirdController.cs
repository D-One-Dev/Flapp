using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Sprite birdJump, birdFall;
    public float gravityScale, velocity;
    public GameObject canvas, pipe1, pipe2, menuButton, pauseButton;
    public Text txt;
    private int score;
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
            canvas.GetComponent<MainScene>().gamePause = true;
            pipe1.GetComponent<PipeMove>().pipeMove = false;
            pipe2.GetComponent<PipeMove>().pipeMove = false;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(0f, 0f);
            menuButton.transform.position = new Vector3(0f, -3f, -9.5f);
            pauseButton.transform.position = new Vector3(-6.5f, 9f, -9.5f);
            pauseButton.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            txt.GetComponent<RectTransform>().localPosition = new Vector2(txt.GetComponent<RectTransform>().localPosition.x, 0f);
        }
        if (pipe1.GetComponent<Transform>().position.x < transform.position.x && !pipe1.GetComponent<PipeMove>().pipePassed)
        {
            score = int.Parse(txt.text);
            score++;
            txt.text = score.ToString();
            pipe1.GetComponent<PipeMove>().pipePassed = true;
        }
        if (pipe2.GetComponent<Transform>().position.x < transform.position.x && !pipe2.GetComponent<PipeMove>().pipePassed)
        {
            score = int.Parse(txt.text);
            score++;
            txt.text = score.ToString();
            pipe2.GetComponent<PipeMove>().pipePassed = true;
        }
    }
}
