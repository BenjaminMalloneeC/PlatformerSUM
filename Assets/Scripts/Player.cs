using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 5f;
    public int currentJumps;
    public int maxJump = 1;
    public float height = 1f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        currentJumps = maxJump;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;

        rigidBody.velocity = new Vector2(xMovement, rigidBody.velocity.y);

        if (rigidBody.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        if (rigidBody.velocity.x < 0)
        {
            sprite.flipX = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                currentJumps = maxJump;
            }
            if (currentJumps > 0)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        currentJumps--;
        rigidBody.AddForce(Vector2.up * jumpForce);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, (height / 2f) + 0.1f);

        return (hitinfo.collider != null);
    }
}
