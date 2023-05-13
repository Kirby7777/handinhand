using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool DoubleJumpActive;
    public float maxJumps;
    private float JumpsLeft;
    Rigidbody2D rb;
    BoxCollider2D coll;
    [SerializeField] LayerMask JumpableGround;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        JumpsLeft = maxJumps;
        maxJumps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bool JumpButton = Input.GetButtonDown("Jump");
        float dirX = Input.GetAxisRaw("Horizontal");

        if (JumpButton && JumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
            JumpsLeft -= 1;
        }

        if (isGrounded() && rb.velocity.y <=0 )
        {
            JumpsLeft = maxJumps;
        }

        if (DoubleJumpActive)
        {
            maxJumps = 2;
        }
        

        rb.velocity = new Vector2 (dirX * speed, rb.velocity.y);
    }



     private bool isGrounded ()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.5f, JumpableGround);
    }

   
    
}
