using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //control ataque
    public GameObject target;
    public GameObject mira;
    public float shootingDistance = 20f;
    public GameObject bullet;
    public bool isAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            if (Vector3.Distance(transform.position, target.transform.position) < shootingDistance && !isAttack) {
                // cambio el valor para limitar los disparos
                changeState();
                //comienzo a disparar al player cuendo la distancia es 12 o menos
                Instantiate(bullet, mira.transform.position, mira.transform.rotation);
                Invoke("changeState", 0.5f);
            }
        }
    }

    void changeState() {
        isAttack = !isAttack;
    }
}
