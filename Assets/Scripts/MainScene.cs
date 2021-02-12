using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text txt;
    public Outline oLine;
    public bool enableText = true, gamePause = false;
    public GameObject pipe1, pipe2, pipe1Down, pipe1Up, pipe2Down, pipe2Up, pause; 
    void Start()
    {
        pipe1Down.transform.position = new Vector3(0f, Random.Range(-14f, -6f), 8f);
        pipe1Up.transform.position = new Vector3(0f, Random.Range(pipe1Down.transform.position.y + 18f, pipe1Down.transform.position.y + 21f), 8f);
        pipe1.transform.position = new Vector3(8f, 0f, 0f);

        pipe2Down.transform.position = new Vector3(0f, Random.Range(-14f, -6f), 8f);
        pipe2Up.transform.position = new Vector3(0f, Random.Range(pipe2Down.transform.position.y + 18f, pipe2Down.transform.position.y + 21f), 8f);
        pipe2.transform.position = new Vector3(16f, 0f, 0f);
    }
    void FixedUpdate()
    {
        if (!gamePause)
        {
            if (enableText)
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time, 1f));
                oLine.effectColor = new Color(oLine.effectColor.r, oLine.effectColor.g, oLine.effectColor.b, txt.color.a);
            }
            else
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1f);
                oLine.effectColor = new Color(oLine.effectColor.r, oLine.effectColor.g, oLine.effectColor.b, 1f);
                txt.GetComponent<RectTransform>().localPosition = new Vector2(txt.GetComponent<RectTransform>().localPosition.x, -750);
                txt.text = ("0");
                txt.fontSize = 200;
                oLine.effectDistance = new Vector2(4, -4);

                pause.transform.position = new Vector3(-3.5f, 9f, -9.5f);
            }
        }
    }
}
