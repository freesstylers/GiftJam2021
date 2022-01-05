using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeContainer : MonoBehaviour
{
    [SerializeField]
    List<GameObject> array;
    [SerializeField]
    float trees = 12;
    [SerializeField]
    float maxZ = 100.0f;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    bool left = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trees; i++)
        {
            GameObject aux = Instantiate(prefab, this.transform);
            Vector3 v = new Vector3(0,0,0);

            if (left)
                v.x = -4;
            else
                v.x = 4;

            v.z = maxZ - 10 * i;

            aux.transform.position = v;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
