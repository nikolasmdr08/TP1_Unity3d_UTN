using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int _score;
    public static bool _activeShield;
    public GameObject _gameOver;
    public GameObject _winGame;

    // Start is called before the first frame update
    void Start() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }

    public void gameOver() {
        _gameOver.SetActive(true);
    }

    public void winLevel() {
        _winGame.SetActive(true);
    }

    public void nextLVL(string lvl) {
        //Application.LoadLevel(lvl); // comentado ya que unity da error, informa obsoleto
        if (lvl != "") {
            SceneManager.LoadScene(lvl);
        }
    }

}

