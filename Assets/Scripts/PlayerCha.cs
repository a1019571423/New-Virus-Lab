using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : Character
{
    public List<Rigidbody2D> bulletTypes;
    public float ph = 3;
    bool hurt;
    bool die;
    bool jumpDown;
    public float downTime = 0.5f;

    private void Update()
    {
        animator.SetBool("Hurt", hurt);
        hurt = false;
        JumpDown();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlueAgentia"))
        {
            bullets[0] = bulletTypes[0];
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Hurt();
        }
        if (collision.gameObject.layer == 13)
        {
            jumpDown = true;
        }
        else
        {
            jumpDown = false;
        }
    }
    void JumpDown()
    {
        if (jumpDown && isGround)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                gameObject.layer = 13;
                isGround = false;
                Invoke(nameof(ReCoverLayer), downTime);
            }
        }
    }

    void ReCoverLayer()
    {
        if (gameObject.layer == 13)
        {
            gameObject.layer = 8;
        }
    }
    void Hurt()
    {
        hurt = true;
        ph--;
        if (ph <= 0)
        {
            ph = 0;
            die = true;
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("Die", die);
        Invoke(nameof(Delay), 1f);
    }
    void Delay()
    {
        Time.timeScale = 0;//Í£Ö¹ÓÎÏ·
    }

}
