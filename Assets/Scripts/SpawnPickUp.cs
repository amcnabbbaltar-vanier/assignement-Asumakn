using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUp : MonoBehaviour
{
    public GameObject SpeedBoost;
    public GameObject ScoreBoost;
    public GameObject JumpBoost;

    public GameObject Trap;

    GameObject newPickup;

    float timer = 0;

    MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer > 10)
        {


                SpawnJumpBoost();
                SpawnSpeedBoost();
                SpawnScoreBoost();
                SpawnTrap();

            timer = 0;
        }

    }


    void SpawnSpeedBoost()
    {

        newPickup = Instantiate(SpeedBoost, transform.position, Quaternion.identity);

        newPickup.transform.position = new Vector3(newPickup.transform.position.x + Random.Range(-renderer.bounds.size.x / 2, renderer.bounds.size.x / 2), transform.position.y + 1, newPickup.transform.position.z + Random.Range(-renderer.bounds.size.z / 2, renderer.bounds.size.z / 2));
    }

    void SpawnScoreBoost()
    {

        newPickup = Instantiate(ScoreBoost, transform.position, Quaternion.identity);
        newPickup.transform.position = new Vector3(newPickup.transform.position.x + Random.Range(-renderer.bounds.size.x / 2, renderer.bounds.size.x / 2), transform.position.y + 1, newPickup.transform.position.z + Random.Range(-renderer.bounds.size.z / 2, renderer.bounds.size.z / 2));
    }


    void SpawnJumpBoost()
    {

        newPickup = Instantiate(JumpBoost, transform.position, Quaternion.identity);

        newPickup.transform.position = new Vector3(newPickup.transform.position.x + Random.Range(-renderer.bounds.size.x / 2, renderer.bounds.size.x / 2), transform.position.y + 1, newPickup.transform.position.z + Random.Range(-renderer.bounds.size.z / 2, renderer.bounds.size.z / 2));

    }

    void SpawnTrap()
    {

        newPickup = Instantiate(Trap, transform.position, Quaternion.identity);

        newPickup.transform.position = new Vector3(newPickup.transform.position.x + Random.Range(-renderer.bounds.size.x / 2, renderer.bounds.size.x / 2), transform.position.y + 1, newPickup.transform.position.z + Random.Range(-renderer.bounds.size.z / 2, renderer.bounds.size.z / 2));

    }
}
