using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBullet : MonoBehaviour
{
private Player playerScript;
    private Vector2 targetPosition;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
        playerScript=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition=playerScript.transform.position;
        Destroy(gameObject,4);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript!=null){
if(Vector2.Distance(transform.position,playerScript.transform.position)>1f){
            transform.position=Vector2.MoveTowards(transform.position,playerScript.transform.position,speed*Time.deltaTime);
        }
    
        }
        }
    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
