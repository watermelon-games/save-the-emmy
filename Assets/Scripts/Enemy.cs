using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1;
    public bool toLeft = true;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var movement = toLeft ? -1 : 1;

        Move(movement);
    }
    
    private void Move(float movement)
    {
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (movement > 0)
        {
            _animator.SetBool("isMove", true);
            _animator.SetBool("isRight", true);
            _animator.SetBool("isLeft", false);
        }
        else
        {
            _animator.SetBool("isMove", true);
            _animator.SetBool("isRight", false);
            _animator.SetBool("isLeft", true);
        }
    }
}