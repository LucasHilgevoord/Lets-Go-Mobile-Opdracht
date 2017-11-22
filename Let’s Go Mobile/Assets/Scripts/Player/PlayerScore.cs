using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private float score = 0.0f;
    private bool _alive = true;

    public Text scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _alive = PlayerDie.IsAlive;

        if (_alive)
        {
            score += Time.deltaTime * 2;
            scoreText.text = ((string)"-=") + ((int)score).ToString() + ((string)"=-");
        }

    }
}
