using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected BoxCollider2D collider;
    public GameObject player;

    
    public float force;
    public int lives;
    public bool dead = false;
    public bool grounded = true;
    public bool jumping = false;
    private bool hitted = false;
    private bool isCrouching = false;

    private int direction = 1;
    public GameObject whipCollider;
    public Transform whipSpawner;

    protected LevelManager levelManger;
    protected Rigidbody2D rigidbody;
    protected Animator animator;
    protected BoxCollider2D boxCol;

    public static Player instance;

    public float scrollSpeed = 1;
    public float speed = 1.5f;
    private int whipLevel = 3;

    void Start()
    {
        Flip();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        levelManger = GetComponent<LevelManager>();
        boxCol = whipCollider.GetComponent<BoxCollider2D>();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Door").GetComponent<Door>().reachDoor == false)
        {
            if (Input.GetKey(KeyCode.Alpha1)) whipLevel = 1;
            if (Input.GetKey(KeyCode.Alpha2)) whipLevel = 2;
            if (Input.GetKey(KeyCode.Alpha3)) whipLevel = 3;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (grounded == true && dead == false) { Jump(); }
            }

            if (isCrouching == false && dead == false && hitted == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(Attack());
                }
                if (Input.GetKey(KeyCode.LeftArrow) && IsGrounded() && !Input.GetKey(KeyCode.DownArrow))
                {
                    animator.SetInteger("Speed", 1);

                    direction = -1;
                    Flip();
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
                else if (!Input.GetKey(KeyCode.RightArrow)) { animator.SetInteger("Speed", 0); }

                if (Input.GetKey(KeyCode.RightArrow) && IsGrounded() && !Input.GetKey(KeyCode.DownArrow))
                {
                    animator.SetInteger("Speed", 1);
                    direction = 1;
                    Flip();
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
                else if (!Input.GetKey(KeyCode.LeftArrow))
                {
                    animator.SetInteger("Speed", 0);
                }
            }



            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("Squat", true);
                isCrouching = true;
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(Attack());
                }
            }
            else
            {
                isCrouching = false;
                animator.SetBool("Squat", false);
            }
        }
        if (hitted == true)
        {
            if (direction == 1)
            {
                Flip();
                transform.position += Vector3.right * 1.5f * Time.deltaTime;

            }
            if (direction == -1)
            {
                Flip();
                transform.position += Vector3.left * 1.5f * Time.deltaTime;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag=="Floor" || col.gameObject.tag== "Platform")
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Platform")
            grounded = false;
    }

    IEnumerator Attack()
    {
        switch (whipLevel)
        {
            case 1:
                {
                    Debug.Log("1");
                    animator.SetInteger("Attack", 1);
                    boxCol.size = new Vector2 (.15f, 0.06f);
                    GameObject SpawnWhip = Instantiate(whipCollider, whipSpawner.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.25f);
                    Destroy(SpawnWhip);
                    animator.SetInteger("Attack", 0);
                    break;
                }
            case 2:
                {
                    Debug.Log("2");
                    animator.SetInteger("Attack", 2);
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
                    animator.SetInteger("Attack", 3);
                    boxCol.size = new Vector2(.3f, 0.06f);
                    GameObject SpawnWhip = Instantiate(whipCollider, whipSpawner.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.25f);
                    Destroy(SpawnWhip);
                    animator.SetInteger("Attack", 0);
                    break;
                }
        }
    }

    void Jump()
    {
        // jump animation 

        animator.SetBool("Jump", true);
        jumping = true;
        rigidbody.velocity =new Vector2(0,3f);

        while (jumping == true)
        {
            if (direction == 1 && Input.GetKey(KeyCode.RightArrow))
            {
                Flip();
                transform.position += Vector3.right * 1.5f * Time.deltaTime;
                if(grounded==true) jumping = false;
            }
            if (direction == -1 && Input.GetKey(KeyCode.LeftArrow))
            {
                Flip();
                transform.position += Vector3.left * 1.5f * Time.deltaTime;
                if (grounded == true) jumping = false;
            }
        }

        //rigidbody.AddForce(new Vector3(0f, 15f, 0f), ForceMode2D.Impulse);
        
        animator.SetBool("Jump", false);
        
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ghost" || coll.gameObject.tag == "Knight" || coll.gameObject.tag == "Bat" || coll.gameObject.tag == "Medusa")
        {
            if (lives <= 0)
            {
                StartCoroutine(Die());
            }
            else
            {
                StartCoroutine(Hit(coll));
            }
        }
    }

    IEnumerator Die()
    {
        lives--;
            dead = true;
            animator.SetBool("Dead", true);
            yield return new WaitForSeconds(3f);
    }

    IEnumerator Hit(Collider2D coll)
    {
        animator.SetBool("Hurt", true);
        hitted = true;
        rigidbody.velocity = new Vector2(0,3f);

        StartCoroutine(Recover());

        yield return new WaitUntil(() => grounded==true);
        hitted = false;
        animator.SetBool("Hurt", false);
    }

    IEnumerator Recover()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(0.2f);
        collider.enabled = true;
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -direction;
        transform.localScale = theScale;
    }

    public bool IsGrounded()
    {
        if (grounded==true) return true;
            else return false;
    }

    

}