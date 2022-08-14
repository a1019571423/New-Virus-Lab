using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject boom;

    void Update()
    {
        DelayDestroy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject boomFX = Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(boomFX,0.1f);
    }
    void DelayDestroy()
    {
        Destroy(gameObject, 2f);
    }
}
