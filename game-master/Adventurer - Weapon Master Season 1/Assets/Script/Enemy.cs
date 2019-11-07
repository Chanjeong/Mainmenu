using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP;
    [SerializeField] HealthBar healthBar;

    void Start(){
        currentHP=maxHP;
    }

    public void TakeDamage (float damage){ 
        currentHP -= damage; //health is decreased by damage dealt.
        if (currentHP <=0){
            Die(); 
        }
        healthBar.SetSize(currentHP/maxHP);
    }

    void Die(){
        Destroy(gameObject);
        Debug.Log("Enemy is dead");
    }

}

  
