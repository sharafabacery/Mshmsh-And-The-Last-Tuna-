using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenShots;
    [SerializeField]
    
    private GameObject projectile,effect;
    [SerializeField]
    
    private Transform shotPoint;
    
    private float shotTime;
    [SerializeField]
    Animator cameraAnim;

    private void Start() {
        cameraAnim=Camera.main.GetComponent<Animator>();
    }
   
    // Update is called once per frame
    void Update()
    {
        //direction where is cursor and weapon
        //pixel coo mouse(in world)->change to unity 
        Vector2 direction=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;//direction to angle
        Quaternion rotation=Quaternion.AngleAxis(angle-90,Vector3.forward);//unity rotation angle to quet
        transform.rotation=rotation;
        if (Input.GetMouseButton(0))
        {
            if (Time.time>shotTime)
            {
                //Debug.Log("shot");
               GameObject proj=(GameObject) Instantiate(projectile,shotPoint.position,shotPoint.rotation);
                Instantiate(effect,proj.transform.position,proj.transform.rotation);
                
               cameraAnim.SetTrigger("shake");
                shotTime=Time.time+timeBetweenShots;
            }
        }
    }
}
