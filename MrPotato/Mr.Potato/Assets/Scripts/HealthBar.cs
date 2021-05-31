using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform hero;

    public Vector3 offset = new Vector3(0,1,0);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hero.position + offset;
    }
}
