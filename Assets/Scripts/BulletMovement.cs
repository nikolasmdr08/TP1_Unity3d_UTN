using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20;
    public float timeLife = 2f;

    private void Awake() {
        Invoke("destroy", timeLife);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    private void destroy() {
        Destroy(gameObject);
    }
}
