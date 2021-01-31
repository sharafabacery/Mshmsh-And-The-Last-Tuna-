using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;
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
        Instantiate(effect,transform.position,transform.rotation);
        Destroy(gameObject);

        }
            }
}
