using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //private Camera _camera;
    public Transform bulletSpawnPoint;

    Vector3 mouseDirection;

    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    private void Start()
    {
        //_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        //mouseDirection = _camera.ScreenToWorldPoint(Input.mousePosition);

        //Vector3 rotation = mouseDirection - transform.position;

        //float rotationY = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; //Atan2 returns the principal value of the arc tangent of y/x, expressed in radians. Rad2Deg returns radians to degrees.

        //transform.rotation = Quaternion.Euler(0, rotationY, 0); //a rotation around "rotationz" around the z axis, not the x or y

        if (Input.GetMouseButtonDown(0)) //if player left clicks...
        {
            var bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //will spawn the bullet wherever the gun is pointing

            bulletClone.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * bulletSpeed; //sends bullet flying
        }
    }
}