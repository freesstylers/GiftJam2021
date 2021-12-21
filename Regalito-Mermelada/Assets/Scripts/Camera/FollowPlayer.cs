using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTr_;
    Transform tr_;

    private void Start()
    {
        tr_ = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr_.position = new Vector3(playerTr_.position.x, tr_.position.y, playerTr_.position.z-5);
    }
}
