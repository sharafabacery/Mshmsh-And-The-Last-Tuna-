using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
   [SerializeField]
    protected int health,damage,HealthPickupChance;
    [SerializeField]
    protected float speed,timeBetweenAttacks;
    [SerializeField]
    protected GameObject healthPickup,tunaPickup,deathEffect,soundEffect;
    protected Transform player;
    protected Rigidbody2D rb;
    //AIPath aI;
    AIDestinationSetter target;
    
    public virtual void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        //rb.constraints = RigidbodyConstraints2D.None;
       
    }

    public virtual void Start() {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        target = GetComponent<AIDestinationSetter>();
        target.target=player;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }
    public void TakeDamage(int damageAmount){
        health-=damageAmount;
        Instantiate(soundEffect);
        if(health<=0){
            Instantiate(deathEffect,transform.position,transform.rotation);
            
            Instantiate(tunaPickup,transform.position,transform.rotation);
            int randHealth=Random.Range(0,101);
            if(randHealth<HealthPickupChance){
                Instantiate(healthPickup,transform.position+new Vector3(25,25),transform.rotation);
            }
         //  GameObject blood=(GameObject) Instantiate(deathEffect,transform.position,Quaternion.identity);
           //Destroy(blood,1f);
            Destroy(gameObject);
        }
    }
}    
