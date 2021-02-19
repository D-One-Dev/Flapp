using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    //start game text reference
    public Text txt;
    //text outline reference
    public Outline oLine;
    //some shit | is game paused | is score displaying
    public bool enableText = true, gamePause = false, score = true;
    //pipes and pause button references
    public GameObject pipe1, pipe2, pipe1Down, pipe1Up, pipe2Down, pipe2Up, pause; 
    void Start()
    {
        //new lower pipe random y position
        pipe1Down.transform.position = new Vector3(0f, Random.Range(-14f, -6f), 8f);
        //new upper pipe random y position
        pipe1Up.transform.position = new Vector3(0f, Random.Range(pipe1Down.transform.position.y + 22f, pipe1Down.transform.position.y + 24f), 8f);
        //new first pair of pipes x position
        pipe1.transform.position = new Vector3(12f, 0f, 0f);
        //new lower pipe random y position
        pipe2Down.transform.position = new Vector3(0f, Random.Range(-14f, -6f), 8f);
        //new upper pipe random y position
        pipe2Up.transform.position = new Vector3(0f, Random.Range(pipe2Down.transform.position.y + 22f, pipe2Down.transform.position.y + 24f), 8f);
        //new second pair of pipes x position
        pipe2.transform.position = new Vector3(36f, 0f, 0f);
    }
    void FixedUpdate()
    {
        //if game is stopped or ended
        if (!gamePause)
        {
            if (enableText)
            {
                //text animation
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time, 1f));
                oLine.effectColor = new Color(oLine.effectColor.r, oLine.effectColor.g, oLine.effectColor.b, txt.color.a);
            }
            else
            {
                //if score is displayed
                if (score)
                {
                    //default text and outline color
                    txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1f);
                    oLine.effectColor = new Color(oLine.effectColor.r, oLine.effectColor.g, oLine.effectColor.b, 1f);
                    //setting text, fontsize and some new shit
                    txt.text = ("0");
                    txt.fontSize = 200;
                    oLine.effectDistance = new Vector2(4, -4);
                    score = false;
                }
                //setting pause button position outside of camera
                pause.transform.position = new Vector3(-3.5f, 9f, -9.5f);
            }
        }
    }
}
