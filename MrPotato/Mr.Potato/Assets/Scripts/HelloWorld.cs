using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//MonoBehaviour Unity大的父类
/**
生命周期
初始化函数： Awake -> Start
更新函数： FixedUpdate -> Update
销毁函数： Destory
*/
public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        Debug.Log("Awake");
    }

}
