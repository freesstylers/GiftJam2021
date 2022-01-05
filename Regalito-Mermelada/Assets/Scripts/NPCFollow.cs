using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform target;
    public float targetDist;
    public float speed;
    public float minT, maxT;

    private bool stop = true;
    private float angle = 0;
    private int factor = 1;

    private void Start()
    {
        Stop();
    }

    private void Update()
    {
        if((transform.position - target.position).magnitude < targetDist)
        {
            Vector3 p = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(p);
        }
        else
        {        
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 2.0f))
            {
                angle += Time.deltaTime * factor;
                transform.Rotate(Vector3.up, angle);
            }
            else if(!stop)
            {
                WalkForward();
            }
        }
    }

    void Stop()
    {
        if (stop)
        {
            stop = false;
            transform.Rotate(Vector3.up, Random.Range(0.0f, 360.0f));
            Invoke("Stop", Random.Range(minT, maxT));
            factor *= -1;
        }
        else
        {
            stop = true;
            Invoke("Stop", Random.Range(minT, maxT));
        }
    }

    void WalkForward()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
    }
}
