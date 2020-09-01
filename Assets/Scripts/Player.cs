using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool doorOpen = false;
    public bool onLadder = false;
    public float movementSpeed = 2;
    public float jumpForce = 10;

    public Text coinsCountText;
    public int coinsCount = 0;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Transform _transform;

    private void Start()
    {
        coinsCount = 0;
        
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        var climb = Input.GetAxisRaw("Vertical");

        Move(movement);

        Climb(movement, climb);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f && !onLadder)
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

    private void Climb(float movement, float climb)
    {
        if (onLadder)
        {
            _animator.SetBool("isClimb", true);
            transform.position += new Vector3(movement, climb, 0) * Time.deltaTime * movementSpeed;
        }
        else
        {
            _animator.SetBool("isClimb", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            TakeCoin();
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            TakeKey();
        }
    }

    private void TakeCoin()
    {
        coinsCount++;
        coinsCountText.text = "x" + coinsCount.ToString();
    }

    private void TakeKey()
    {
        doorOpen = true;
    }
}