using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    [SerializeField]
    float minZ = -4.5f;
    [SerializeField]
    float startZ = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > minZ)
        {
            Vector3 v = transform.position;
            v.z -= 0.1f;
            transform.position = v;
        }
        else
        {
            Vector3 v = transform.position;
            v.z = startZ;
            transform.position = v;
        }
    }
}
