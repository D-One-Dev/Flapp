using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public bool isGameOn = false, isGamePaused = false;
    public GameObject canv, bird, pipe1Up, pipe1Down, pipe2Up, pipe2Down, pipe1, pipe2;
    private float birdGrav, birdSpd;
    public Text txt;
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
            bird.transform.position = new Vector3(-3f, 3f, 8f);
            pipe1Down.transform.localPosition = new Vector3(0f, Random.Range(-14f, -6f), 8f);
            pipe1Up.transform.localPosition = new Vector3(0f, Random.Range(pipe1Down.transform.position.y + 22f, pipe1Down.transform.position.y + 24f), 8f);
            pipe1.transform.position = new Vector3(12f, 0f, 0f);

            pipe2Down.transform.localPosition = new Vector3(0f, Random.Range(-14f, -6f), 8f);
            pipe2Up.transform.localPosition = new Vector3(0f, Random.Range(pipe2Down.transform.position.y + 22f, pipe2Down.transform.position.y + 24f), 8f);
            pipe2.transform.position = new Vector3(36f, 0f, 0f);
            isGameOn = true;
            canv.GetComponent<MainScene>().enableText = false;
            bird.GetComponent<Rigidbody2D>().gravityScale = birdGrav;
            pipe1Down.GetComponent<BoxCollider2D>().isTrigger = false;
            pipe1Up.GetComponent<BoxCollider2D>().isTrigger = false;
            pipe2Down.GetComponent<BoxCollider2D>().isTrigger = false;
            pipe2Up.GetComponent<BoxCollider2D>().isTrigger = false;
            txt.GetComponent<RectTransform>().anchorMax = new Vector2(txt.GetComponent<RectTransform>().anchorMax.x, 1f);
            txt.transform.position = new Vector3(txt.transform.position.x, -8f, txt.transform.position.z);

        }
        else
        {
            if(!isGamePaused) bird.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, birdSpd);
        }
    }
}
