using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Sprite birdJump, birdFall;
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
    }
}
