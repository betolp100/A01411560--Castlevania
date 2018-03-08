using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Fire());
	}

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
