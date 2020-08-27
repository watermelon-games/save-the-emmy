using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool onLadder = false;
    public float movementSpeed = 2;
    public float jumpForce = 10;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");

        Move(movement);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            Jump(true);
        }
        else
        {
            Jump(false);
        }
    }

    private void Move(float movement)
    {
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        
        if (movement != 0)
        {
            if (movement > 0)
            {
                _animator.SetBool("isMove", true);
                _animator.SetBool("isRight", true);
            }

            if (movement < 0)
            {
                _animator.SetBool("isMove", true);
                _animator.SetBool("isLeft", true);
            }
        }
        else
        {
            _animator.SetBool("isMove", false);
            _animator.SetBool("isRight", false);
        }
    }
    
    private void Jump(bool isJump)
    {
        if (isJump)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _animator.SetBool("isJump", true);
        }
        else
        {
            _animator.SetBool("isJump", false);
        }
    }

    private void Climb(bool isClimb)
    {
        if (isClimb)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _animator.SetBool("isClimb", true);
        }
        else
        {
            _animator.SetBool("isClimb", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            onLadder = true;
            if (onLadder == true && Input.GetKeyDown("w"))
            {
                Climb(true);
            }
            Debug.Log("I'm on ladder.");
        }
        else
        {
            onLadder = false;
        }
    }
}