using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbundioCadaver : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(movement());
    }

    public Vector3 door;
    public Vector3 finalPoint;

    IEnumerator movement()
    {
        FindObjectOfType<PlayerMovement>().canMove = false;

        while (transform.localPosition != door)
        {
            float step = 1.5f * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, door, step);
            yield return null;
        }

        while (transform.localPosition != finalPoint)
        {
            float step = 1.5f * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPoint, step);
            yield return null;
        }

        FindObjectOfType<PlayerMovement>().canMove = true;
    }
}