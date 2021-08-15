using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedMove = 2f;

    public GameObject modelo;
    private Animator anim;

    public bool isShooting = false;
    private bool isMoving = false;
    private bool isDeath = false;

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
                //Instantiate(bullet, Shooter.transform.position, Shooter.transform.rotation);
                break;
            case "back":
                modelo.transform.eulerAngles = new Vector3(0, 180, 0);
                //Instantiate(bullet, Shooter.transform.position, Shooter.transform.rotation);
                break;
            case "right":
                modelo.transform.eulerAngles = new Vector3(0, 90, 0);
                //Instantiate(bullet, Shooter.transform.position, Shooter.transform.rotation);
                break;
            default:
                modelo.transform.eulerAngles = new Vector3(0, 270, 0);
                //Instantiate(bullet, Shooter.transform.position, Shooter.transform.rotation);
                break;
        }
        Invoke("changeState", 0.5f);
    }
    private void changeState()
    {
        isShooting = !isShooting;
    }

    private void Animation()
    {
        Debug.Log(isMoving);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isShooting", isShooting);
        anim.SetBool("isDeath", isDeath);
    }
}
