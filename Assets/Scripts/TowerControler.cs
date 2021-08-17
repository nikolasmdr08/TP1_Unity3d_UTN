using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControler : MonoBehaviour
{
    public GameObject cristal;
    public GameObject mira;
    private GameObject target;
    public GameObject bullet;
    public float distance = 20;
    public float speed = 50;
    bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            if (Vector3.Distance(target.transform.position, mira.transform.position) < distance) {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0f;
                var rotation = Quaternion.LookRotation(lookPos);
                mira.transform.rotation = Quaternion.RotateTowards(mira.transform.rotation, rotation, 2);

                if (!isShooting) {
                    changeState();
                    //shoot
                    Instantiate(bullet, mira.transform.position, mira.transform.rotation);
                    Invoke("changeState", 8f);
                }
            }
            else {
                idle();
            }
        }
        else {
            idle();
        }
    }

    void idle() {
        cristal.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

    void changeState() {
        isShooting = !isShooting;
    }
}
