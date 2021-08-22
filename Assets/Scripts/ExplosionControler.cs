using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControler : MonoBehaviour
{
    public GameObject explode;
    public GameObject soundExplode;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        Invoke("selfDestruct", timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selfDestruct() {
        Instantiate(soundExplode, transform.position, transform.rotation);
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
