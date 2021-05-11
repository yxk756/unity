using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MCamera : MonoBehaviour
{
    private Transform player;

    public float xMargin = 2;
    public float yMargin = 2;

    public float smoothX = 1;
    public float smoothY = 1;

    private Vector2 minCamXandY = new Vector2(-8,-8);

    private Vector2 maxCamXandY = new Vector2(8,8);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private bool NeedMoveX()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }
    
    private bool NeedMoveY()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        TrackPlayer();
    }

    private void TrackPlayer()
    {
        float CamNewX = transform.position.x;
        float CamNewY = transform.position.y;
        if (NeedMoveX()) //计算新摄像机位置
            CamNewX = Mathf.Lerp(CamNewX,player.position.x, smoothX * Time.deltaTime);
        if (NeedMoveY())
            CamNewY = Mathf.Lerp(CamNewY, 
                player.position.y, smoothY * Time.deltaTime);
        //将新摄像机位置固定在合法范围内
        CamNewX = Mathf.Clamp(CamNewX, minCamXandY.x, maxCamXandY.x);
        CamNewY = Mathf.Clamp(CamNewY, minCamXandY.y, maxCamXandY.y);
        
        transform.position = new Vector3(CamNewX, CamNewY, 
            transform.position.z);

    }
    
}
