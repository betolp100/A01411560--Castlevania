using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

    public GameObject firePrefab;
// destroy candle 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Whip")
        {
            Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
