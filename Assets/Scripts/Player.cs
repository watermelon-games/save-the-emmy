using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public GameObject btnLeft;
    public GameObject btnRight;

    public float PosBtnLeft;
    public float PosBtnRight;

    public float run;

    public bool IsMoveRight = true;
    public bool IsMoveLeft = false;

    public bool IsJump = false;

    void Start()
    {
        PosBtnLeft = btnLeft.transform.position.y;
        PosBtnRight = btnRight.transform.position.y;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Move(true, true, false, false);
            }
            else
            {
                Move(true, false, false, false);
            }
        }
        else
        {
            Move(false, false, false, false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move(bool move, bool isRight, bool crouch, bool jump)
    {
        if (move)
        {
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }

        if (isRight)
        {
            anim.SetBool("ToRight", true);
            anim.SetBool("ToLeft", false);
        }
        else
        {
            anim.SetBool("ToRight", false);
            anim.SetBool("ToLeft", true);
        }
        
        anim.SetBool("IsJump", false);
    }
    
    void Crouch()
    {
        Debug.Log("Crouch");
    }
    
    void Jump()
    {
        anim.SetBool("IsJump", true);
        rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
    }
}
