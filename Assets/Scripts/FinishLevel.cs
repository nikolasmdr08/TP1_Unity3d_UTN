using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int countEnemys;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            print("colisiono meta");
            GameObject[] cant = GameObject.FindGameObjectsWithTag("Enemy");
            countEnemys = cant.Length;

            if (countEnemys == 0) {
                GameManager.Instance.winLevel();
            }
        }
    }
}
