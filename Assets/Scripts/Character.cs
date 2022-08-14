using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5;
    Vector2 vector;
    bool isGround;
    public float jumpspeed = 5;

    Rigidbody2D rigd;
    public Animator animator;

    public List<Transform> bullets;
    public Transform bulletPoint;


    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    public void Move(float x,bool jump)
    {
        if (x < 0 && transform.rotation.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
        else if (x > 0 && transform.rotation.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }

        vector = rigd.velocity;
        vector.x = x * speed;

        if (jump && isGround)
        {
            vector.y = jumpspeed;
            isGround = false;
        }

        if (!isGround)
        {
            vector.y += Physics2D.gravity.y * Time.deltaTime * 0.6f;
        }
        
        rigd.velocity = vector;
        UpdateAnim();
    }

    private void FixedUpdate()
    {
        isGround = false;
        if (Physics2D.Raycast(transform.position + new Vector3(0, 0.15f, 0), Vector2.down, 0.2f, 1<<9))
        {
            isGround = true;
            Debug.DrawLine(transform.position + new Vector3(0, 0.15f, 0), transform.position - new Vector3(0, 0.05f, 0), Color.red);
        }
    }

    public void HorAttack(bool attack)
    {
        if (attack)
        {
            if (bullets[0] == null)
            {
                return;
            }
            Transform transform = Instantiate(bullets[0], bulletPoint.position, Quaternion.identity);
        }

        animator.SetBool("HorAttack", attack);

    }
    public void UpAttack(bool attack)
    {
        if (attack)
        {
            Debug.Log("����2");
        }

        animator.SetBool("UpAttack", attack);

    }
    void UpdateAnim()
    {
        float run = Mathf.Abs(vector.x);
        animator.SetFloat("Run", run/speed);
        animator.SetBool("IsGround", isGround);
    }
}
