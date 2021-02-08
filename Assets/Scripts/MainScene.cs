using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text txt;
    public Outline oLine;
    private GameObject pipe1Down, pipe1Up, pipe2Down, pipe2Up;
    public GameObject pipeDownPf, pipeUpPf;
    public bool enableText = true;
    private float downPipe1PosX, downPipe1PosY, downPipe2Pos;
    void Start()
    {
        pipe1Down = Instantiate(pipeDownPf, new Vector3(Random.Range(6.5f, 8f),Random.Range(-10.75f, -4.15f),0f), Quaternion.identity) as GameObject;
        downPipe1PosY = pipe1Down.GetComponent<Transform>().localPosition.y;
        downPipe1PosX = pipe1Down.GetComponent<Transform>().localPosition.x;
        pipe1Up = Instantiate(pipeUpPf, new Vector3(Random.Range(6.5f, 8f), Random.Range(downPipe1PosY + 14f, downPipe1PosY + 19f), -1f), Quaternion.identity) as GameObject;
        //
        pipe2Down = Instantiate(pipeDownPf, new Vector3(downPipe1PosX + Random.Range(4f, 8f), Random.Range(-10.75f, -4.15f), 0f), Quaternion.identity) as GameObject;
        downPipe2Pos = pipe2Down.GetComponent<Transform>().localPosition.y;
        pipe2Up = Instantiate(pipeUpPf, new Vector3(pipe2Down.GetComponent<Transform>().localPosition.x, Random.Range(downPipe2Pos + 14f, downPipe2Pos + 19f), -1f), Quaternion.identity) as GameObject;
    }
    void Update()
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
            if (txt.GetComponent<RectTransform>().offsetMax.y > -1000f)
            {
                txt.GetComponent<RectTransform>().offsetMax += new Vector2(txt.GetComponent<RectTransform>().offsetMax.x, -10f);
                txt.GetComponent<RectTransform>().offsetMin += new Vector2(txt.GetComponent<RectTransform>().offsetMin.x, -10f);
            }
        }
        if (pipe1Down.GetComponent<Transform>().position.x <= -7)
        {
            pipe1Down.transform.position = new Vector3(Random.Range(6.5f, 8f), Random.Range(-10.75f, -4.15f), 0f);
            downPipe1PosY = pipe1Down.GetComponent<Transform>().localPosition.y;
            pipe1Up.transform.position = new Vector3(Random.Range(6.5f, 8f), Random.Range(downPipe1PosY + 14f, downPipe1PosY + 19f), 0f);
        }
        else if (pipe2Down.GetComponent<Transform>().position.x <= -7)
        {
            pipe2Down.transform.position = new Vector3(downPipe1PosX, Random.Range(-10.75f, -4.15f), 0f);
            downPipe2Pos = pipe2Down.GetComponent<Transform>().localPosition.y;
            pipe2Up.transform.position = new Vector3(pipe2Down.GetComponent<Transform>().localPosition.x, Random.Range(downPipe1PosY + 14f, downPipe1PosY + 19f), 0f);
        }
    }
}
