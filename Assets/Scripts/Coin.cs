using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float timeLife = 3f;
    public GameObject soundCoin;

    private void Awake() {
        Invoke("destroy", timeLife);
    }

    private void destroy() {
        Destroy(gameObject);
    }
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
            Instantiate(soundCoin, gameObject.transform.position, gameObject.transform.rotation);
            GameManager._score += 500;
            Destroy(gameObject);
        }
    }

}
