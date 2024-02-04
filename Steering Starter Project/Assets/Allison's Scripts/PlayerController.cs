using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 70f;
    private float playerSpeed = 2f;

    public bool isMoving = false;

    public int health = 100;

    //public Rigidbody rb;

    void Update()
    {
        Vector3 direction = transform.position += transform.forward * -playerSpeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Debug.Log("Collided with rock");
            DamagePlayer();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void DamagePlayer()
    {
        health -= 10;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
