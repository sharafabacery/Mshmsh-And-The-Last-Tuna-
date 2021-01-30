using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minX,maxX,minY,maxY;
    private Transform PlayerTransform;
    void Awake()
    {
        PlayerTransform=GameObject.FindWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position=PlayerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerTransform!=null){
            float ClampedX=Mathf.Clamp(PlayerTransform.position.x,minX,maxX);//cons
            float Clampedy=Mathf.Clamp(PlayerTransform.position.y,minY,maxY);//cons
            transform.position=Vector2.Lerp(transform.position,new Vector2(ClampedX,Clampedy),speed);//move a to b speed
   
        }
    }
}
