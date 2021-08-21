using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject creditos;
    public GameObject principal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetKey(KeyCode.X))
        {
            principal.SetActive(false);
            creditos.SetActive(false);
            tutorial.SetActive(true);
        }
        if (Input.GetKey(KeyCode.C))
        {
            principal.SetActive(false);
            tutorial.SetActive(false);
            creditos.SetActive(true);
        }
        if (Input.GetKey(KeyCode.V))
        {
            Application.Quit();
        }
    }
}
