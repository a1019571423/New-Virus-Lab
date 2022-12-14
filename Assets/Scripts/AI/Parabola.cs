using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parabola : MonoBehaviour
{
    public float time = 3;//代表从A点出发到B经过的时长
    public Transform pointA;//点A
    public Transform pointB;//点B
    public float g = -10;//重力加速度
    // Use this for initialization
    private Vector2 speed;//初速度向量
    private Vector2 Gravity;//重力向量
    void Start()
    {

        transform.position = pointA.position;//将物体置于A点
        //通过一个式子计算初速度
        speed = new Vector2((pointB.position.x - pointA.position.x) / time,
            (pointB.position.y - pointA.position.y) / time - 0.5f * g * time);
        Gravity = Vector2.zero;//重力初始速度为0
    }
    private float dTime = 0;
    // Update is called once per frame
    void FixedUpdate()
    {

        Gravity.y = g * (dTime += Time.fixedDeltaTime);//v=at
        //模拟位移
        transform.Translate(speed * Time.fixedDeltaTime);
        transform.Translate(Gravity * Time.fixedDeltaTime);
    }
}
