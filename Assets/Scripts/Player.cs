using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 2;
    public float JumpForce = 10;

    private Rigidbody2D _rigidbody;
    public Animator _animator;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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

    void Move(float movement)
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
    
    void Jump(bool isJump)
    {
        if (isJump)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _animator.SetBool("isJump", true);
        }
        else
        {
            _animator.SetBool("isJump", false);
        }
    }
}