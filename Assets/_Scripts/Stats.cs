using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public Text lifes, countdown, scoreText;
    public int score;
    public int countdownI;
    public float timeLeft;

    private void Start()
    {
        score = 0;
    }


    // Update is called once per frame
    void Update () {
        Debug.Log(score);
        lifes.text = GameObject.Find("Player").GetComponent<Player>().lives.ToString();
        scoreText.text = score.ToString();   //some user interface game stats command

       timeLeft -= Time.deltaTime;
        countdownI = Mathf.FloorToInt(timeLeft);
       countdown.text = countdownI.ToString();
        Debug.Log(timeLeft  );
        if (timeLeft < 0)
        {
            
            Debug.Log("GameOver");
        }   
    }

}
