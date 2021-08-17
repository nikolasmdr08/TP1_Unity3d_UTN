using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLife : MonoBehaviour
{
    public float timeLife = 0.1f;

    private void Awake()
    {
        Invoke("destroy", timeLife);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
