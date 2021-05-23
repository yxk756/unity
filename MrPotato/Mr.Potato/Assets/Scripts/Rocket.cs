using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explode;
    
    void Start()
    {
        Destroy(gameObject,2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag != "Player")
        {
            float random = Random.Range(0,360);
            Instantiate(explode, transform.position, Quaternion.Euler(new Vector3(0,0,random)));  
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
