using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;

    public float fSpeed = 10f; //初始化速度

    private PlayerControl _playerControl;
    
    private bool fired = false;
    
    private Animator animator;

    private AudioSource ac;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerControl = GameObject.Find("hero").GetComponent<PlayerControl>();
        animator = transform.root.GetComponent<Animator>();

        ac = GetComponent<AudioSource>();
    }
   
    void SendFire()
    {
        if (fired)
        {
            animator.SetTrigger("shoot");
            ac.Play();
            Vector3 speed = new Vector3(0, 0, 0);
            if (_playerControl.bFaceRight)
            {
                //Debug.Log("rrrrft");
                Rigidbody2D rRocket = Instantiate(rocket,transform.position, Quaternion.Euler(speed));
                rRocket.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                //Debug.Log("left");
                speed.z = 180;
                Rigidbody2D rRocket = Instantiate(rocket,transform.position, Quaternion.Euler(speed));
                rRocket.velocity = new Vector2(-fSpeed, 0);
            }
            
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        fired = Input.GetButtonDown("Fire1");
        _playerControl = transform.root.GetComponent<PlayerControl>();
        SendFire();
    }
    
}
