using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
 [SerializeField]
    private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }
}
