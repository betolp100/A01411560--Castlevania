using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public List<Rigidbody2D> rigibodies;
    public Vector3 lastPos;
    Transform _transform;

    protected Animator animator;
    public bool upDown,rightLeft;
    // Use this for initialization
    void Start()
    {
        rigibodies = new List<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _transform = transform;
        lastPos = _transform.position;
        
    }
    // Update is called once per frame
    void Update () {
        if (rightLeft) { animator.SetBool("IsLeftRight", true); }
        if (upDown) { animator.SetBool("IsUpDown", true); }
    }

    private void LateUpdate()
    {
        if (rigibodies.Count > 0)
        {
            for (int i = 0; i < rigibodies.Count; i++)
            {
                Rigidbody2D rigi = rigibodies[i];
                Vector3 velocity = (_transform.position - lastPos);
                rigi.transform.Translate(velocity);
            }
        }
        lastPos = _transform.position;  //calling an update after the regular update 
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D rigi = col.collider.GetComponent<Rigidbody2D>();
            if (rigi != null)
            {
                Add(rigi);
            }//adding the player to a rigibody list
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D rigi = col.collider.GetComponent<Rigidbody2D>();
            if (rigi != null)
            {
                Remove(rigi);
            }//removing the player from the rigibody list
        }
    }

    void Add(Rigidbody2D rigi)
    {
        if (!rigibodies.Contains(rigi))
            rigibodies.Add(rigi);
    }

    void Remove(Rigidbody2D rigi)
    {
        if (rigibodies.Contains(rigi))
            rigibodies.Remove(rigi);
    }
}
