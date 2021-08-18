using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    GameObject target;
    public float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 pos = new Vector3(x,y,z);
            transform.position = target.transform.position + pos;
        }
    }
}
