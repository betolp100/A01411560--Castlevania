using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipSound : MonoBehaviour
{
    private SoundManager soundManager;
    

    private void Awake()
    {
        if (!soundManager) soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Background")
        {
            Debug.Log("JISUS");  //if we didnt hit an objet or enemy
            soundManager.PlaySong(2);
        } else

        if (coll.gameObject.layer == 9)
        { //if wee hit something destroyable
            GameObject.Find("Stats").GetComponent<Stats>().score  = GameObject.Find("Stats").GetComponent<Stats>().score + 100;
            soundManager.PlaySong(3);
        }

        
    }
}
