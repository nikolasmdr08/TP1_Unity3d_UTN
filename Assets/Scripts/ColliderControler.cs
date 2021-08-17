using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControler : MonoBehaviour
{
    public string targetCollision;
    public string mycollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        bool isMe = collision.gameObject.CompareTag(mycollider);
        if (!isMe) {
            bool isTarget = collision.gameObject.CompareTag(targetCollision);
            if (isTarget) {
                print("enemigo");
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Limit")) {
                print("pared");
                Destroy(gameObject);
            }
        }
    }
}
