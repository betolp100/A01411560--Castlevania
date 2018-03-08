using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    private Animator animator;
    public Color dmgColor;
    private Color startColor;
    protected Renderer rend;
    public GameObject firePrefab;
    private bool ishitten = false;
    public int lives = 1;
    private bool ghostDead = false;
    public float speed = 4;
    private int direction = -1;
    private bool movingLeft = true;
    private Vector3 walk;
	void Start ()
    {
        animator = GetComponent<Animator>();
        rend=GetComponent<Renderer>();
        startColor = rend.material.color;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ghostDead == true)
        {
            GameObject.Find("WaveSpawner").GetComponent<WaveSpawner>().ghostCounter--;
            Destroy(gameObject);
        }
        if (movingLeft) MoveLeft(); else MoveRight();
    }

    void MoveRight()
    {
        if (ishitten == false)
        {
            movingLeft = false;
            walk.x = 1;
            Flip();
            transform.position += walk * speed * Time.deltaTime;
        }
    }

    void MoveLeft()
    {
        if (ishitten == false)
        {
            movingLeft = true;
            walk.x = -1;
            Flip();
            transform.position += walk * speed * Time.deltaTime;
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -walk.x;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            if (movingLeft == false)
                movingLeft = true;
            else movingLeft = false;
        }

        if (collision.gameObject.tag == "Whip")
        {
            lives--;
            if (lives <= 0)
            {
                Instantiate(firePrefab, transform.position, Quaternion.identity);
                ghostDead = true;
            }
            else
            {

                StartCoroutine(Hitted());
            }
        }
    }

    IEnumerator Hitted()
    {
        ishitten = true;
        rend.material.color = dmgColor;
        animator.enabled = false;
        yield return new WaitForSeconds(.25f);
        rend.material.color = startColor;
        ishitten = false;
        animator.enabled = true;
    }
}
