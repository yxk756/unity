using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D heroBody;

    public float MaxSpeed = 3;

    private Animator animator;
    
    //用户输入的力量 -1  ->   1
    private float finput = 0.0f;

    //移动的力量放大的倍数
    public float moveForce = 100;

    //jump的力量放大的倍数
    public float jumpForce = 555;

    //是否朝右
    [HideInInspector] //在Unnity中隐藏
    public bool bFaceRight = true;
    
    private Transform groundCheck;

    //射线检测结果
    private bool bGround = false;
    
    //是否按下跳跃键
    private bool bJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        
        groundCheck = transform.Find("groundCheck");

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //检测键盘输入  Horizontal，得到 (-1,1)的浮点数
        finput = Input.GetAxis("Horizontal");
        
        //控制转身
        if (finput < 0 && bFaceRight)
        {
            Flip();
        }
        else if(finput > 0 && !bFaceRight)
        {
            Flip();
        }
        
        //射线检测
        
        bGround =  Physics2D.Linecast(transform.position,groundCheck.position,1 << LayerMask.NameToLayer("Ground"));
        
        //检测跳跃键
        bJump = Input.GetButtonDown("Jump");

        Jump();
        
        //奔跑动作
        animator.SetFloat("speed",Mathf.Abs(heroBody.velocity.x));
    }

    void FixedUpdate()
    {
        //Abs绝对值，因为力是向量
        if (Mathf.Abs(heroBody.velocity.x) < MaxSpeed)
        {
            //给物体添加一个力
            heroBody.AddForce(finput * moveForce * Vector2.right);
        }
        //最大速度时
        if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
        {
            //设定速度为最大速度
            heroBody.velocity = 
                new Vector2(Mathf.Sign(heroBody.velocity.x) *
                            MaxSpeed, heroBody.velocity.y);
        }
    }

    /**
     * 转身
     */
    void Flip()
    {
        Vector3 scale = transform.localScale;
        //反向
        scale.x *= -1;
        transform.localScale = scale;
        bFaceRight = !bFaceRight;
    }

    /**
     * Jump
     */
    void Jump()
    {
        //jump
        if (bGround && bJump)
        {
            heroBody.AddForce(new Vector2(0f, jumpForce ) );
            bJump = false;
            //播放跳跃动作
            animator.SetTrigger("jump");
        }
        
    }
}
