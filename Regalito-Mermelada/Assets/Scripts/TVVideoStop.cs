using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVVideoStop : MonoBehaviour
{
    public VideoPlayer v;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            v.Stop();
        }
    }
}
