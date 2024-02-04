using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStuff : MonoBehaviour
{
    public int HP = 50;
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Damage();
        }
    }
    public void Damage()
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
