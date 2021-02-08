using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    //private float posX, posY;
    void Start()
    {

    }
    void FixedUpdate()
    {
        transform.position -= new Vector3(0.1f, 0f, 0f);
    }
}
