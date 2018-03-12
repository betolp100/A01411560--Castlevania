using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : MonoBehaviour
{

    public GameObject firePrefab;
    private Vector3 fly;
    private bool medusaDead=false;
    public float speed;
    //move medusa to the right
    public void Update()
    {
            fly.x = 1;
            transform.position += fly * speed * Time.deltaTime;
    }
}
