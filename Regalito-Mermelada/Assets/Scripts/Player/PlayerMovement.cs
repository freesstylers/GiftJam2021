using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement behaviour")]
    public float speed = 1f;
    public CharacterController cController;
    private Transform playerRot;
    
    [Header("Camera behaviour")]
    public float rotSpeed;

    public bool canMove = true;

    void Start()
    {
        playerRot = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        HandleMovement();
        HandleCamera();
    }


    void HandleMovement()
    {
        float hor;
        float ver;

        if (canMove)
        {
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");
        }
        else
        {
            hor = ver = 0.0f;
        }

        Vector3 dir = new Vector3(-hor, 0f, -ver);
        dir = playerRot.TransformDirection(dir);
        cController.Move(dir * speed * Time.deltaTime);

        int signX = (hor == 0f) ? 0 : -(int)Mathf.Sign(hor);
        int signZ = (ver == 0f) ? 0 : -(int)Mathf.Sign(ver);

        if (Mathf.Abs(hor) >= Mathf.Abs(ver)) signZ = 0;
        else signX = 0;

        gameObject.GetComponent<Animator>().SetInteger("Horizontal", signX);
        gameObject.GetComponent<Animator>().SetInteger("Vertical", signZ);
    }

    void HandleCamera()
    {
        float hor = Input.GetAxis("CamHorizontal");

        playerRot.Rotate(Vector3.up, -hor * rotSpeed);
    }
}
