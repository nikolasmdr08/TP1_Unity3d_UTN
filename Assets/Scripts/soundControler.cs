using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControler : MonoBehaviour
{
    public float duracion;
    // Start is called before the first frame update

    private void Awake() {
        Invoke("Destroy", duracion);
    }

    private void Destroy() {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
