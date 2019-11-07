using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 20f;
    public Rigidbody2D rb;

    void Start(){
        rb.velocity = transform.right * speed; //when the character shoots, the bullet flies in his facing direction.
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
         //print info
         Enemy enemy = hitInfo.GetComponent<Enemy>(); //access to Enemy script
         if (enemy != null){ //if bullet hits something, take damage
            enemy.TakeDamage(damage);
             //deal damage
        }
        Destroy(gameObject);
        Debug.Log("Deal " + damage + " damage to " + hitInfo.name);
    }    
    }

