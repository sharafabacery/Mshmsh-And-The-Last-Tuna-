using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float lifeTime,speed;
    [SerializeField]
    private int damage;
    public GameObject sound;
    //init Game object for effect
    //init GameObject for sound effect
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(sound);
        
        Invoke("DestroyProjctile",lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime*speed);
    }
    private void DestroyProjctile(){
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Enemy"){
            other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("damaged function");
            
        }else if(other.tag =="Boss")
        {
         //handle damage function
            
            
        }
        DestroyProjctile();
    }
}
