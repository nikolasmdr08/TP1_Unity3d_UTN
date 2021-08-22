using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    //variables para vigilancia
    public int routine;
    public float timer;
    public Quaternion angle;
    public float grade;
    public float speed = 2f;

    public GameObject target;
    public float targetDistanceMax = 35f;

    public bool isAttack = false;
    public bool isMoving = false;

    public GameObject modelo;
    private Animator anim;

    //item spawn
    public GameObject coin;
    public GameObject shield;
    public GameObject kill;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        anim = modelo.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            move(target);
        }
        else {
            move();
        }
        anim.SetBool("isMoving", isMoving);
    }

    private void move() {
        patrol();
    }

    private void move(object tarjet) {
        if (Vector3.Distance(transform.position, target.transform.position) > targetDistanceMax) {
            patrol();
        }
        // si el player esta en rango
        else {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void patrol() {
        timer += 1 * Time.deltaTime; // aumenta 1 por seg

        if (timer >= 4) { // cambio de accion cada 4 seg
            routine = Random.Range(0, 2); //0 o 1
            timer = 0;
        }

        switch (routine) {
            case 0:
                //caso 0 debe quedar en idle
                isMoving = false;
                break;
            case 1: // movimiento al azar
                grade = Random.Range(0, 360); // direccion random 
                angle = Quaternion.Euler(0, grade, 0);
                routine++;
                isMoving = true;
                break;
            case 2: // muevo en la direccion que se marco antes
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    private void changeState() {
        isAttack = !isAttack;
    }

    private void OnDestroy() {
        int probabilidad = Random.Range(0,101);

        if(probabilidad <= 60) {
            Instantiate(coin, transform.position, transform.rotation);
        }
        else {
            if (probabilidad <=90) {
                Instantiate(shield, transform.position, transform.rotation);
            }
            else {
                Instantiate(kill, transform.position, transform.rotation);
            }
        }
    }

}
