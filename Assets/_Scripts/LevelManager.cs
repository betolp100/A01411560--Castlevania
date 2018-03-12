using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

   
    Scene currentScene;
    
    public static LevelManager instance = null;


    private void Awake()
    {
            if (instance == null)
                instance = this;
            else if (instance != this)   //Singleton Algorythm
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void QuitLevel()
    {
        Debug.Log("Game Finished");
        Application.Quit();   //End game
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }   //Load level

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  //Load next level
    }
    private void Update()
    {
        if (GameObject.Find("Start") != null)
        { //move feom the start to level00
            if (GameObject.Find("Start").GetComponent<StartScene>().begin == true)
            {
                Debug.Log("Cambiando de escena");
                LoadNextLevel();
            }
        }

        if (GameObject.Find("CountDown") != null)
        {
            if (GameObject.Find("CountDown").GetComponent<CountdownTimer>().ready == true)
            {//move from level 01
                Debug.Log("Cambiando de escena");
                LoadNextLevel();
            }
        }

        if (GameObject.Find("Door") != null)
        { //move from level01 to next scene in this case win scene
            if (GameObject.Find("Door").GetComponent<Door>().endLevel == true) { LoadNextLevel(); }
        }

        if (GameObject.Find("Stats") != null)
        { 
            if (GameObject.Find("Stats").GetComponent<Stats>().countdownI <=0)
            {
                Debug.Log("Cambiando de escena");
                LoadLevel("Lose");
            }
        }
    }
}
