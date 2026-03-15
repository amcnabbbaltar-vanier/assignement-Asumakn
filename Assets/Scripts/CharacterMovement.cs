using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    float speed = 0f;
    float jumpForce = 100f;
    bool jump = false;

    bool isSpeedBoost = false;

    float speedTimer = 0;

    bool isJumpBoost = false;

    float JumpTimer = 0;

    public float bonusSpeed = 3;

    public ParticleSystem particlePrefab;

    float PlayerTurn = 0;

    ParticleSystem ps;
    public GameObject PlayerCamera;

    MenuOptions menu = new MenuOptions();

    Camera cam;

    Vector3 SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        JumpBoost();
        PlayerMovement();


    }

    void FixedUpdate()
    {

        if (jump)
        {

            if (anim.GetBool("isGrounded") == false)
            {
                if (anim.GetBool("doubleJump"))
                {
                    anim.SetBool("doubleJump", false);
                }
                else
                {
                    anim.SetBool("doubleJump", true);
                    Jump();

                }
            }
            else
            {
                Jump();
                anim.SetBool("isGrounded", false);

            }


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
        rb.velocity += Vector3.up * jumpForce;
        jump = false;
    }





    void PlayerMovement()
    {


        Vector3 turn = new Vector3(0, Input.GetAxis("Horizontal"), 0);

        transform.Rotate(turn);

        rb.rotation.Set(0, transform.rotation.y, 0, 0);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("doubleJump", false);
        }

        anim.SetFloat("playerSpeed", speed);

        Vector3 orientation = cam.transform.forward;

        orientation.y = 0;

        rb.velocity += orientation * speed * Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetAxis("Vertical") == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    void PlayerSpeed()
    {


        if (isSpeedBoost)
        {

            speedTimer += Time.deltaTime;

            if (speedTimer < 10)
            {
                if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && Input.GetKey(KeyCode.LeftShift))
                {
                    speed = 20.2f + bonusSpeed;
                }
                else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
                {
                    speed = 15.2f + bonusSpeed;
                }
                else
                {
                    speed = 0;
                }
            }
            else
            {
                speedTimer = 0;
                isSpeedBoost = false;
                ps.Stop();
            }

        }
        else
        {


            if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && Input.GetKey(KeyCode.LeftShift))
            {
                speed = 20.2f;
            }
            else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                speed = 15.2f;
            }
            else
            {
                speed = 0;
            }
        }

    }

    void JumpBoost()
    {
        if (isJumpBoost)
        {
            jumpForce = 15f;
        }
        else
        {
            jumpForce = 10f;
        }

        JumpTimer += Time.deltaTime;

        if (JumpTimer > 30)
        {
            isJumpBoost = false;
        }
    }


    void Respawn()
    {
        transform.position = SpawnPoint;
        rb.velocity = Vector3.zero;
        GameManager.DamagePlayer();
    }
}
