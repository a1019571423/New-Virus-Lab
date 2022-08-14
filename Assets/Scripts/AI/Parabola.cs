using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parabola : MonoBehaviour
{
    public float time = 3;//�����A�������B������ʱ��
    public Transform pointA;//��A
    public Transform pointB;//��B
    public float g = -10;//�������ٶ�
    // Use this for initialization
    private Vector2 speed;//���ٶ�����
    private Vector2 Gravity;//��������
    void Start()
    {

        transform.position = pointA.position;//����������A��
        //ͨ��һ��ʽ�Ӽ�����ٶ�
        speed = new Vector2((pointB.position.x - pointA.position.x) / time,
            (pointB.position.y - pointA.position.y) / time - 0.5f * g * time);
        Gravity = Vector2.zero;//������ʼ�ٶ�Ϊ0
    }
    private float dTime = 0;
    // Update is called once per frame
    void FixedUpdate()
    {

        Gravity.y = g * (dTime += Time.fixedDeltaTime);//v=at
        //ģ��λ��
        transform.Translate(speed * Time.fixedDeltaTime);
        transform.Translate(Gravity * Time.fixedDeltaTime);
    }
}
