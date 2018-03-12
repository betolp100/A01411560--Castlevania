using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Camera : MonoBehaviour {

    public float minY, maxY; // .1         2.8
    public float minX, maxX; // 2.2             12

    public Transform player;
    public Vector3 offset;

    private bool limitReached;
    // Use this for initialization

    void Update()
    {
        /*Vector3 camaraPos = new Vector3(player.position.x + offset.x , player.transform.position.y  + offset.y, offset.z); // Camera follows the player with specified offset position
       if (camaraPos.x > minX && camaraPos.x < maxX)
        {
            transform.position = camaraPos;
        }*/
        //pan camera to player
        transform.position = new Vector3(player.position.x + offset.x, player.transform.position.y + offset.y, offset.z);
    }
}
