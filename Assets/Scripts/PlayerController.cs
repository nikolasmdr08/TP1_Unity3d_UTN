using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedMove = 2f;

    public GameObject modelo;
    public GameObject mira;
    private Animator anim;

    private bool isShooting = false;
    private bool isMoving = false;
    private bool isDeath = false;

    public GameObject bullet;
    public GameObject soundBullet;
    public GameObject soundDeath;

    // Start is called before the first frame update
    void Start()
    {
        anim = modelo.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShooting)
        {
            move(); // control movimiento
        }

        shoot(); // control de disparo
        Animation(); // control de animacion
    }

    private void move()
    {
        /// desplazamiento de personaje
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speedMove * Time.deltaTime);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speedMove * Time.deltaTime);
            isMoving = true;
        }

        if (!Input.anyKey) ///control para animacion idle
        {
            isMoving = false;
        }
    }

    private void shoot()
    {
        ///rotacion segun lugar de disparo
        if (!isShooting)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionShoot("forward");
            }
            else
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    directionShoot("back");
                }
                else
                {
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        directionShoot("right");
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            directionShoot("left");
                        }
                    }
                }
            }
        }
    }

    private void directionShoot(string direction)
    {
        changeState();
        //roto el disparador segun la flecha precionada
        switch (direction)
        {
            case "forward":
                modelo.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                mira.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Instantiate(bullet, mira.transform.position, mira.transform.rotation);
                break;
            case "back":
                modelo.transform.eulerAngles = new Vector3(0, 180, 0);
                mira.transform.eulerAngles = new Vector3(0, 180, 0);
                Instantiate(bullet, mira.transform.position, mira.transform.rotation);
                break;
            case "right":
                modelo.transform.eulerAngles = new Vector3(0, 90, 0);
                mira.transform.eulerAngles = new Vector3(0, 90, 0);
                Instantiate(bullet, mira.transform.position, mira.transform.rotation);
                break;
            default:
                modelo.transform.eulerAngles = new Vector3(0, 270, 0);
                mira.transform.eulerAngles = new Vector3(0, 270, 0);
                Instantiate(bullet, mira.transform.position, mira.transform.rotation);
                break;
        }
        Instantiate(soundBullet, mira.transform.position, mira.transform.rotation);
        Invoke("changeState", 0.5f);
    }
    private void changeState()
    {
        isShooting = !isShooting;
    }

    private void Animation()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isShooting", isShooting);
        anim.SetBool("isDeath", isDeath);
    }

    private void OnDestroy() {
        Instantiate(soundDeath, gameObject.transform.position, gameObject.transform.rotation);
    }
}
