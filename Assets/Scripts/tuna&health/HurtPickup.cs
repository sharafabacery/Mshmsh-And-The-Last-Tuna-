using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPickup : MonoBehaviour
{
    public int healAmount;
    //public GameObject pickupEffect;
    
    
       void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            other.GetComponent<Player>().Heal(healAmount);
           // Instantiate(pickupEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
