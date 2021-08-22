using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public float timeLife = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(other.gameObject);
            GameManager.Instance.gameOver();
        }
    }

    

    private void Awake() {
        Invoke("destroy", timeLife);
    }

    private void destroy() {
        Destroy(gameObject);
    }
}
