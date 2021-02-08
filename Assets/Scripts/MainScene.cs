using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text txt;
    public Outline oLine;
    private GameObject pipe1Down, pipe1Up;
    public GameObject pipe1DownPf, pipe1UpPf;
    private float downPipePos;
    void Start()
    {
        pipe1Down = Instantiate(pipe1DownPf, new Vector3(8f,Random.Range(-10.75f, -4.15f),0f), Quaternion.identity) as GameObject;
        downPipePos = pipe1Down.GetComponent<Transform>().localPosition.y;
        pipe1Up = Instantiate(pipe1UpPf, new Vector3(8f, Random.Range(downPipePos + 14f, downPipePos + 19f), -1f), Quaternion.identity) as GameObject;
    }
    void Update()
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong(Time.time, 1f));
        oLine.effectColor = new Color(oLine.effectColor.r, oLine.effectColor.g, oLine.effectColor.b, txt.color.a);
        if (pipe1Down.GetComponent<Transform>().position.x <= -7)
        {
            pipe1Down.transform.position = new Vector3(8f, Random.Range(-10.75f, -4.15f), 0f);
            downPipePos = pipe1Down.GetComponent<Transform>().localPosition.y;
            pipe1Up.transform.position = new Vector3(8f, Random.Range(downPipePos + 14f, downPipePos + 19f), -1f);
        }
    }
}
