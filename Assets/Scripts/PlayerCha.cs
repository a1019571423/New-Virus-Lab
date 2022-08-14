using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : Character
{
    public List<Rigidbody2D> bulletTypes;
    public float ph = 3;
    bool hurt;
    bool die;

    private void Update()
    {
        animator.SetBool("Hurt", hurt);
        hurt = false;
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
