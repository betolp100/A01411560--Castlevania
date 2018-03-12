using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaCollider : MonoBehaviour {


    public GameObject firePrefab;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Whip")//destroy when hit whip or deleter
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Deleter")
        {
            Instantiate(firePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
