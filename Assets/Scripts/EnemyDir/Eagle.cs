using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Enemy
{
    [SerializeField]
    private float stopDistance;
    private float attackTime;
    //private Animator animator;
    public Transform shotPoints;
    public GameObject EnemyBullot,effect;
    public override void   Start() {
        base.Start();
    //    animator=GetComponent<Animator>();

    }
    // Update is called once per frame
   private void Update()
    {
        if(player!=null){
            if(Vector2.Distance(transform.position,player.position)<stopDistance){
      //          transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
            if(Time.time>=attackTime){
                RangedAttack();//simulate
                attackTime=Time.time+timeBetweenAttacks;
                //animator.SetTrigger("attack");
            }
            }
            
        }
    }
    public void RangedAttack(){
        Vector2 direction=player.position-shotPoints.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;//direction to angle
        Quaternion rotation=Quaternion.AngleAxis(angle-90,Vector3.forward);//unity rotation angle to quet
        shotPoints.rotation=rotation;
       // Instantiate(effect,shotPoints.position,shotPoints.rotation);
        Instantiate(EnemyBullot,shotPoints.position,shotPoints.rotation);
        
    }

}
