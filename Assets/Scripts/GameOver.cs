﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKey(KeyCode.X)) {
            Application.Quit();
        }
    }
}
