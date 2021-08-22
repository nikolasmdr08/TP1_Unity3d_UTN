using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "SCORE: " + GameManager._score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager._score.ToString();
    }
}
