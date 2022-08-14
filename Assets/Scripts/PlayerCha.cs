using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : Character
{
    public List<Transform> bulletTypes;
    public float ph = 3;
    bool hurt;
    bool die;

    private void Update()
    {
        animator.SetBool("Hurt", hurt);
        hurt = false;
    }
    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BlueAgentia")
        {
            bullets[0] = bulletTypes[0];
        }

        if (collision.tag == "Zombie")
        {
            Hurt();
        }
    }
    void Hurt()
    {
        hurt = true;
        ph--;
        if (ph < 0)
        {
            ph = 0;
            die = true;
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("Die", die);
        Invoke("Delay", 2);
        //Destroy(gameObject, 0.5f);
    }

    void Delay()
    {
        Time.timeScale = 0;//Í£Ö¹ÓÎÏ·
    }

}
