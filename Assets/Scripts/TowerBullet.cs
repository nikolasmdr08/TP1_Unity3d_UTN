using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    Rigidbody rb;
    GameObject target;


    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        target = GameObject.Find("Player");

        if (target != null) { 
            float forceApplication = 100; //(1 / Vector3.Distance(target.transform.position, transform.position));
            rb.AddForce((target.transform.position - transform.position) * forceApplication);
        }

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {

    }

}
