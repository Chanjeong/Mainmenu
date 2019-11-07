using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float attackSpeed = 0.8f; //how many attacks player can make in a second

    private float timeBtwAttack;
    void Update()
    {
        if(timeBtwAttack<=0){ //if attack wait time < 0, you are able to shoot
            if(Input.GetKeyDown(KeyCode.J)){
                Shoot();
                timeBtwAttack = 1/attackSpeed ; //when you shoot, the timer resets
            }
        
        }else{
             timeBtwAttack -= Time.deltaTime;  //when wait time > 0, the timer counts down.
            } 
        
    }
    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}

