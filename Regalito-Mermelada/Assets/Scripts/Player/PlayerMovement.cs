using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    Transform tr_;
    private void Start()
    {
        tr_ = GetComponent<Transform>();
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(hor, 0f, ver).normalized;

        if (dir.magnitude > 0.1f)
        {
            tr_.position += dir * speed * Time.deltaTime;
        }
    }
}
