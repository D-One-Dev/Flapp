using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private bool isGameOn = false;
    public GameObject canv;
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
        }
    }
}
