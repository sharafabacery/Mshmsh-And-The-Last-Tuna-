using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    //to do Animator
    [SerializeField]
    private float speed;
    [SerializeField]
    private int health,score;
    public GameObject meow;
    [SerializeField]
    private SpriteRenderer head;

    
    private Vector2 moveAmount;
    // Start is called before the first frame update
    void Start()
    {
        
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        UIManger.Instance.UpdateLive(health);
        UIManger.Instance.UpdateTunaCount(score);
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal=Input.GetAxisRaw("Horizontal");
        if(Horizontal==1){
            if(head.flipX==true)head.flipX=false;
        }else if(Horizontal==-1){
            if(head.flipX==false)head.flipX=true;
        }else{
            head.flipX=false;
        }
        Vector2 directionAxes=new Vector2(Horizontal,Input.GetAxisRaw("Vertical"));
        moveAmount=directionAxes.normalized*speed;
        if (directionAxes !=Vector2.zero)
        {
            animator.SetBool("IsRunning",true);
        }else
        {
            animator.SetBool("IsRunning",false);
        }
    }
    public void scoreplusplus(){
        score=score+1;
        UIManger.Instance.UpdateTunaCount(score);
    }
    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

    }
    public void TakeDamage(int damageAmount){
        health-=damageAmount;
        Instantiate(meow);
        UIManger.Instance.UpdateLive(health);
        //hurtAnim.SetTrigger("hurt");
        if(health<=0){
            UIManger.Instance.loadScene(3);
            Destroy(gameObject);
            //LOSE SCENE    

        }
           
        
        
    }
      public void Heal(int healAmount){
        if(healAmount+health>7){
                health=7;
                    }else{
        
           
            health+=healAmount;
UIManger.Instance.UpdateLive(health);
        }
    }
}
