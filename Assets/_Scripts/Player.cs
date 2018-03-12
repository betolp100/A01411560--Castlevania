using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected BoxCollider2D collider;
    public GameObject player;

    private SoundManager soundManager;

    public Vector3 spawn;
    public float force;
    public int health;
    public int lives;
    public bool dead = false;
    public bool grounded = true;
    public bool jumping = false;
    private bool hitted = false;
    private bool isCrouching = false;
    private bool levelStart;
    public bool trueDead = false;

    private int attackSpeed = 1;
    private int direction = 1;
    public GameObject whipCollider;
    public Transform whipSpawner;

    protected LevelManager levelManager;
    protected Rigidbody2D rigidbody;
    protected Animator animator;
    protected BoxCollider2D boxCol;

    public static Player instance;

    public float scrollSpeed = 1;
    public float speed = 1.5f;
    private int whipLevel = 3;


    void Start()
    { //Instantiating
        Flip();
        animator    = GetComponent<Animator>();
        rigidbody   = GetComponent<Rigidbody2D>();
        collider    = GetComponent<BoxCollider2D>();
        levelManager= GetComponent<LevelManager>();
        boxCol      = whipCollider.GetComponent<BoxCollider2D>();
        levelStart  = true;
    }

    private void Awake()
    { //Instantiating
        if (!soundManager) soundManager = GameObject.FindObjectOfType<SoundManager>();
        if (!levelManager) levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) levelManager.LoadLevel("Win");
        if (grounded == true) jumping = false;
        if (GameObject.Find("Door").GetComponent<Door>().reachDoor == false)
        {
            if (Input.GetKey(KeyCode.Alpha1)) whipLevel = 1;
            if (Input.GetKey(KeyCode.Alpha2)) whipLevel = 2;
            if (Input.GetKey(KeyCode.Alpha3)) whipLevel = 3;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (grounded == true && dead == false) { StartCoroutine (Jump()); }
            }

            if (isCrouching == false && dead == false && hitted == false)
            { //move only when crouchin, when is not dead and whe is not hitted by any enemy
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(Attack());
                }
                if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    if (jumping == false)
                    {
                        animator.SetInteger("Speed", 1);//changing animation to walk
                        direction = -1;
                        Flip();
                        transform.position += Vector3.left * speed *attackSpeed* Time.deltaTime; //with this command we ignore the physics 
                    }
                }
                else if (!Input.GetKey(KeyCode.RightArrow)) { animator.SetInteger("Speed", 0); }

                if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    if (jumping == false)
                    {

                        animator.SetInteger("Speed", 1); //changing animation to walk
                        direction = 1;
                        Flip();
                        transform.position += Vector3.right * speed *attackSpeed* Time.deltaTime;//with this command we ignore the physics 
                    }
                }
                else if (!Input.GetKey(KeyCode.LeftArrow))
                {
                    animator.SetInteger("Speed", 0);
                } //returning to idle
                if (grounded == true) jumping = false;
            }



            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("Squat", true);
                isCrouching = true;
                if (Input.GetKey(KeyCode.Space)) //changing animation to crouch
                {
                    StartCoroutine(Attack()); //changing animation to attack while crouching
                }
            }
            else
            {
                isCrouching = false; // changing to idle
                animator.SetBool("Squat", false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    { //Assigning values while grounded
        if(col.gameObject.tag=="Floor" || col.gameObject.tag== "Platform")
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {//Assigning values while grounded
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Platform")
            grounded = false;
    }

    IEnumerator Attack()
    { //The attacking index, the user can change between whips with 1,2,3
        attackSpeed =  0 ;
        switch (whipLevel)
        {
            case 1:
                {
                    Debug.Log("1");
                    animator.SetInteger("Attack", 1);
                    boxCol.size = new Vector2 (.15f, 0.06f); //creating a hitbox
                    GameObject SpawnWhip = Instantiate(whipCollider, whipSpawner.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.25f);
                    Destroy(SpawnWhip);
                    animator.SetInteger("Attack", 0);
                    break;
                }
            case 2:
                {
                    Debug.Log("2");
                    animator.SetInteger("Attack", 2);//creating a hitbox
                    boxCol.size = new Vector2(.15f, 0.06f);
                    GameObject SpawnWhip = Instantiate(whipCollider, whipSpawner.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.25f);
                    Destroy(SpawnWhip);
                    animator.SetInteger("Attack", 0);
                    break;
                }
            default:
                {
                    Debug.Log("3");
                    animator.SetInteger("Attack", 3);//creating a hitbox
                    boxCol.size = new Vector2(.3f, 0.06f);
                    GameObject SpawnWhip = Instantiate(whipCollider, whipSpawner.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.25f);
                    Destroy(SpawnWhip);
                    animator.SetInteger("Attack", 0);
                    break;
                }
        }
        attackSpeed = 1;
    }

    IEnumerator Jump()
    {
        // jump animation 

        animator.SetBool("Jump", true);
        rigidbody.AddForce(new Vector2(10,14), ForceMode2D.Impulse); //rigidbody.velocity = new Vector2(10000, 3f);
        //jumping = true;
        yield return new WaitUntil(() => grounded == true);
       
        

           

        //rigidbody.AddForce(new Vector3(0f, 15f, 0f), ForceMode2D.Impulse);
        
        animator.SetBool("Jump", false);
        
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ghost" || coll.gameObject.tag == "Knight" || coll.gameObject.tag == "Bat" || coll.gameObject.tag == "Medusa")
        {
            if (health <= 0)
            { //if any anemy kill us...
                
                soundManager.PlaySong(0);
                StartCoroutine(Die());
            }
            else
            { //if any enemy hit us only...
                soundManager.PlaySong(6);
                StartCoroutine(Hit(coll));
            }
        }
    }

    IEnumerator Die() 
    {
        if (levelStart == true)
        {
                attackSpeed = 0;
                levelStart = false; 
                dead = true;
                animator.SetBool("Dead", true);
                lives--;

                yield return new WaitForSeconds(3f);
            if (lives > 0)
            {
                health = 32;
                dead = false;    //If we still have lives we can re spawn
                levelStart = true;
                transform.position = spawn;
                animator.SetBool("Dead", false);
                attackSpeed = 1;
                animator.SetBool("Revive", true);
            } if (lives <= 0) {
                Debug.Log("OLIWIS");
                trueDead = true; }
            
        }

    }

    IEnumerator Hit(Collider2D coll) // method called after player entering an enemy hitbox
    {
        health--;
        animator.SetBool("Hurt", true);
        hitted = true;
        rigidbody.velocity = new Vector2(0,3f);

        yield return new WaitUntil(() => jumping == false); //Function that helps you to start doing something an event
        hitted = false;
        animator.SetBool("Hurt", false);
    }

    public void Flip() // scale the x value of the player in order to always be pointing to the front
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -direction;// the - is due to the default sprites are facing backwards
        transform.localScale = theScale;
    }

    public bool IsGrounded() //verify if player is grounded
    {
        if (grounded==true) return true;
            else return false;
    }

}