using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour {

    public bool ready = false;
    void Start () {
        StartCoroutine(ChangeScene());
    }
     //a countdown script
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(10f);
        ready = true;
    }
}
