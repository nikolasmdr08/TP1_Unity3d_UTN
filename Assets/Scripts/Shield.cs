using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float timeLife = 10f;
    public GameObject target;

    private void Awake() {
        Invoke("destroy", timeLife);
    }

    private void destroy() {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("bulletEnemy")|| other.gameObject.CompareTag("Enemy")) {
            Destroy(other.gameObject);
        }
    }


}
