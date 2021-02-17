using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public GameObject pipeDown, pipeUp;
    public bool pipeMove = true, pipePassed = false;
    public float pipeSpeed;
    void FixedUpdate()
    {
        if (pipeMove)
        {
            transform.position += new Vector3((-pipeSpeed/10), 0f, 0f);
            if (transform.position.x <= -6.5f)
            {
                transform.position = new Vector3(36f, 0f, 0f);
                pipeDown.transform.localPosition = new Vector3(0f, Random.Range(-14f, -6f), 8f);
                pipeUp.transform.localPosition = new Vector3(0f, Random.Range(pipeDown.transform.position.y + 22f, pipeDown.transform.position.y + 24f), 8f);
                pipePassed = false;
            }
        }
    }
}
