using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;
    float speed = 0f;
    float jumpForce ;
    bool jump = false;

    bool isSpeedBoost = false;

    float speedTimer = 0;

    bool isJumpBoost = false;


    int jumpCount = 0;

    public float bonusSpeed = 3;

    public ParticleSystem particlePrefab;


    ParticleSystem ps;
    public GameObject PlayerCamera;

    MenuOptions menu;

    Camera cam;

    Vector3 SpawnPoint;

    bool moving = false;

    float motion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        cam = PlayerCamera.GetComponent<Camera>();
        ps.Stop();

        SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

      
        if (transform.position.y < -80)
        {
            Respawn();
        }

        GameManager.timer += Time.deltaTime;

        PlayerSpeed();
        PlayerMovement();
        JumpBoost();
        TurnPlayer();

        if (jumpCount == 2)
        {
            Invoke(nameof(ResetJump), 1.5f);
        }
    }

    void FixedUpdate()
    {

        if (jump)
        {
            Jump();
        }


    }

    void OnTriggerEnter(Collider other)
    {

        Instantiate(particlePrefab, transform);

        if (other.CompareTag("JumpBoost"))
        {

            isJumpBoost = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("SpeedBoost"))
        {

            ps.Play();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ScoreBoost"))
        {
            GameManager.incrementScore(50);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            GameManager.DamagePlayer();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("EndPoint"))
        {
            menu.NextLevel();

        }


    }

    void Jump()
    {
        if (jumpCount < 2)
        {
            rb.velocity += Vector3.up * jumpForce;
            jumpCount++;
        }


        jump = false;
    }





    void PlayerMovement()
    {

        Vector3 orientation = cam.transform.forward;
        orientation.y = 0;

        motion = rb.velocity.x + rb.velocity.z;

        if (motion < 0)
        {
            motion *= -1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (motion < 15)
            {
                rb.velocity += orientation * speed * Input.GetAxis("Vertical") * Time.deltaTime;

            }
        }
        else
        {
            if (motion < 10)
            {
                rb.velocity += orientation * speed * Input.GetAxis("Vertical") * Time.deltaTime;

            }
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }


        if (Input.GetAxis("Vertical") == 0 && rb.velocity.y == 0)
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    void PlayerSpeed()
    {

        if (moving)
        {
            speed = 15.2f;
        }
        else
        {
            speed = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed += 5;
        }


        if (isSpeedBoost)
        {
            speed += 5;
            speedTimer += Time.deltaTime;

            if (speedTimer > 5)
            {
                ps.Stop();
                isSpeedBoost = false;
            }
        }


    }

    void JumpBoost()
    {

        jumpForce = 5f;

        if (isJumpBoost)
        {
            jumpForce += 5;
        }

    }


    void Respawn()
    {
        transform.position = SpawnPoint;
        rb.velocity = Vector3.zero;
        GameManager.DamagePlayer();
    }

    void ResetJump()
    {
        jumpCount = 0;
    }


    void TurnPlayer()
    {
        Vector3 turn = new Vector3(0, Input.GetAxis("Horizontal"), 0);

        transform.Rotate(turn);

         rb.rotation.Set(0, transform.rotation.y, 0, 0);
    }
}
