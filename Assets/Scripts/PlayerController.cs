using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCha playerCha;
    bool jump;
    bool horAttack;
    bool upAttack;

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

        if (Input.GetButtonDown("Fire1"))
        {
            horAttack = true;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            upAttack = true;
        }

        playerCha.HorAttack(horAttack);
        horAttack = false;
        playerCha.UpAttack(upAttack);
        upAttack = false;
    }
}
