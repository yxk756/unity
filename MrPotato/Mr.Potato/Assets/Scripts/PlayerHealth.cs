using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    
    public float hurtPoint = 20;

    private SpriteRenderer healthBar;

    private Animator animator;

    public float nTime;
    
    public Vector3 healthBarScale;

    public AudioClip[] audioClips;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Health").GetComponent<SpriteRenderer>();
        healthBarScale = healthBar.transform.localScale;
        nTime = Time.time;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Time.time > nTime)
            {
                
                if (health > 0)
                {
                    //减血量
                    takeDamage(other.transform);
                    //更新血条
                    updateHealthBar();
                    nTime = Time.time;

                    if (health <= 0)
                    {
                        //播放死亡动画
                        animator.SetTrigger("die");
                        //掉到河里去
                        Collider2D[] colliders = GetComponents<Collider2D>();
                        foreach (var c in colliders)
                        {
                            c.isTrigger = true;
                        }
                    }

                    //给英雄背景设置层
                    SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
                    foreach (var s in spriteRenderers)
                    {
                        s.sortingLayerName = "UI";
                    }
                }
            }

        }
    }

    
    void takeDamage(Transform enemy)
    {
        health -= hurtPoint;
        int  i = Random.Range(0, audioClips.Length - 1);
        AudioSource.PlayClipAtPoint(audioClips[i],transform.position);
        
    }

    void updateHealthBar()
    {
        //healthBar
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        healthBar.transform.localScale = new Vector3(health * 0.01f,healthBarScale.y,healthBarScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
