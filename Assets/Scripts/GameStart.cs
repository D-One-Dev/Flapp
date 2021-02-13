using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private bool isGameOn = false;
    public GameObject canv, bird;
    private float birdGrav, birdSpd;
    void Start()
    {
        birdGrav = bird.GetComponent<BirdController>().gravityScale;
        birdSpd = bird.GetComponent<BirdController>().velocity;
    }
    void FixedUpdate()
    {
        
    }
    void OnMouseDown()
    {
        if (!isGameOn)
        {
            isGameOn = true;
            canv.GetComponent<MainScene>().enableText = false;
            bird.GetComponent<Rigidbody2D>().gravityScale = birdGrav;
        }
        else
        {
            bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, birdSpd);
        }
    }
}
