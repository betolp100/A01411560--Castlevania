using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public Text lifes, countdown, scoreText;
    public int score=0;
    public int countdownI;
    public float timeLeft;
    public bool changeScene=false;

    private void Start()
    {
        StartCoroutine(Counter());
        timeLeft = 350;
        
    }


    // Update is called once per frame
    void Update () {
        
        lifes.text = GameObject.Find("Player").GetComponent<Player>().lives.ToString();
        scoreText.text = score.ToString();   //some user interface game stats command

       timeLeft -= Time.deltaTime;
        countdownI = Mathf.FloorToInt(timeLeft);
       countdown.text = countdownI.ToString();
       Debug.Log(countdownI);
         
    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(350f);
        changeScene = true;
    }

}
