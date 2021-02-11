using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public GameObject pipeDown, pipeUp;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(-0.1f, 0f, 0f);
        if (transform.position.x <= -6.5f)
        {
            transform.position = new Vector3(8f, 0f, 0f);
            pipeDown.transform.localPosition = new Vector3(0f, Random.Range(-14f, -6f), 8f);
            pipeUp.transform.localPosition = new Vector3(0f, Random.Range(pipeDown.transform.position.y + 18f, pipeDown.transform.position.y + 21f), 8f);
        }
    }
}
