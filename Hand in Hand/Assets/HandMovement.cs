using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D rb;
    BoxCollider2D coll;
    [SerializeField] LayerMask JumpableGround;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
        }

        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * speed, rb.velocity.y);
        

    }

     private bool isGrounded ()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.5f, JumpableGround);
    }

   
    
}
