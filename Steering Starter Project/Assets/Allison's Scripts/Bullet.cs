using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Ghost ghost;
    public float damage = 5;
    private float deleteAfterTime = 1f;

    private void Start()
    {
        Destroy(this.gameObject, deleteAfterTime);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if (collision.gameObject.tag == ("Rock")) //Damage player and ghost if hit
    //    //{
    //    //    Damage(collision.gameObject);
    //    //}
    //}
    //public virtual void Damage(GameObject g)
    //{
    //    //ghost.curHP -= 5;
    //    //g.GetComponent<Ghost>().curHP -= 5;
    //    //Debug.Log("Hit ghost");
    //}
}
