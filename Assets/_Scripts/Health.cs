using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    protected Image image;
    public Sprite[] spriteArray;

    private void Start()
    {
        
        image = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update ()
    { //health bar per life
            if (GameObject.Find("Player").GetComponent<Player>().health >= 32)
            {

                image.sprite = spriteArray[16];
            }

            if (GameObject.Find("Player").GetComponent<Player>().health <= 30)
            {
                image.sprite = spriteArray[15];
            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 28)
            {
                image.sprite = spriteArray[14];

            }

            if (GameObject.Find("Player").GetComponent<Player>().health <= 26)
            {
                image.sprite = spriteArray[13];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 24)
            {
                image.sprite = spriteArray[12];
            }

            if (GameObject.Find("Player").GetComponent<Player>().health <= 22)
            {
                image.sprite = spriteArray[11];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 20)
            {
                image.sprite = spriteArray[10];

            }

            if (GameObject.Find("Player").GetComponent<Player>().health <= 18)
            {
                image.sprite = spriteArray[9];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 16)
            {
                image.sprite = spriteArray[8];

            }

            if (GameObject.Find("Player").GetComponent<Player>().health <= 14)
            {
                image.sprite = spriteArray[7];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 12)
            {
                image.sprite = spriteArray[6];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 10)
            {
                image.sprite = spriteArray[5];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 8)
            {
                image.sprite = spriteArray[4];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 6)
            {
                image.sprite = spriteArray[3];

            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 4)
            {
                image.sprite = spriteArray[2];
 
            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 2)
            {
                image.sprite = spriteArray[1];
  
            }
            if (GameObject.Find("Player").GetComponent<Player>().health <= 1)
            {
                image.sprite = spriteArray[0];


            } 
	}
}
