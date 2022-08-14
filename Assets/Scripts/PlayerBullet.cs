using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector2 vector;
    Rigidbody2D rigid;
    GameObject player;
    public float speed = 7;

    public Transform boom;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        Move();
        DelayDestroy();
    }
    void Move()
    {
        rigid.rotation -= 5f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void DelayDestroy()
    {
        Destroy(gameObject, 2f);
    }
}
