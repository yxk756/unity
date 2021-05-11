using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackGround : MonoBehaviour
{
    public Transform[] background;
    public float fParalax = 0.4f;
    public float layerPraction = 5f;
    public float fSmooth = 5f;

    private Transform cam;

    //上一帧摄像机位置
    private Vector3 previousCamPos;

    private Vector3 _vector3;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main.transform;
    }

    private void Start()
    {
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        //每一帧位移偏移量 * fParalax
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fParalax;

        for (int i = 0; i < background.Length; i++)
        {
            float fNewX = background[i].position.x + fParrlaxX * (1 + i * layerPraction);

            Vector3 newPos = new Vector3(fNewX, background[i].position.y,background[i].position.z);

            background[i].position = Vector3.Lerp(background[i].position,
                newPos,fSmooth * Time.deltaTime
                );
        }

        previousCamPos = cam.position;
    }
}
