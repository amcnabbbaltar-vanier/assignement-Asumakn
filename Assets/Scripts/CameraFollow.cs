using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
