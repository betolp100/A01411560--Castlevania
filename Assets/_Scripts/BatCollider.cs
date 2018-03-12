using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCollider : MonoBehaviour {

    public GameObject firePrefab;
    
    private bool isPlayerNear = false;
    public Transform player;
    protected Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
     //no desc need it   
        if (collision.gameObject.tag == "Whip")
        {
            Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
