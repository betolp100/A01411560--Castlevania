using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour {

    public Text start;
    protected Text T;
    private bool started = false;
    public bool begin = false;

    private void Start()
    {
        start = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && started==false)
        {
            started = true;
            StartCoroutine(Twinkle());
        }
	}

    IEnumerator Twinkle()
    {  //Twink the game start 3 times
        yield return new WaitForSeconds(0.15f);
        start.enabled = false;
        yield return new WaitForSeconds(0.15f);
        start.enabled = true;
        yield return new WaitForSeconds(0.15f);
        start.enabled = false;
        yield return new WaitForSeconds(0.15f);
        start.enabled = true;
        yield return new WaitForSeconds(0.15f);
        start.enabled = false;
        yield return new WaitForSeconds(0.15f);
        start.enabled = true;
        begin = true;
    }
}
