using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private SoundManager soundManager;
    private LevelManager levelManager;
    [HideInInspector]
    public bool endLevel = false;
    [HideInInspector]
    public bool reachDoor = false;     //some variable...
    public Transform waypoint;
    public GameObject player;
    protected Animator animator;
    protected Animator playerAnimator;
    public float speedWalk;
	void Start ()
    {
        animator = GetComponent<Animator>();   
        playerAnimator = player.GetComponent<Animator>();
        animator.SetBool("End", false);
    }
    //Instantiating components
    private void Awake()
    {
        if (!soundManager) soundManager = GameObject.FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (reachDoor == true)
        {
            StartCoroutine(LoadNextRoom());
        }
    }

    IEnumerator LoadNextRoom()
    {
        //Once we reach to the door, we change the scene
        playerAnimator.SetInteger("Speed", 0);
        yield return new WaitForSeconds(1f);

        playerAnimator.SetInteger("Speed", 1);
        Vector3 dir = waypoint.position - player.transform.position;
        float distanceThisFrame = speedWalk * Time.deltaTime;
        player.transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        yield return new WaitForSeconds(1.5f);
        animator.SetBool("End", false);

        yield return new WaitForSeconds(2.4f);
        endLevel = true;
        reachDoor = false;


    }   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { //When colliding with player
            soundManager.PlaySong(5);
            Destroy(GameObject.Find("MusicManager"));
            
            animator.SetBool("End", true);
            playerAnimator.SetInteger("Speed", 1);
            reachDoor = true;
            
        }
    }


}
