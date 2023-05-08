using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool doublejump;
    public bool hasjumped;
    void Start()
    {
        hasjumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if (hasjumped == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
              
            }
            hasjumped = true;


        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doublejump == false)
        {
            hasjumped = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (doublejump == false)
        {
            hasjumped = true;
        }
    }
}
