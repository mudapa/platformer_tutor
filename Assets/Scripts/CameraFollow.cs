using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;
    public float cameraSpeed;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position + offset, cameraSpeed * Time.deltaTime);
    }
}
