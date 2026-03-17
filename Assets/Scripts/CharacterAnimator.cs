using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{


    Rigidbody rb;

    Animator anim;

    float speed ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



        if (rb.velocity.y == 0)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("doubleJump", false);
        }

        Fall();
        WalkRunIdle();
        DoubleJump();
    }


    void Fall()
    {
        if (rb.velocity.y < 1 && rb.velocity.y > -1 )
        {
            anim.SetBool("isGrounded", true);

        }
        else
        {
            anim.SetBool("isGrounded", false);
        }
    }

    void DoubleJump()
    {
        if (rb.velocity.y > 0 && anim.GetBool("isGrounded") == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("jumpx2");
                anim.SetTrigger("doubleJump");
            }

        }
    }

    void WalkRunIdle()
    {

        speed = rb.velocity.x + rb.velocity.z;

        if(speed < 0)
        {
            speed *= -1;
        }

            anim.SetFloat("playerSpeed", speed);
    }
}
