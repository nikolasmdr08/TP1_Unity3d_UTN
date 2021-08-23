using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    public GameObject shield;
    public GameObject soundShield;
    public float timeLife = 3f;

    private void Awake() {
        Invoke("destroy", timeLife);
    }

    private void destroy() {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GameManager._activeShield = true;
            Instantiate(shield, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(soundShield, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
