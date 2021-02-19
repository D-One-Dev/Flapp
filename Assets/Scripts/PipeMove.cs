using UnityEngine;

public class PipeMove : MonoBehaviour
{
    //objects references
    public GameObject pipeDown, pipeUp;
    //is pipe moving | had pipe passed
    public bool pipeMove = true, pipePassed = false;
    //pipe speed
    public float pipeSpeed;
    void FixedUpdate()
    {
        //if pipe moving is enabled
        if (pipeMove)
        {
            //move the pipe
            transform.position += new Vector3((-pipeSpeed/10), 0f, 0f);
            //teleportation to the beginning
            if (transform.position.x <= -6.5f)
            {
                //new x position
                transform.position = new Vector3(36f, 0f, 0f);
                //new lower pipe y position
                pipeDown.transform.localPosition = new Vector3(0f, Random.Range(-14f, -6f), 8f);
                //new upper pipe y position
                pipeUp.transform.localPosition = new Vector3(0f, Random.Range(pipeDown.transform.position.y + 22f, pipeDown.transform.position.y + 24f), 8f);
                pipePassed = false;
            }
        }
    }
}
