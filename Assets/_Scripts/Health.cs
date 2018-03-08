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
    {
            if (GameObject.Find("Player").GetComponent<Player>().lives == 16)
            {
                image.sprite = spriteArray[16];
            }

            if (GameObject.Find("Player").GetComponent<Player>().lives == 15)
            {
                image.sprite = spriteArray[15];
            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 14)
            {
                image.sprite = spriteArray[14];

            }

            if (GameObject.Find("Player").GetComponent<Player>().lives == 13)
            {
                image.sprite = spriteArray[13];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 12)
            {
                image.sprite = spriteArray[12];
            }

            if (GameObject.Find("Player").GetComponent<Player>().lives == 11)
            {
                image.sprite = spriteArray[11];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 10)
            {
                image.sprite = spriteArray[10];

            }

            if (GameObject.Find("Player").GetComponent<Player>().lives == 9)
            {
                image.sprite = spriteArray[9];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 8)
            {
                image.sprite = spriteArray[8];

            }

            if (GameObject.Find("Player").GetComponent<Player>().lives == 7)
            {
                image.sprite = spriteArray[7];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 6)
            {
                image.sprite = spriteArray[6];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 5)
            {
                image.sprite = spriteArray[5];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 4)
            {
                image.sprite = spriteArray[4];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 3)
            {
                image.sprite = spriteArray[3];

            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 2)
            {
                image.sprite = spriteArray[2];
 
            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 1)
            {
                image.sprite = spriteArray[1];
  
            }
            if (GameObject.Find("Player").GetComponent<Player>().lives == 0)
            {
                image.sprite = spriteArray[0];

            } 
	}
}
