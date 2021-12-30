using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoor : MonoBehaviour
{
    public bool move = false;
    public int dir = 1;

    public GameObject leftDoor;
    public GameObject rightDoor;

    Vector3 leftDoorPos;
    Vector3 rightDoorPos;

    public float dist = 4.0f;
    public float speed = 0.4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dir = 1;
            move = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dir = -1;
            move = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (leftDoor) leftDoorPos = leftDoor.transform.localPosition;
        if (rightDoor) rightDoorPos = rightDoor.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float step = speed * Time.deltaTime;

            Vector3 goalLeftPos = leftDoorPos;
            Vector3 goalRightPos = rightDoorPos;

            if(dir > 0)
            {
                goalLeftPos += new Vector3(0, 0, dist);
                goalRightPos -= new Vector3(0, 0, dist);
            }

            Vector3 newLeftPos = Vector3.MoveTowards(leftDoor.transform.localPosition, goalLeftPos, step);
            Vector3 newRightPos = Vector3.MoveTowards(rightDoor.transform.localPosition, goalRightPos, step);

            leftDoor.transform.localPosition = newLeftPos;
            rightDoor.transform.localPosition = newRightPos;
            
            move = !goalLeftPos.Equals(newLeftPos);
        }
    }
}
