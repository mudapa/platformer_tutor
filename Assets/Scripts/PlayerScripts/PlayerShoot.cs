using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
              Instantiate(bullet, shotPoint.position, transform.rotation);
        }
    }
}
