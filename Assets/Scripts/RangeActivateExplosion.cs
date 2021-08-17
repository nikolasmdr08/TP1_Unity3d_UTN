using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeActivateExplosion : MonoBehaviour
{
    public GameObject explode;
    public GameObject target;
    public float range =2f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            if (Vector3.Distance(transform.position, target.transform.position) < range) {
                Instantiate(explode, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}