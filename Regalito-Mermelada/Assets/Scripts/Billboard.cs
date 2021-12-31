using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var target = FindObjectOfType<PlayerMovement>().transform.position;

        target.y = transform.position.y;
        transform.LookAt(target);
    }
}
