using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaPickup : MonoBehaviour
{
    //[SerializeField]
    //private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            other.GetComponent<Player>().scoreplusplus();
//sound Effect
        //visual effect
        Destroy(gameObject);

        }
            }
}
