using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCha playerCha;
    bool jump;
    bool attack;

    void Start()
    {
        playerCha = GetComponent<PlayerCha>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }

        playerCha.Move(h, jump);
        jump = false;

        if (Input.GetButtonDown("Fire2"))
        {
            attack = true;
        }

        playerCha.Attack(attack);
        attack = false;
    }
}
