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
        vector = rigid.velocity;
        if (player.transform.rotation.eulerAngles.y == 0)
        {
            vector.x += speed;
        }
        if (player.transform.rotation.eulerAngles.y == 180)
        {
            vector.x -= speed;
        }
        rigid.velocity = vector;

        rigid.rotation += 5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void DelayDestroy()
    {
        Destroy(gameObject, 0.6f);
    }
}
