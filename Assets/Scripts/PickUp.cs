using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1.5f;
    float timer = 0;
    bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke(nameof(deSpawn), 10);
        
    }

    // Update is called once per frame
    void Update()
    {

     //   transform.Rotate(new Vector3(0, 1, 0));
    }


    void FixedUpdate()
    {
        //rb.rotation = Quaternion.Euler(Vector3.up *speed);
        Bounce();
    }

    void deSpawn()
    {
        Destroy(this.gameObject);
    }
    void Bounce()
    {

        timer += Time.deltaTime;
        if (timer > 1.25)
        {
            if (up)
            {
                rb.velocity = Vector3.down * speed;
                up = false;

            }
            else
            {
                rb.velocity = Vector3.up * speed;
                up = true;
            }
            timer = 0;
        }
    }


}
