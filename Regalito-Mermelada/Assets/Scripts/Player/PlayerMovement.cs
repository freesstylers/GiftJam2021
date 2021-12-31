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
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(-hor, 0f, -ver);
        dir = playerRot.TransformDirection(dir);
        cController.Move(dir * speed * Time.deltaTime);

        gameObject.GetComponent<Animator>().SetInteger("Horizontal", -(int) dir.x);
        gameObject.GetComponent<Animator>().SetInteger("Vertical", -(int)dir.z);
    }

    void HandleCamera()
    {
        float l = Convert.ToInt32(Input.GetKey(KeyCode.Q));
        float r = Convert.ToInt32(Input.GetKey(KeyCode.E));

        playerRot.Rotate(Vector3.up, (r - l) * rotSpeed);
    }
}
