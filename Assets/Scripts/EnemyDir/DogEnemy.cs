using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class DogEnemy : Enemy
{
    [SerializeField]
    private float attackSpeed,stopDistance;
    private float attackTime;
    public AIPath ai;
    
    private void Update() {
       if(player!=null){
          // Debug.Log(Vector2.Distance(transform.position,player.position));
            if(Vector2.Distance(transform.position,player.position)>stopDistance){
                transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
            }else{
                
                if (Time.time>attackTime)
            {
                StartCoroutine(Attack());
                attackTime=Time.time+timeBetweenAttacks;
            }
            }
        }
    }
     IEnumerator Attack(){
        player.GetComponent<Player>().TakeDamage(damage);
        Vector2 orginalPostion=transform.position;
        Vector2 targetPosition=player.position;
        float percent=0;
        while (percent<=1)
        {
            percent+=Time.deltaTime*attackSpeed;
            float formula=(-Mathf.Pow(percent,2)+percent)*4;
            transform.position=Vector2.Lerp(orginalPostion,targetPosition,formula);
            yield return null;
        }

    }
}
