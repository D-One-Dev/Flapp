using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private bool isGameOn = false;
    public GameObject canv, bird;
    void Start()
    {
        
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
            bird.GetComponent<Rigidbody2D>().gravityScale = 8f;
        }
        else
        {
            bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 45f);
        }
    }
}
