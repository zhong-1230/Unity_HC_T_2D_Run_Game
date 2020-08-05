﻿using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 5;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 350;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;

    public bool isGround;
    public int coin;

    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    public Animator ani;
    public Rigidbody2D rig;
    public CapsuleCollider2D cap;
    public AudioSource and;

    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {

    }
    /// <summary>
    /// 滑行
    /// </summary>
    private void Slide()
    {
        bool ctrl = Input.GetKey(KeyCode.LeftControl);
        ani.SetBool("滑行開關", ctrl);

        // 如果 按下 ctrl
        // 站立 -0.1 -0.4 1.35 1.35
        // 否則
        // 滑行 -0.1 -0.4 1.35  3.6
        if (ctrl)
        {
            cap.offset = new Vector2(-0.1f, -0.4f);
            cap.size = new Vector2(1.35f, 1.35f);
        }
        else
        {
            cap.offset = new Vector2(-0.1f, -0.4f);
            cap.size = new Vector2(1.35f, 3.6f);
        }
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // 動畫控制器.設定布林值("參數名稱",布林值)
        // true 玩家是否按下空白鍵
        bool space = Input.GetKeyDown(KeyCode.Space);

        // 2D 射線碰撞物件 = 2D 物理.射線碰撞(起點，方向，長度，圖層)
        // 圖層語法：1 << 圖層編號
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.07f, -1.1f), -transform.up, 0.1f, 1 << 8);

        if (hit)
        {
            isGround = true;
        }
        // 如果 在地板上
        if (isGround)
        {
            //如果 按下空白鍵
            if (space)
            {
                ani.SetBool("跳躍開關", true);
                // 剛體.添加推力(二維向量)
                rig.AddForce(new Vector2(0, jump));
                // 是否在地板上 = 否
                isGround = false;
            }
        }



    }
    /// <summary>
    /// 吃金幣
    /// </summary>
    private void EatCoin()
    {

    }
    /// <summary>
    /// 受傷
    /// </summary>
    private void Hit()
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
    /// <summary>
    /// 過關
    /// </summary>
    private void Pass()
    {

    }


    #endregion

    #region 事件
    private void Start()
    {

    }

    private void Update()
    {
        Jump();
        Slide();
    }

    // 繪製圖示事件：繪製輔助線條，僅在 Scene 看得到
    private void OnDrawGizmos()
    {
        // 圖示.顏色 = 顏色.紅色
        Gizmos.color = Color.red;
        // 圖示.繪製射線(起點，方向)
        // transform 此物件的變形元件
        // transform.position 此物件的座標
        // transform.up 此物件上方      Y  預設為1
        // transform.right 此物件右方   X  預設為1
        // transform.forward 此物件前方 Z  預設為1

        Gizmos.DrawRay(transform.position + new Vector3(-0.07f, -1.1f), -transform.up * 0.1f);
    }
    #endregion
}
