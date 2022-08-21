using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : Character
{
    public List<Rigidbody2D> bulletTypes;
    int btIndex = 0;
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
        if (collision.CompareTag("GreenAgentia"))
        {
            RecoverHp();
        }
        if (collision.CompareTag("BlueAgentia"))
        {
            btIndex = 0;
            AddBullet(btIndex);
        }
        if (collision.CompareTag("YellowAgentia"))
        {
            btIndex = 1;
            AddBullet(btIndex);
        }
        if (collision.CompareTag("PurpleAgentia"))
        {
            btIndex = 2;
            AddBullet(btIndex);
        }
    }

    void AddBullet(int index)
    {
        if (bullets[0] == null)
        {
            bullets[0] = bulletTypes[index];
        }
        else if (bullets[0] != bulletTypes[index] && bullets[1] == null)
        {
            bullets[1] = bulletTypes[index];
        }
        else if (bullets[0] != bulletTypes[index] && bullets[1] != bulletTypes[index] && bullets[2] == null)
        {
            bullets[2] = bulletTypes[index];
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
                Invoke(nameof(RecoverLayer), downTime);
            }
        }
    }

    void RecoverLayer()
    {
        if (gameObject.layer == 13)
        {
            gameObject.layer = 8;
        }
    }

    void RecoverHp()
    {
        ph++;
        if (ph >= 3)
        {
            ph = 3;
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
