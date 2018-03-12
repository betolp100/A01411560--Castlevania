using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{

    public GameObject firePrefab;
    public GameObject batSprites;
    private bool isPlayerNear = false;
    public Transform player;
    public GameObject curve;
    private Animator animator, animatorCurve;
    private Vector3 fly;
    public float speed;
    // Update is called once per frame
    private void Start()
    {
        animator = batSprites.GetComponent<Animator>();
        animatorCurve = curve.GetComponent<Animator>();
        animatorCurve.SetBool("StartFlying", false);
        animator.SetBool("Flying", false);
    }

    void Update()
    {
        if (isPlayerNear == true)
        {// move to player
            Vector3 dir = player.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {//when player collide with the sensor start flying
            animator.SetBool("Flying", true);
            animatorCurve.SetBool("StartFlying", true);
            isPlayerNear = true;
        }
    }
}